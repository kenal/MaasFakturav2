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
    /// Interaction logic for RechBaustellen.xaml
    /// </summary>
    public partial class RechBaustellen : Window
    {
        public RechBaustellen()
        {
            InitializeComponent();
        }

        private void btnKartei_Click(object sender, RoutedEventArgs e)
        {
            grdKartei.Visibility = Visibility.Visible;
            grdListe.Visibility = Visibility.Collapsed;
        }

        private void btnListe_Click(object sender, RoutedEventArgs e)
        {
            grdListe.Visibility = Visibility.Visible;
            grdKartei.Visibility = Visibility.Hidden;
        }

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
                var windowWidth = System.Windows.SystemParameters.PrimaryScreenWidth - 20;
                //datagrid 01
                col1_1.Width = windowWidth / brKolona01;
                col1_2.Width = windowWidth / brKolona01;
                col1_3.Width = windowWidth / brKolona01;
                col1_4.Width = windowWidth / brKolona01;
                col1_5.Width = windowWidth / brKolona01;
                col1_6.Width = windowWidth / brKolona01;
                col1_7.Width = windowWidth / brKolona01;
            }
            #endregion
            #region resolution normal
            else
            {
                var windowWidth = this.Width - 20;
                //datagrid 01
                col1_1.Width = windowWidth / brKolona01;
                col1_2.Width = windowWidth / brKolona01;
                col1_3.Width = windowWidth / brKolona01;
                col1_4.Width = windowWidth / brKolona01;
                col1_5.Width = windowWidth / brKolona01;
                col1_6.Width = windowWidth / brKolona01;
                col1_7.Width = windowWidth / brKolona01;
            }
            #endregion
        }
    }
}
