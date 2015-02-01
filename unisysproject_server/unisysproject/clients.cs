using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace unisysproject
{
    
    //public static class ModifyProgressBarColor
    //{
    //    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = false)]
    //    static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr w, IntPtr l);
    //    public static void SetState(ProgressBar pBar, int state)
    //    {
    //        //SendMessage(pBar.Handle, 1040, (IntPtr)state, IntPtr.Zero);
    //    }
    //}
    public class clients
    {
        public string name;
        public double cpu_avail=1.0;
        public double storage_avail = 1.0;
        public double memory_avail = 1.0;
        public double cpu_avail_share = 0.0;
        public double storage_avail_share = 0.0;
        public double memory_avail_share = 0.0;
        public int credits = 0;
        public Label cpu;
        public Label mem;
        public Label storage;
        public ProgressBar cpu_p;
        public ProgressBar mem_p;
        public ProgressBar storage_p;
        public clients(string n, Label c, Label m, Label s, ProgressBar cp, ProgressBar mp, ProgressBar sp)
        {
            name = n;
            cpu = c;
            mem = m;
            storage = s;
            cpu_p = cp;
            mem_p = mp;
            storage_p = sp;
            credits = 200;
        }
        public void topUp(int i)
        {
            credits = credits + i;
        }
        public void Spend(int i)
        {
            credits = credits - i;
        }
        public void updateFields(string c,string ca,string m,string ma,string s,string sa)
        {
            //bool convert;
            try
            {
                if (c != "")
                {
                    cpu.Content = ca+"/"+c;
                    cpu_avail = double.Parse(c);
                    cpu_avail_share = double.Parse(ca);
                    double ratio = cpu_avail_share / cpu_avail;
                    if (ratio < 0.25)
                    {
                        cpu_p.Foreground= Brushes.Red;
                        cpu_p.Value = (int)(ratio * 100);
                        //ModifyProgressBarColor.SetState(cpu_p, 2);
                        
                    }
                    else if (ratio >= 0.25 && ratio < 0.5)
                    {
                        cpu_p.Foreground = Brushes.Yellow;
                        cpu_p.Value = (int)(ratio * 100);
                        //ModifyProgressBarColor.SetState(cpu_p, 3);
                    }
                    else
                    {                        
                        cpu_p.Foreground = Brushes.Green;
                        cpu_p.Value = (int)(ratio * 100);
                        //ModifyProgressBarColor.SetState(cpu_p, 1);
                    }

                }
                if (m != "")
                {
                    mem.Content = ma+"/"+m;
                    memory_avail = double.Parse(m);
                    memory_avail_share = double.Parse(ma);
                    double ratio = memory_avail_share / memory_avail;
                    if (ratio < 0.25)
                    {
                        mem_p.Foreground = Brushes.Red;
                        mem_p.Value = (int)(ratio * 100);
                        //ModifyProgressBarColor.SetState(mem_p, 2);
                    }
                    else if (ratio >= 0.25 && ratio < 0.5)
                    {
                        mem_p.Foreground = Brushes.Yellow;
                        mem_p.Value = (int)(ratio * 100);
                        //ModifyProgressBarColor.SetState(mem_p, 3);
                    }
                    else
                    {
                        mem_p.Foreground = Brushes.Green;
                        mem_p.Value = (int)(ratio * 100);
                        //ModifyProgressBarColor.SetState(mem_p, 1);
                    }

                }
                if (s != "")
                {
                    storage.Content = sa+"/"+s;
                    storage_avail = double.Parse(s);
                    storage_avail_share = double.Parse(sa);
                    double ratio = storage_avail_share / storage_avail;
                    if (ratio < 0.25)
                    {
                        storage_p.Foreground = Brushes.Red;
                        storage_p.Value = (int)(ratio * 100);
                        //ModifyProgressBarColor.SetState(storage_p, 2);
                    }
                    else if (ratio >= 0.25 && ratio < 0.5)
                    {
                        storage_p.Foreground = Brushes.Yellow;
                        storage_p.Value = (int)(ratio * 100);
                        //ModifyProgressBarColor.SetState(storage_p, 3);
                    }
                    else
                    {
                        storage_p.Foreground = Brushes.Green;
                        storage_p.Value = (int)(ratio * 100);
                        //ModifyProgressBarColor.SetState(storage_p, 1);
                    }
                }
            }
            catch (System.Exception e)
            {

                MessageBox.Show(e.Message);
                //throw;
            }
        }

    }
    


}
