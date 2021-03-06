﻿using Desktop.ViewModel;
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

namespace Desktop
{
    /// <summary>
    /// Interaction logic for AdminEditWindow.xaml
    /// </summary>
    public partial class AdminEditWindow : Window
    {
            AdminWindowViewModel m = new AdminWindowViewModel();

         public AdminEditWindow(AdminWindowViewModel m)
        {
            InitializeComponent();
            this.m = m;
            this.DataContext = m;
            m.CloseAction = null;
            if (m.CloseAction == null)
            {
                m.CloseAction = new Action(() => this.Close());
            }
        }

         private void Button_Click(object sender, RoutedEventArgs e)
         {
             this.Close();
         }

         
    }
}
