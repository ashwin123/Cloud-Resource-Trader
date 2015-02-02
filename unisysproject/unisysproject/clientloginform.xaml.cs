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
using System.Windows.Shapes;
using System.IO;

namespace unisysproject
{
    /// <summary>
    /// Interaction logic for clientloginform.xaml
    /// </summary>
    public partial class clientloginform : Page
    {
        public clientloginform()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String user, passwd, id;
            user = u_txt.Text;
            passwd = p_txt.Password;
            
            Dictionary<string, String[]> auth = new Dictionary<string, String[]>();


           // MessageBox.Show(user + passwd);
            try
            {
                using (StreamReader sr = new StreamReader("auth.txt"))
                {
                    String[] lines = sr.ReadToEnd().Split('\n');
                    foreach (String s in lines)
                        auth.Add(s.Split()[0],s.Split());
                      //  Console.WriteLine(s);
                    
                    
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(exc.Message);
            }
           /* foreach (KeyValuePair<string, String[]> kvp in auth)
            {
                Console.WriteLine("Key = {0}, Value = {1}",
                    kvp.Key, kvp.Value);
            }*/
            if (!auth.ContainsKey(user))
                MessageBox.Show("User not present!");
            foreach (String s in auth.Keys)
            {
               if(s.Equals(user))
               {
                   if (auth[s][1].Equals(passwd))
                   {
                       id = auth[s][2];
                       Console.WriteLine("id : " + id);
                       this.NavigationService.Navigate(new SharingPage(id));
                      // break;
                   }
                   else
                       MessageBox.Show("Incorrect password!");
               }
            }
            


                
        }
    }
}
