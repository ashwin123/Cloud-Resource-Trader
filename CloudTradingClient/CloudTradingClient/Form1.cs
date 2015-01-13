using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;

namespace CloudTradingClient
{
    public partial class Form1 : Form
    {
        public static IPHostEntry ipHost = Dns.GetHostEntry("");
        public static IPAddress ipAddr = ipHost.AddressList[0];
        public static IPEndPoint ipe = new IPEndPoint(ipAddr, 2015);
        public static Socket tempSocket = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        static System.Windows.Forms.Timer t = new System.Windows.Forms.Timer();
        Random r = new Random();
        public static int ID, tot_cpu, tot_mem, tot_stor;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                tempSocket.Connect(ipe);
                if (tempSocket.Connected)
                    MessageBox.Show("Connected to Cloud Trading Service!", "Successful Conenction",MessageBoxButtons.OK,MessageBoxIcon.Information);
                getUsageStats();
            }
            catch(Exception exp)
            { MessageBox.Show(exp.Message); }
        
        }
        private void Send(object sender, EventArgs e)
        {
            try
            {
                // Sending message 
                //<Client Quit> is the sign for end of data 
                if (tb_cpu.Text == "" || memBox.Text == "")
                    MessageBox.Show("Set both CPU and memory","Invalid Resource Request",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                else
                {   //ex request - Client 1:Request:20:200
                    string theMessageToSend = "client" + ID + ":Request:" + tb_cpu.Text + ":" + memBox.Text;
                    byte[] msg = Encoding.Unicode.GetBytes(theMessageToSend + ":<Client Quit>");

                    // Sends data to a connected Socket. 
                    int bytesSend = tempSocket.Send(msg);
                }
                
            }
            catch (Exception exc)
            { MessageBox.Show(exc.ToString()); }
        }

        public void getUsageStats()
        {
            t.Interval =15000;
            t.Start();
            t.Tick += new EventHandler(GetUpdate); //after evert t.Interval ms, GetUpdate is called

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {   //ex-req Client 1:Topup:5000
                string theMessageToSend = "client" + ID + ":Topup:" + top_up_tb.Text;
                byte[] msg = Encoding.Unicode.GetBytes(theMessageToSend + ":<Client Quit>");
                // Sends data to a connected Socket. 
                int bytesSend = tempSocket.Send(msg);
            }
            catch (Exception exc)
            { MessageBox.Show(exc.ToString()); }
        }

        private void SendStorage(object sender, EventArgs e)
        {
            try
            {   //ex-req Client 1:Request:5000
                string theMessageToSend = "client" + ID +":Request:" + stor.Text;
                byte[] msg = Encoding.Unicode.GetBytes(theMessageToSend + ":<Client Quit>");
                // Sends data to a connected Socket. 
                int bytesSend = tempSocket.Send(msg);
            }
            catch (Exception exc)
            { MessageBox.Show(exc.ToString()); }
        }

        public void GetUpdate(Object o, EventArgs e)
        {            
            int cpu_avail = r.Next(Convert.ToInt32(0.3*tot_cpu),tot_cpu);
            int mem_avail = r.Next(Convert.ToInt32(0.3 * tot_mem), tot_mem);
            int stor_avail = r.Next(Convert.ToInt32(0.3 * tot_stor), tot_stor);
            this.Invoke(new MethodInvoker(delegate          // delegate to update
            {
                //ex-request Client 1:Update:1000:200:500:20:5000:2500
                string theMessageToSend = "client" + ID + ":Update:" + tot_cpu + ":" +  cpu_avail + ":" + tot_mem + ":" + mem_avail + ":" + tot_stor + ":" + stor_avail;
                byte[] msg = Encoding.Unicode.GetBytes(theMessageToSend + ":<Client Quit>");


                // Sends data to a connected Socket. 
                int bytesSend = tempSocket.Send(msg);
            }));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // based on ID, set max values of resources for each client
            ID = clid.SelectedIndex + 1;
            if(ID == 1)
            {
                tot_cpu = 500;
                tot_mem = 1000;
                tot_stor = 5000;
            }
            if(ID == 2)
            {
                tot_cpu = 700;
                tot_mem = 2000;
                tot_stor = 7000;
            }
            if(ID == 3)
            {
                tot_cpu = 600;
                tot_mem = 3000;
                tot_stor = 6000;
            }
            tb_cpu.Text = tot_cpu.ToString();
            tb_mem.Text = tot_mem.ToString();
            tb_stor.Text = tot_stor.ToString();
        }
       
        

    }
}
