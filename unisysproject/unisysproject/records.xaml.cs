﻿using System;
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
    /// Interaction logic for records.xaml
    /// </summary>
    public partial class records : Page
    {
        String id;
        public records(String id)
        {
            InitializeComponent();
            this.id = id;
            Console.Write("id here : " + id);
        }
    }
}
