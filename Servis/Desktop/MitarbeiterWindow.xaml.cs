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

namespace MassProject
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MitarbeiterWindow : Window
    {
        public MitarbeiterWindow()
        {
            InitializeComponent();
            this.DataContext = new MitarbeiterWindowViewModel();
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
                var windowWidth = System.Windows.SystemParameters.PrimaryScreenWidth - 80;
                //datagrid 01
                col1_1.Width = windowWidth / brKolona01;
                col1_2.Width = windowWidth / brKolona01;
                col1_3.Width = windowWidth / brKolona01;
                col1_4.Width = windowWidth / brKolona01;
                col1_5.Width = windowWidth / brKolona01;
                col1_6.Width = windowWidth / brKolona01;
                col1_7.Width = windowWidth / brKolona01;
                col1_8.Width = windowWidth / brKolona01;
                col1_9.Width = windowWidth / brKolona01;
              
            }
            #endregion
            #region resolution normal
            else
            {
                var windowWidth = this.Width - 97;
                var windowWidth2 = this.Width - 130;
                var windowWidth3 = this.Width +173;
                //datagrid 01
                col1_1.Width = windowWidth2 / brKolona01;
                col1_2.Width = windowWidth2 / brKolona01;
                col1_3.Width = windowWidth2 / brKolona01;
                col1_4.Width = windowWidth2 / brKolona01;
                col1_5.Width = windowWidth2 / brKolona01;
                col1_6.Width = windowWidth2 / brKolona01;
                col1_7.Width = windowWidth2 / brKolona01;
                col1_8.Width = windowWidth2 / brKolona01;
                col1_9.Width = windowWidth3 / brKolona01;
              

            }
            #endregion
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
