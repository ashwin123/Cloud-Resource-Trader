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

namespace unisysproject
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Page
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void policy_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("Window3.xaml", UriKind.Relative));
        }

        private void auth_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("clientloginform.xaml", UriKind.Relative));
        }

        private void share_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("records.xaml", UriKind.Relative));
        }
    }
}
