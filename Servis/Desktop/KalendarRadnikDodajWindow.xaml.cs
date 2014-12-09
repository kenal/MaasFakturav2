using Desktop.ViewModel;
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
    /// Interaction logic for KalendarRadnikDodajWindow.xaml
    /// </summary>
    public partial class KalendarRadnikDodajWindow : Window
    {
        KalendarRadnikWindowViewModel krwv = new KalendarRadnikWindowViewModel();
        public KalendarRadnikDodajWindow()
        {
            InitializeComponent();
        }

        public KalendarRadnikDodajWindow(KalendarRadnikWindowViewModel krwv)
        {
            InitializeComponent();
            this.krwv = krwv;
            this.DataContext = krwv;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
            
        }

        
    }
}
