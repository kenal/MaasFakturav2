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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for PoslanePorukeUserControl.xaml
    /// </summary>
    
    
    public partial class PoslanePorukeUserControl : UserControl
    {
        PorukeWindowViewModel pwvm = new PorukeWindowViewModel();
        public PoslanePorukeUserControl()
        {
            InitializeComponent();
            this.DataContext = new PorukeWindowViewModel();
        }

        public PoslanePorukeUserControl(PorukeWindowViewModel pw)
        {
            InitializeComponent();
            this.pwvm = pw;
            this.DataContext = pw;
            
        }
    }
}
