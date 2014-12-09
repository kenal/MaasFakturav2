using Desktop.ViewModel;
using System;
using System.Data;
using System.Windows;
using System.Windows.Input;

namespace Desktop
{
    /// <summary>
    /// Interaction logic for LieferantWindowEdit.xaml
    /// </summary>
    public partial class LieferantWindowEdit : Window
    {
        LieferantWindowViewModel l = new LieferantWindowViewModel();
       
        public LieferantWindowEdit()
        {
            InitializeComponent();
            Countries = GetData();
        }
              public LieferantWindowEdit(LieferantWindowViewModel l)
        {
            InitializeComponent();
            this.l = l;
            this.DataContext = l;
            l.CloseAction = null;
            if (l.CloseAction == null)
            {
                l.CloseAction = new Action(() => this.Close());
                
            }
            Countries = GetData();
       }
              private void Button_Click_1(object sender, RoutedEventArgs e)
              {
                  this.Close();
              }

              private void Button_Click(object sender, RoutedEventArgs e)
              {
                  this.Close();
              }   

       #region Countries
              public DataTable Countries
              {
                  get { return (DataTable)GetValue(CountriesProperty); }
                  set { SetValue(CountriesProperty, value); }
              }


              public static readonly DependencyProperty CountriesProperty =
                  DependencyProperty.Register("Countries", typeof(DataTable), typeof(LieferantWindowEdit), new UIPropertyMetadata(null));

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
