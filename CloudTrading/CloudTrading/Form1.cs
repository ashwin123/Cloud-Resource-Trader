using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CloudTrading
{
    public partial class Form1 : Form
    {
        SocketPermission permission;
        Socket sListener;
        IPEndPoint ipEndPoint;
        Socket handler;
        static Dictionary<string, clients> Clients = new Dictionary<string, clients>();
        clients client1, client2, client3;
        static int flag, timeout;
        public Form1()
        {
            InitializeComponent();
            client1 = new clients("client1", c1_cpu, c1_mem, c1_storage, c1_cpu_p, c1_mem_p, c1_storage_p);
            client2 = new clients("client2", c2_cpu, c2_mem, c2_storage, c2_cpu_p, c2_mem_p, c2_storage_p);
            client3 = new clients("client3", c3_cpu, c3_mem, c3_storage, c3_cpu_p, c3_mem_p, c3_storage_p);
            Clients["client1"] = client1;
            Clients["client2"] = client2;
            Clients["client3"] = client3;
            creditBox.Text = "0";
            update();
        }
        public static void update()
        {
           
            foreach(var client in Clients.Values)
            {
                
                
               client.updateFields("1","0","1","0","1","0");
            }
        }
        public static void Realupdate(string name, string c,string ca,string m,string ma,string s,string sa)
        {
            clients client;
            client = Clients[name];
            client.updateFields(c,ca,m,ma,s,sa);           
        }
        public static ManualResetEvent allDone = new ManualResetEvent(false);

        private void button1_Click(object sender, EventArgs e)
        {
            IPHostEntry ipHost = Dns.GetHostEntry("");
            IPAddress ipAddr = ipHost.AddressList[0];
            IPEndPoint ipe = new IPEndPoint(ipAddr, 2015);
            Socket sListener = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            sListener.Bind(ipe);
            sListener.Listen(10);
            AsyncCallback aCallback = new AsyncCallback(AcceptCallback);
            sListener.BeginAccept(aCallback, sListener);
        }

        public void AcceptCallback(IAsyncResult ar)
        {
            Socket listener = null;

            // A new Socket to handle remote host communication 
            Socket handler = null;
            try
            {
                // Receiving byte array 
                byte[] buffer = new byte[4096];
                // Get Listening Socket object 
                listener = (Socket)ar.AsyncState;
                // Create a new socket 
                handler = listener.EndAccept(ar);

                // Using the Nagle algorithm 
                handler.NoDelay = false;

                // Creates one object array for passing data 
                object[] obj = new object[2];
                obj[0] = buffer;
                obj[1] = handler;
                while (true)
                {// Begins to asynchronously receive data 
                    handler.BeginReceive(
                        buffer,        // An array of type Byt for received data 
                    0,             // The zero-based position in the buffer  
                    buffer.Length, // The number of bytes to receive 
                    SocketFlags.None,// Specifies send and receive behaviors 
                    new AsyncCallback(ReceiveCallback),//An AsyncCallback delegate 
                    obj            // Specifies infomation for receive operation 
                    );

                    // Begins an asynchronous operation to accept an attempt 
                    AsyncCallback aCallback = new AsyncCallback(AcceptCallback);
                    listener.BeginAccept(aCallback, listener);
                }
            }
            catch (Exception exc)
            { /*MessageBox.Show(exc.ToString());*/ }
        }

        public void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                // Fetch a user-defined object that contains information 
                object[] obj = new object[2];
                obj = (object[])ar.AsyncState;

                // Received byte array 
                byte[] buffer = (byte[])obj[0];

                // A Socket to handle remote host communication. 
                handler = (Socket)obj[1];

                // Received message 
                string content = string.Empty;


                // The number of bytes received. 
                int bytesRead = handler.EndReceive(ar);

                if (bytesRead > 0)
                {
                    content += Encoding.Unicode.GetString(buffer, 0,
                        bytesRead);

                    // If message contains "<Client Quit>", finish receiving
                    if (content.IndexOf("<Client Quit>") > -1)
                    {
                        // Convert byte array to string
                        string str = content.Substring(0, content.LastIndexOf(":<Client Quit>"));
                        this.Invoke((MethodInvoker)delegate
                        {
                            // runs on UI thread                            
                            string[] msg = splitMessage(str);
                            if (msg.Length == 8)
                            {
                                
                                Realupdate(msg[0], msg[2], msg[3], msg[4], msg[5], msg[6], msg[7]);
                            }
                            else if (msg.Length == 3)
                            {
                                //MessageBox.Show("request length three!!");
                                if(msg[1]=="Topup")
                                {
                                    Clients[msg[0]].topUp(int.Parse(msg[2]));
                                    MessageBox.Show(msg[2] + " credits purchased");
                                    int cr = int.Parse(msg[2]);
                                    int cur = int.Parse(creditBox.Text);
                                    cr = cr + cur;
                                    creditBox.Text = cr.ToString();
                                }
                                else
                                {
                                    int cost = calcCreditCost(msg[2]);
                                    if (cost <= Clients[msg[0]].credits)
                                    {
                                        Clients[msg[0]].Spend(cost);
                                        req(msg[0], double.Parse(msg[2]));
                                    }
                                    else
                                        MessageBox.Show(msg[0] + " has insufficient credits for request");
                                }
                                
                            }
                            else if (msg.Length == 4)
                            {
                                //req(msg[0], double.Parse(msg[3]), double.Parse(msg[2]));
                                int cost = calcCreditCost(msg[2],msg[3]);
                                if (cost <= Clients[msg[0]].credits)
                                {
                                    Clients[msg[0]].Spend(cost);
                                    req(msg[0], double.Parse(msg[3]), double.Parse(msg[2])); }
                                else
                                    MessageBox.Show(msg[0] + " has insufficient credits for request");
                            }
                                
                        });
                    }
                    else
                    {
                        // Continues to asynchronously receive data
                        byte[] buffernew = new byte[4096];
                        obj[0] = buffernew;
                        obj[1] = handler;
                        handler.BeginReceive(buffernew, 0, buffernew.Length,
                            SocketFlags.None,
                            new AsyncCallback(ReceiveCallback), obj);
                    }
                }
            }
            catch (Exception exc)
            { MessageBox.Show(exc.ToString()); }
        }
        private string[] splitMessage(string m)
        {
            return Regex.Split(m, @":");
        }
        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        private void req(string name,double amt_gb, double cps)
        {
            double[] score = new double[Clients.Count-1];
            for (int i = 0; i < score.Length; i++)
                score[i] = 0;
            int k=0;
            string[] c = new string[Clients.Count - 1];
            foreach (string s in Clients.Keys)
            {
                if (s != name)
                    c[k++] = s;
            }
            int maxi = 0;
            double max = 0;
            for (int i = 0; i < score.Length; i++)
            {
                clients cl = Clients[c[i]];
                if (cl.memory_avail_share >= amt_gb)
                {                    
                    score[i] += (2 * (cl.memory_avail_share - amt_gb));
                }
                if (cl.cpu_avail_share >= cps)
                {

                    score[i] += (cl.cpu_avail_share - cps);
                }
                if(score[i]>max)
                {
                    max = score[i];
                    maxi = i;
                }
            }
            clients handler = Clients[c[maxi]];
            double am, ac;
            int credit;
            credit = 0;
            am = ac = 0;
            am = handler.memory_avail_share - amt_gb;
            if (am < 0)
            {
                am = 0;
                credit += Convert.ToInt32(handler.memory_avail_share / 500);
            }
            else
            {
                credit += Convert.ToInt32(amt_gb / 500);
            }
                
            
            
            ac = handler.cpu_avail_share - cps;
            if (ac < 0)
            {
                ac = 0;
                credit += Convert.ToInt32(handler.cpu_avail_share / 50);
            }
            else
            {
                credit += Convert.ToInt32(cps / 50);
            }

            handler.topUp(credit);
            MessageBox.Show("Request from "+name+" is being handled by "+handler.name);
           handler.updateFields(handler.cpu_avail.ToString() , ac.ToString(), handler.memory_avail.ToString() ,  am.ToString(), handler.storage_avail.ToString() , handler.storage_avail_share.ToString());
           Thread.Sleep(3000);
           am = ac = 0;
           am = handler.memory_avail_share + amt_gb;
           if (am < 0)
               am = 0;
           ac = handler.cpu_avail_share + cps;
           if (ac < 0)
               ac = 0;
           MessageBox.Show("request from " + name + " completed by " + handler.name);
           handler.updateFields(handler.cpu_avail.ToString(), ac.ToString(), handler.memory_avail.ToString(), am.ToString(), handler.storage_avail.ToString(), handler.storage_avail_share.ToString());
        
        }
        private int calcCreditCost(string cp,string mem)
        {
            double c, m;
            c = double.Parse(cp);
            m = double.Parse(mem);
            double val = c / 10 + m / 100;
            return Convert.ToInt32(val);
        }
        private int calcCreditCost(string cp)
        {
            double c, m;
            c = double.Parse(cp);
            //m = double.Parse(mem);
            double val = c / 100; 
            return Convert.ToInt32(val);
        }
        private void req(string name, double amt_storage)
        {
            double[] score = new double[Clients.Count - 1];
            for (int i = 0; i < score.Length; i++)
                score[i] = 0;
            int k = 0;
            string[] c = new string[Clients.Count - 1];
            foreach (string s in Clients.Keys)
            {
                if(s!=name)
                    c[k++] = s;
            }
            int maxi = 0;
            double max = 0;
            for (int i = 0; i < score.Length; i++)
            {
                clients cl = Clients[c[i]];
                if (cl.storage_avail_share >= amt_storage)
                {

                    score[i] += (cl.storage_avail_share - amt_storage);
                }
                if (score[i] > max)
                {
                    max = score[i];
                    maxi = i;
                }
            }
            clients handler = Clients[c[maxi]];
            double  ss;
            ss=0;
            int credit = 0;
            ss = handler.memory_avail_share - amt_storage;
            if (ss < 0)
            {
                credit += Convert.ToInt32(handler.memory_avail_share / 500);
                ss = 0;
            }
            else
            {
                credit += Convert.ToInt32(amt_storage / 500);
            }
            handler.topUp(credit);    
            MessageBox.Show("Request from " + name + " is being handled by " + handler.name,"Resources Found",MessageBoxButtons.OK,MessageBoxIcon.Information);
            handler.updateFields(handler.cpu_avail.ToString(), handler.cpu_avail_share.ToString(), handler.memory_avail.ToString(), handler.memory_avail_share.ToString(), handler.storage_avail.ToString(), ss.ToString());
            Thread.Sleep(5000);
            ss = handler.memory_avail_share + amt_storage;
            if (ss < 0)
                ss = 0;
            MessageBox.Show("Request from " + name + " has been completed by " + handler.name,"Trade Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
            handler.updateFields(handler.cpu_avail.ToString(), handler.cpu_avail_share.ToString(), handler.memory_avail.ToString(), handler.memory_avail_share.ToString(), handler.storage_avail.ToString(), ss.ToString());
           
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }
       
        
    }
}
