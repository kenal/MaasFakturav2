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
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        public AdminWindow()
        {
            InitializeComponent();
            this.DataContext = new AdminWindowViewModel();
        }

        #region Button Events
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Tab "New"
            grdNew.Visibility = Visibility.Visible;
            grdBen.Visibility = System.Windows.Visibility.Collapsed;
            grdMit.Visibility = System.Windows.Visibility.Collapsed;
            grdStat.Visibility = System.Windows.Visibility.Collapsed;
            grdAngAuf.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Tab "Benutzer"
            grdBen.Visibility = Visibility.Visible;
            grdNew.Visibility = System.Windows.Visibility.Collapsed;
            grdMit.Visibility = System.Windows.Visibility.Collapsed;
            grdStat.Visibility = System.Windows.Visibility.Collapsed;
            grdAngAuf.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Tab "Mit.Kalendar"
            grdMit.Visibility = Visibility.Visible;
            grdBen.Visibility = System.Windows.Visibility.Collapsed;
            grdNew.Visibility = System.Windows.Visibility.Collapsed;
            grdStat.Visibility = System.Windows.Visibility.Collapsed;
            grdAngAuf.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //Tab "Statistik"
            grdStat.Visibility = Visibility.Visible;
            grdBen.Visibility = System.Windows.Visibility.Collapsed;
            grdNew.Visibility = System.Windows.Visibility.Collapsed;
            grdMit.Visibility = System.Windows.Visibility.Collapsed;
            grdAngAuf.Visibility = System.Windows.Visibility.Collapsed;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //Tab "Statistik"
            grdAngAuf.Visibility = Visibility.Visible;
            grdBen.Visibility = System.Windows.Visibility.Collapsed;
            grdNew.Visibility = System.Windows.Visibility.Collapsed;
            grdMit.Visibility = System.Windows.Visibility.Collapsed;
            grdStat.Visibility = System.Windows.Visibility.Collapsed;
        }
        #endregion

        #region Screen Resolution
        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            gridsResolution();
        }
        public void gridsResolution()
        {
            int brKolona01 = datagrid1.Columns.Count;
            int brKolona02 = datagrid2.Columns.Count;
            int brKolona03 = datagrid3.Columns.Count;
            int brKolona04 = datagrid4.Columns.Count;
            /*int brKolona05 = datagrid5.Columns.Count;*/

            #region resolution full
            if (this.WindowState == WindowState.Maximized)
            {
                var windowWidth = System.Windows.SystemParameters.PrimaryScreenWidth - 30;
                //datagrid 01
                col1_1.Width = windowWidth / brKolona01;
                col1_2.Width = windowWidth / brKolona01;
                //col1_3.Width = windowWidth / brKolona01;
                col1_4.Width = windowWidth / brKolona01;
                col1_5.Width = windowWidth / brKolona01;
                col1_6.Width = windowWidth / brKolona01;
                col1_7.Width = windowWidth / brKolona01;
                col1_8.Width = windowWidth / brKolona01;
                col1_9.Width = windowWidth / brKolona01;
                col1_10.Width = windowWidth / brKolona01;
                col1_11.Width = windowWidth / brKolona01;
                //datagrid02
                col2_1.Width = windowWidth / brKolona02;
                col2_2.Width = windowWidth / brKolona02;
                col2_3.Width = windowWidth / brKolona02;
                col2_4.Width = windowWidth / brKolona02;
                col2_5.Width = windowWidth / brKolona02;
                col2_6.Width = windowWidth / brKolona02;
                //datagrid03
                col3_1.Width = windowWidth / brKolona03;
                col3_2.Width = windowWidth / brKolona03;
                col3_3.Width = windowWidth / brKolona03;
                col3_4.Width = windowWidth / brKolona03;
                col3_5.Width = windowWidth / brKolona03;
                //datagrid04
                col4_1.Width = windowWidth / brKolona04;
                col4_2.Width = windowWidth / brKolona04;
                col4_3.Width = windowWidth / brKolona04;
                col4_4.Width = windowWidth / brKolona04;
                col4_5.Width = windowWidth / brKolona04;
                col4_6.Width = windowWidth / brKolona04;
                col4_7.Width = windowWidth / brKolona04;
                col4_8.Width = windowWidth / brKolona04;
                col4_9.Width = windowWidth / brKolona04;
                col4_10.Width = windowWidth / brKolona04;
                col4_11.Width = windowWidth / brKolona04;
                col4_12.Width = windowWidth / brKolona04;
                //datagrid05
                /*col5_1.Width = windowWidth / brKolona05;
                col5_2.Width = windowWidth / brKolona05;
                col5_3.Width = windowWidth / brKolona05;
                col5_4.Width = windowWidth / brKolona05;
                col5_5.Width = windowWidth / brKolona05;
                col5_6.Width = windowWidth / brKolona05;
                col5_7.Width = windowWidth / brKolona05;
                col5_8.Width = windowWidth / brKolona05;
                col5_9.Width = windowWidth / brKolona05;
                col5_10.Width = windowWidth / brKolona05;
                col5_11.Width = windowWidth / brKolona05;
                col5_12.Width = windowWidth / brKolona05;*/
            }
            #endregion
            #region resolution normal
            else
            {
                var windowWidth = this.Width - 45;
                var windowsBenutzer01 = this.Width - 93;
                var windowsBenutzer02 = this.Width + 390;
                //datagrid 01
                col1_1.Width = windowsBenutzer01 / brKolona01;
                col1_2.Width = windowsBenutzer01 / brKolona01;
                //col1_3.Width = windowWidth / brKolona01;
                col1_4.Width = windowsBenutzer01 / brKolona01;
                col1_5.Width = windowsBenutzer01 / brKolona01;
                col1_6.Width = windowsBenutzer01 / brKolona01;
                col1_7.Width = windowsBenutzer01 / brKolona01;
                col1_8.Width = windowsBenutzer01 / brKolona01;
                col1_9.Width = windowsBenutzer01 / brKolona01;
                col1_10.Width = windowsBenutzer01 / brKolona01;
                col1_11.Width = windowsBenutzer02 / brKolona01;
                //datagrid02
                col2_1.Width = windowWidth / brKolona02;
                col2_2.Width = windowWidth / brKolona02;
                col2_3.Width = windowWidth / brKolona02;
                col2_4.Width = windowWidth / brKolona02;
                col2_5.Width = windowWidth / brKolona02;
                col2_6.Width = windowWidth / brKolona02;
                //datagrid03
                col3_1.Width = windowWidth / brKolona03;
                col3_2.Width = windowWidth / brKolona03;
                col3_3.Width = windowWidth / brKolona03;
                col3_4.Width = windowWidth / brKolona03;
                col3_5.Width = windowWidth / brKolona03;
                //datagrid04
                col4_1.Width = windowWidth / brKolona04;
                col4_2.Width = windowWidth / brKolona04;
                col4_3.Width = windowWidth / brKolona04;
                col4_4.Width = windowWidth / brKolona04;
                col4_5.Width = windowWidth / brKolona04;
                col4_6.Width = windowWidth / brKolona04;
                col4_7.Width = windowWidth / brKolona04;
                col4_8.Width = windowWidth / brKolona04;
                col4_9.Width = windowWidth / brKolona04;
                col4_10.Width = windowWidth / brKolona04;
                col4_11.Width = windowWidth / brKolona04;
                col4_12.Width = windowWidth / brKolona04;
            }
            #endregion
        }
        #endregion

        
    }
}
