using Desktop;
using Desktop.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
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
	/// Interaction logic for LieferantWIndow.xaml
	/// </summary>
	public partial class LieferantWindow : Window
	{
        private LieferantWindowViewModel ViewModel = new LieferantWindowViewModel();

        public LieferantWindowViewModel ViewModel1
        {
            get { return ViewModel; }
            set { ViewModel = value; }
        }
		public LieferantWindow()
		{
			this.InitializeComponent();
           
            this.DataContext = ViewModel1;
            Countries = GetData();
			// Insert code required on object creation below this point.
		}

        public void gridsResolution()
        {
            int brKolona01 = datagrid1.Columns.Count;
            #region resolution full
            if (this.WindowState == WindowState.Maximized)
            {
                var windowWidth = System.Windows.SystemParameters.PrimaryScreenWidth - 87;
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
                var windowWidth = this.Width - 104;
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

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            gridsResolution();
        }

        #region Countries
        public DataTable Countries
        {
            get { return (DataTable)GetValue(CountriesProperty); }
            set { SetValue(CountriesProperty, value); }
        }


        public static readonly DependencyProperty CountriesProperty =
            DependencyProperty.Register("Countries", typeof(DataTable), typeof(LieferantWindow), new UIPropertyMetadata(null));

        //public String SelectedCountry
        //{
        //    get { return (String)GetValue(SelectedCountryProperty); }
        //    set { SetValue(SelectedCountryProperty, value);

        //    }
        //}


        //public static readonly DependencyProperty SelectedCountryProperty =
        //    DependencyProperty.Register("SelectedCountry", typeof(String), typeof(KundenWindow), new UIPropertyMetadata(null));

        public DataTable GetData()
        {
            DataTable dt = new DataTable();

            DataSet ds = new DataSet();

            ds.ReadXml(AppDomain.CurrentDomain.BaseDirectory + "XML\\countries.xml");
            return ds.Tables[0];
        }
        #endregion

        #region Timer

        private void CountryCombo_DropDownOpened(object sender, EventArgs e)
        {
            System.Windows.Threading.DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(Vrtnja);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();
            Mouse.OverrideCursor = Cursors.Wait;
        }

        public static void Vrtnja(object sender, EventArgs e)
        {
            Mouse.OverrideCursor = null;

        }
        #endregion
	}

}