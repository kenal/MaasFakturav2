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
    /// Interaction logic for PrimljenePorukeUserControl.xaml
    /// </summary>
    public partial class PrimljenePorukeUserControl : UserControl
    {
        PorukeWindowViewModel pwvm = new PorukeWindowViewModel();
        public PrimljenePorukeUserControl()
        {
            InitializeComponent();
            this.DataContext = new PorukeWindowViewModel();
        }

        public PrimljenePorukeUserControl(PorukeWindowViewModel pw)
        {
            InitializeComponent();
            this.pwvm = pw;
            this.DataContext = pw;
        }
    }
}
