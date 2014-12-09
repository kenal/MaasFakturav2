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
    /// Interaction logic for PorukeWidnow.xaml
    /// </summary>
    public partial class PorukeWindow : Window
    {
        PorukeWindowViewModel viewModel = new PorukeWindowViewModel();

        public PorukeWindowViewModel ViewModel
        {
            get { return viewModel; }
            set { viewModel = value; }
        }

        public PorukeWindow()
        {
            InitializeComponent();
            this.DataContext = viewModel;
            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            PoslanePorukeUserControl ppuc = new PoslanePorukeUserControl(viewModel);
            root.Child = null;
            root.Child = ppuc;
            visak.Visibility = Visibility.Visible;
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            PrimljenePorukeUserControl primljenePor = new PrimljenePorukeUserControl(viewModel);
            root.Child = null;
            root.Child = primljenePor;
            visak.Visibility = Visibility.Visible;
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            NovaPorukaUserControl npuc = new NovaPorukaUserControl();
            root.Child = null;
            root.Child = npuc;
            visak.Visibility = Visibility.Collapsed;
        }

        
    }
}
