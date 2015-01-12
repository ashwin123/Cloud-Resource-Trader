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
            update();
        }
        public static void update()
        {
            foreach(var client in Clients.Values)
            {
                
                
               client.updateFields("10","2","500","210","4","2");
            }
            //MessageBox.Show(client1.cpu.Text);
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
            //System.Windows.Forms.Timer test = new System.Windows.Forms.Timer();
            //test.Interval = 1000;
            //test.Tick += new EventHandler(test1);
            //test.Start();
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
            { MessageBox.Show(exc.ToString()); }
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
                            //c1_cpu.Text = str; // runs on UI thread
                            //MessageBox.Show(str);
                            string[] msg = splitMessage(str);
                            int c = 0;
                            /*while(c!=2)
                            {
                                foreach (string s in msg)
                                    Console.WriteLine(s);
                                c++;
                            }*/
                            Console.WriteLine(msg.Length);
                            if (msg.Length == 8)
                            {
                                //MessageBox.Show(str);
                                Realupdate(msg[0], msg[2], msg[3], msg[4], msg[5], msg[6], msg[7]);
                            }
                            else if (msg.Length == 3)
                            {
                                req(msg[0], double.Parse(msg[2]));
                            }
                            else if (msg.Length == 4)
                            {
                                req(msg[0], double.Parse(msg[3]), double.Parse(msg[2]));
                            }
                                
                        });
                    }
                    else
                    {
                        // Continues to asynchronously receive data
                        byte[] buffernew = new byte[1024];
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
            am = ac = 0;
            am = handler.memory_avail_share - amt_gb;
            if (am < 0)
                am = 0;
            ac = handler.cpu_avail_share - cps;
            if (ac < 0)
                ac = 0;
            MessageBox.Show("request from "+name+" is handled by "+handler.name);
           handler.updateFields(handler.cpu_avail.ToString() , ac.ToString(), handler.memory_avail.ToString() ,  am.ToString(), handler.storage_avail.ToString() , handler.storage_avail_share.ToString());
           Thread.Sleep(5000);
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
            ss = handler.memory_avail_share - amt_storage;
            if (ss < 0)
                ss = 0;
            MessageBox.Show("request from " + name + " is handled by " + handler.name);
            handler.updateFields(handler.cpu_avail.ToString(), handler.cpu_avail_share.ToString(), handler.memory_avail.ToString(), handler.memory_avail_share.ToString(), handler.storage_avail.ToString(), ss.ToString());
            Thread.Sleep(5000);
            ss = handler.memory_avail_share + amt_storage;
            if (ss < 0)
                ss = 0;
            MessageBox.Show("request from " + name + " completed by " + handler.name);
            handler.updateFields(handler.cpu_avail.ToString(), handler.cpu_avail_share.ToString(), handler.memory_avail.ToString(), handler.memory_avail_share.ToString(), handler.storage_avail.ToString(), ss.ToString());
           
        }
       
        
    }
}
