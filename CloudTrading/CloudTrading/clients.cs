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
using System.Windows.Forms;

namespace CloudTrading
{
    public class clients
    {
        public string name;
        public double cpu_avail=1.0;
        public double storage_avail = 1.0;
        public double memory_avail = 1.0;
        public double cpu_avail_share = 0.0;
        public double storage_avail_share = 0.0;
        public double memory_avail_share = 0.0;
        public int credits;
        public TextBox cpu;
        public TextBox mem;
        public TextBox storage;
        public ProgressBar cpu_p;
        public ProgressBar mem_p;
        public ProgressBar storage_p;
        public clients(string n, TextBox c, TextBox m, TextBox s, ProgressBar cp, ProgressBar mp, ProgressBar sp)
        {
            name = n;
            cpu = c;
            mem = m;
            storage = s;
            cpu_p = cp;
            mem_p = mp;
            storage_p = sp;
        }
        public void updateFields(string c,string ca,string m,string ma,string s,string sa)
        {
            //bool convert;
            try
            {
                if (c != "")
                {
                    cpu.Text = c;
                    cpu_avail = double.Parse(c);
                    cpu_avail_share = double.Parse(ca);
                    double ratio = cpu_avail_share / cpu_avail;
                    if (ratio < 0.25)
                    {
                        cpu_p.BackColor = System.Drawing.Color.Red;
                        cpu_p.ForeColor = System.Drawing.Color.Red;
                        cpu_p.Value = (int)(ratio * 100);
                    }
                    else if (ratio >= 0.25 && ratio < 0.5)
                    {
                        cpu_p.BackColor = System.Drawing.Color.Yellow;
                        cpu_p.Value = (int)(ratio * 100);
                    }
                    else
                    {
                        cpu_p.BackColor = System.Drawing.Color.Green;
                        cpu_p.Value = (int)(ratio * 100);
                    }

                }
                if (m != "")
                {
                    mem.Text = m;
                    memory_avail = double.Parse(m);
                    memory_avail_share = double.Parse(ma);
                    double ratio = memory_avail_share / memory_avail;
                    if (ratio < 0.25)
                    {
                        mem_p.BackColor = System.Drawing.Color.Red;
                        mem_p.Value = (int)(ratio * 100);
                    }
                    else if (ratio >= 0.25 && ratio < 0.5)
                    {
                        mem_p.BackColor = System.Drawing.Color.Yellow;
                        mem_p.Value = (int)(ratio * 100);
                    }
                    else
                    {
                        mem_p.BackColor = System.Drawing.Color.Green;
                        mem_p.Value = (int)(ratio * 100);
                    }

                }
                if (s != "")
                {
                    storage.Text = s;
                    storage_avail = double.Parse(s);
                    storage_avail_share = double.Parse(sa);
                    double ratio = storage_avail_share / storage_avail;
                    if (ratio < 0.25)
                    {
                        storage_p.BackColor = System.Drawing.Color.Red;
                        storage_p.Value = (int)(ratio * 100);
                    }
                    else if (ratio >= 0.25 && ratio < 0.5)
                    {
                        storage_p.BackColor = System.Drawing.Color.Yellow;
                        storage_p.Value = (int)(ratio * 100);
                    }
                    else
                    {
                        storage_p.BackColor = System.Drawing.Color.Green;
                        storage_p.Value = (int)(ratio * 100);
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
