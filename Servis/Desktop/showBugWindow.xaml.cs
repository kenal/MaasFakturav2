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
    /// Interaction logic for showBugWindow.xaml
    /// </summary>
    public partial class showBugWindow : Window
    {
        public showBugWindow()
        {
            InitializeComponent();
            this.DataContext = new AdminWindowViewModel();
        }

        #region Screen Resolution
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            gridsResolution();
        }
        public void gridsResolution()
        {
            int brKolona01 = datagrid1.Columns.Count;

            #region resolution full
            if (this.WindowState == WindowState.Maximized)
            {
                //var windowWidth = System.Windows.SystemParameters.PrimaryScreenWidth - 43;
                var windowWidth2 = System.Windows.SystemParameters.PrimaryScreenWidth - 325;
                var windowWidth3 = System.Windows.SystemParameters.PrimaryScreenWidth + 1157;
                //datagrid 01
                col1_1.Width = windowWidth2 / brKolona01;
                col1_2.Width = windowWidth2 / brKolona01;
                col1_3.Width = windowWidth3 / brKolona01;
                col1_4.Width = windowWidth2 / brKolona01;
                col1_5.Width = windowWidth2 / brKolona01;
            }
            #endregion
            #region resolution normal
            else
            {
                var windowWidth2 = this.Width - 345;
                var windowWidth3 = this.Width + 1157;
                //datagrid 01
                col1_1.Width = windowWidth2 / brKolona01;
                col1_2.Width = windowWidth2 / brKolona01;
                col1_3.Width = windowWidth3 / brKolona01;
                col1_4.Width = windowWidth2 / brKolona01;
                col1_5.Width = windowWidth2 / brKolona01;
            }
            #endregion
        }
        #endregion
    }
}
