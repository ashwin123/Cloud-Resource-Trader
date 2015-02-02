using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Sockets;
using System.Windows.Threading;
using System.IO;
using System.Diagnostics;
using System.Management;

namespace unisysproject
{
    /// <summary>
    /// Interaction logic for SharingPage.xaml
    /// </summary>
    public partial class SharingPage : Page
    {
        public static String ID;
        public static double tot_cpu, tot_mem, tot_stor, cpu_avail, mem_avail, stor_avail;
        public static IPHostEntry ipHost = Dns.GetHostEntry(Dns.GetHostName());
        public static IPAddress ipAddr = ipHost.AddressList[0];
        public static IPEndPoint ipe = new IPEndPoint(ipAddr, 2015);
        public static Socket tempSocket = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        public static DispatcherTimer dispatcherTimer = new DispatcherTimer();
       // public static Random r = new Random();
        public SharingPage(String id)
        {
            InitializeComponent();
            ID = id;
            //getUsageStats();
        }
        /*public SharingPage(String id)
        {
            ID = id;
        }*/

        public void getUsageStats()
        {
            
            DispatcherTimer dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(GetUpdate);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 3); //Timespan(hrs,min,sec)
            dispatcherTimer.Start(); //after evert t.Interval (3) s, GetUpdate is called  
        }

        public void GetUpdate(Object o, EventArgs e)
        {

            ManagementObject processor = new ManagementObject("Win32_PerfFormattedData_PerfOS_Processor.Name='_Total'");
            processor.Get();
            tot_cpu = 100;
            if (ID == "1")
                tot_mem = 4096;
            else if(ID == "3")
                tot_mem = 6144;
            else
                tot_mem = 8192;
            cpu_avail = 100 - double.Parse(processor.Properties["PercentProcessorTime"].Value.ToString());
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            stor_avail = 0;
            tot_stor = 0;
            foreach(DriveInfo d in allDrives)
            {
                if (d.IsReady == true)
                {
                    stor_avail += d.TotalFreeSpace;
                    tot_stor += d.TotalSize;
                }
                
            }
            tot_stor /= 1024;
            stor_avail /= 1024;
            PerformanceCounter pCntr = new PerformanceCounter("Memory", "Available MBytes");
            mem_avail = (double)pCntr.NextValue();
           // int cpu_avail = r.Next(Convert.ToInt32(0.1 * tot_cpu), tot_cpu);
            //int mem_avail = r.Next(Convert.ToInt32(0.1 * 1500), 1500);
          //  int stor_avail = r.Next(Convert.ToInt32(0.1 * tot_stor), tot_stor);
            Dispatcher.Invoke((Action)delegate()        // delegate to update
            {
                //ex-request Client 1:Update:1000:200:500:20:5000:2500
                string theMessageToSend = "client" + ID + ":Update:" + tot_cpu + ":" + cpu_avail + ":" + tot_mem + ":" + mem_avail + ":" + tot_stor + ":" + stor_avail;
                byte[] msg = Encoding.Unicode.GetBytes(theMessageToSend + ":<Client Quit>");


                // Sends data to a connected Socket. 
                int bytesSend = tempSocket.Send(msg);
            });
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                tempSocket.Connect(ipe);
                if (tempSocket.Connected)
                    MessageBox.Show("Connected to Hub!");
                getUsageStats();
            }
            catch (Exception exp)
            { MessageBox.Show(exp.Message); }
        }

        private void send_stor_Click(object sender, RoutedEventArgs e)
        {
            try
            {   //ex-req Client 1:Request:5000
                string theMessageToSend = "Client " + ID + ":Request:" + t_stor.Text;
                byte[] msg = Encoding.Unicode.GetBytes(theMessageToSend + ":<Client Quit>");


                // Sends data to a connected Socket. 
                int bytesSend = tempSocket.Send(msg);
            }
            catch (Exception exc)
            { MessageBox.Show(exc.ToString()); }
        }

        private void top_up_Click(object sender, RoutedEventArgs e)
        {
            try
            {   //ex-req Client 1:Topup:5000
                string theMessageToSend = "client" + ID + ":Topup:" + t_top.Text;
                byte[] msg = Encoding.Unicode.GetBytes(theMessageToSend + ":<Client Quit>");
                // Sends data to a connected Socket. 
                int bytesSend = tempSocket.Send(msg);
            }
            catch (Exception exc)
            { MessageBox.Show(exc.ToString()); }
        }

        private void send_mem_cpu_Click(object sender, RoutedEventArgs e)
        {
             try
            {
                // Sending message 
                //<Client Quit> is the sign for end of data 
                if (t_cpu.Text == "" || t_mem.Text == "")
                    MessageBox.Show("Set both CPU and memory","Invalid Resource Request");
                else
                {   //ex request - Client 1:Request:20:200
                    string theMessageToSend = "client" + ID + ":Request:" + t_cpu.Text + ":" + t_mem.Text;
                    byte[] msg = Encoding.Unicode.GetBytes(theMessageToSend + ":<Client Quit>");

                    // Sends data to a connected Socket. 
                    int bytesSend = tempSocket.Send(msg);
                }
                
            }
            catch (Exception exc)
            { MessageBox.Show(exc.ToString()); }
        }
        
    }
}

