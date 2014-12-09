using System;
using System.Collections.Generic;
using System.Data;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataTable myDataTable = new DataTable();
            DataTable myDataTable1 = new DataTable();
            DataTable myDataTable2 = new DataTable();
            DataTable myDataTable3 = new DataTable();
            DataTable myDataTable4 = new DataTable();

            // Add columns to DataTable.
            myDataTable.Columns.Add("val1");
            myDataTable.Columns.Add("val2");
            myDataTable.Columns.Add("val3");
            myDataTable.Columns.Add("val4");
            myDataTable.Columns.Add("val5");
            myDataTable.Columns.Add("val6");

            // Add some rows to the DataTable.
            myDataTable.Rows.Add("Administrator", "Almir Music", "0.00€", "4.008,58€", "23.530,89€", "243.344,19€");
            myDataTable.Rows.Add("Mitarbeiter", "Jenny Reismann", "0.00€", "0.00€", "4.043,54€", "190.678,86€");
            myDataTable.Rows.Add("Mitarbeiter", "Claudio Cuppoletta", "0.00€", "0.00€", "6.232,62€", "158.514,47€");

            // Add columns to DataTable.
            myDataTable1.Columns.Add("val1");
            myDataTable1.Columns.Add("val2");
            myDataTable1.Columns.Add("val3");
            myDataTable1.Columns.Add("val4");
            myDataTable1.Columns.Add("val5");
            myDataTable1.Columns.Add("val6");

            // Add some rows to the DataTable.
            myDataTable1.Rows.Add("", " ", "0.00€", "4.008,58€", "33.807,05€€", "1.141.476,52€");

            // Add columns to DataTable.
            myDataTable2.Columns.Add("val1");
            myDataTable2.Columns.Add("val2");
            myDataTable2.Columns.Add("val3");
            myDataTable2.Columns.Add("val4");
            myDataTable2.Columns.Add("val5");
            myDataTable2.Columns.Add("val6");

            // Add some rows to the DataTable.
            myDataTable2.Rows.Add("", "Rechnungsstatistik", "3.887,64€", "3.887,64€", "22.170,16€", "687.962,92€");

            // Add columns to DataTable.
            myDataTable3.Columns.Add("val1");
            myDataTable3.Columns.Add("val2");
            myDataTable3.Columns.Add("val3");
            myDataTable3.Columns.Add("val4");
            myDataTable3.Columns.Add("val5");
            myDataTable3.Columns.Add("val6");
            myDataTable3.Columns.Add("val7");
            myDataTable3.Columns.Add("val8");
            myDataTable3.Columns.Add("val9");
            myDataTable3.Columns.Add("val10");
            myDataTable3.Columns.Add("val11");
            myDataTable3.Columns.Add("val12");

            // Add some rows to the DataTable.
            myDataTable3.Rows.Add("115.620,49€", "159.769,19€", "128.577,60€", "112.740,13€", "79.190,19€", "103.410,49€", "143.682,46€", "127.811,67", "117.734,55€", "33.807,05€", "0,00", "0,00");

            // Add columns to DataTable.
            myDataTable4.Columns.Add("val1");
            myDataTable4.Columns.Add("val2");
            myDataTable4.Columns.Add("val3");
            myDataTable4.Columns.Add("val4");
            myDataTable4.Columns.Add("val5");
            myDataTable4.Columns.Add("val6");
            myDataTable4.Columns.Add("val7");
            myDataTable4.Columns.Add("val8");
            myDataTable4.Columns.Add("val9");
            myDataTable4.Columns.Add("val10");
            myDataTable4.Columns.Add("val11");
            myDataTable4.Columns.Add("val12");

            // Add some rows to the DataTable.
            myDataTable4.Rows.Add("115.620,49€", "159.769,19€", "128.577,60€", "112.740,13€", "79.190,19€", "103.410,49€", "143.682,46€", "127.811,67", "117.734,55€", "33.807,05€", "0,00", "0,00");


            datagrid1.ItemsSource = myDataTable.DefaultView;
            datagrid2.ItemsSource = myDataTable1.DefaultView;
            datagrid3.ItemsSource = myDataTable2.DefaultView;
            datagrid4.ItemsSource = myDataTable3.DefaultView;
            datagrid5.ItemsSource = myDataTable4.DefaultView;
        }


        private void Window_SizeChanged_1(object sender, SizeChangedEventArgs e)
        {
            gridsResolution();
        }

        //Makes grid fits on all resolutions!!!
        public void gridsResolution()
        {
            int brKolona01 = datagrid1.Columns.Count;
            int brKolona02 = datagrid2.Columns.Count;
            int brKolona03 = datagrid3.Columns.Count;
            int brKolona04 = datagrid4.Columns.Count;
            int brKolona05 = datagrid5.Columns.Count;

            #region resolution full
            if (this.WindowState == WindowState.Maximized)
            {
                var windowWidth = System.Windows.SystemParameters.PrimaryScreenWidth - 185;
                //datagrid 01
                col1_1.Width = windowWidth / brKolona01;
                col1_2.Width = windowWidth / brKolona01;
                col1_3.Width = windowWidth / brKolona01;
                col1_4.Width = windowWidth / brKolona01;
                col1_5.Width = windowWidth / brKolona01;
                col1_6.Width = windowWidth / brKolona01;
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
                col3_6.Width = windowWidth / brKolona03;
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
                col5_1.Width = windowWidth / brKolona05;
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
                col5_12.Width = windowWidth / brKolona05;
            }
            #endregion
            #region resolution normal
            else
            {
                var windowWidth = this.Width - 200;
                //datagrid 01
                col1_1.Width = windowWidth / brKolona01;
                col1_2.Width = windowWidth / brKolona01;
                col1_3.Width = windowWidth / brKolona01;
                col1_4.Width = windowWidth / brKolona01;
                col1_5.Width = windowWidth / brKolona01;
                col1_6.Width = windowWidth / brKolona01;
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
                col3_6.Width = windowWidth / brKolona03;
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
                col5_1.Width = windowWidth / brKolona05;
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
                col5_12.Width = windowWidth / brKolona05;
            }
            #endregion
        }

        private void btnMitarbeiter_Click(object sender, RoutedEventArgs e)
        {
            MitarbeiterWindow mit = new MitarbeiterWindow();
            mit.Show();
        }

        private void btnLieferant_Click(object sender, RoutedEventArgs e)
        {
            LieferantWindow lief = new LieferantWindow();
            lief.Show();
        }

        private void btnKunden_Click(object sender, RoutedEventArgs e)
        {
            KundenWindow kun = new KundenWindow();
            kun.Show();
        }

        private void btnAngebot_Click(object sender, RoutedEventArgs e)
        {
            AngebotWindow ang = new AngebotWindow();
            ang.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnAuftragebestat_Click(object sender, RoutedEventArgs e)
        {
            AuftrageWindow auf = new AuftrageWindow();
            auf.Show();
        }

        private void btnErledigte_Click(object sender, RoutedEventArgs e)
        {
            FertigWindow fer = new FertigWindow();
            fer.Show();
        }

        private void btnAuftrageSuche_Click(object sender, RoutedEventArgs e)
        {
            AuftragsSucheWindow aufSuche = new AuftragsSucheWindow();
            aufSuche.Show();
        }
    }
}
