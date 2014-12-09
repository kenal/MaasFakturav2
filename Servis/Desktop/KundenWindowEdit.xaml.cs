using Desktop.ViewModel;
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
using System.Windows.Shapes;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for KundenWindowEdit.xaml
    /// </summary>
    public partial class KundenWindowEdit : Window
    {
        KundenWindowViewModel k = new KundenWindowViewModel();
        public KundenWindowEdit()
        {
            InitializeComponent();
            Countries = GetData();
        }

        public KundenWindowEdit(KundenWindowViewModel k)
        {
            InitializeComponent();
            this.k = k;
            this.DataContext = k;
            if (k.CloseAction == null)
            {
                k.CloseAction = new Action(() => this.Close());
            }
            Countries = GetData();
        }

        #region Countries
        public DataTable Countries
        {
            get { return (DataTable)GetValue(CountriesProperty); }
            set { SetValue(CountriesProperty, value); }
        }


        public static readonly DependencyProperty CountriesProperty =
            DependencyProperty.Register("Countries", typeof(DataTable), typeof(KundenWindowEdit), new UIPropertyMetadata(null));

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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

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

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
