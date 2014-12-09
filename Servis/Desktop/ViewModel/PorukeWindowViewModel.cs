using Desktop.Service;
using Servis.HelperClass;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Desktop.ViewModel
{
   public class PorukeWindowViewModel : INotifyPropertyChanged
    {
        #region Fields
        private List<int> _comboPoruke = new List<int>() { 10, 25, 50, 100 };
        private int _brojPrikazanihPoruka=10;
        MassServisClient client = new MassServisClient();
        private ObservableCollection<tbl_poruka_primljene> _listaPrimljenihPoruka = new ObservableCollection<tbl_poruka_primljene>();
        private tbl_korisnik _selektovaniKorisnik;
        private ObservableCollection<tbl_korisnik> _listaKorisnika = new ObservableCollection<tbl_korisnik>();
        private ObservableCollection<tbl_poruka_poslane> _listaPoslanihPoruka = new ObservableCollection<tbl_poruka_poslane>();
        private tbl_poruka_primljene _selektovanaPrimljenaPoruka;
        private tbl_poruka_poslane _selektovanaPoslanaPoruka;
        private  string _message;

       

     
        private string _betreff;
        private string _poruka;
        #endregion

        #region Properties
        public  string Message
        {
            get { return _message; }
            set { _message = value; OnPropertyChanged("Message"); }
        }
        public tbl_poruka_poslane SelektovanaPoslanaPoruka
        {
            get { return _selektovanaPoslanaPoruka; }
            set { _selektovanaPoslanaPoruka = value; OnPropertyChanged("SelektovanaPoslanaPoruka"); }
        }
        public tbl_poruka_primljene SelektovanaPrimljenaPoruka
        {
            get { return _selektovanaPrimljenaPoruka; }
            set { _selektovanaPrimljenaPoruka = value; OnPropertyChanged("SelektovanaPrimljenaPoruka"); }
        }

        public ObservableCollection<tbl_poruka_poslane> ListaPoslanihPoruka
        {
            get { return _listaPoslanihPoruka; }
            set { _listaPoslanihPoruka = value; OnPropertyChanged("ListaPoslanihPoruka"); }
        }
        public string Poruka
        {
            get { return _poruka; }
            set { _poruka = value; OnPropertyChanged("Poruka"); }
        }
        public string Betreff
        {
            get { return _betreff; }
            set { _betreff = value; OnPropertyChanged("Betreff"); }
        }
        public tbl_korisnik SelektovaniKorisnik
        {
            get { return _selektovaniKorisnik; }
            set { _selektovaniKorisnik = value; OnPropertyChanged("SelektovaniKorisnik"); }
        }

        public ObservableCollection<tbl_poruka_primljene> ListaPrimljenihPoruka
        {
            get { return _listaPrimljenihPoruka; }
            set { _listaPrimljenihPoruka = value; OnPropertyChanged("ListaPrimljenihPoruka"); }
        }
        public ObservableCollection<tbl_korisnik> ListaKorisnika
        {
            get { return _listaKorisnika; }
            set { _listaKorisnika = value; OnPropertyChanged("ListaKorisnika"); }
        }
        public List<int> ComboPoruke
        {
            get { return _comboPoruke; }
            set { _comboPoruke = value; OnPropertyChanged("ComboPoruke"); }
        }
        public int BrojPrikazanihPoruka
        {
            get { return _brojPrikazanihPoruka; }
            set { _brojPrikazanihPoruka = value; OnPropertyChanged("BrojPrikazanihPoruka"); }
        }
        #endregion

        #region ICommand Memebers
        private ICommand _inboxShow;

        public ICommand InboxShow
        {
            get { return _inboxShow = new RelayCommand(param => PrikaziPrimljenuPoruku(param)); }
            set { _inboxShow = value; }
        }

        private ICommand _outboxShow;

        public ICommand OutboxShow
        {
            get { return _outboxShow = new RelayCommand(param => PrikaziPoslanuPoruku(param)); }
            set { _outboxShow = value; }
        }
        private ICommand _popuniCombo;

        public ICommand PopuniCombo
        {
            get { return _popuniCombo = new RelayCommand(param => FillComboKorisnicima(param)); }
            set { _popuniCombo = value; }
        }
        private ICommand _popuniGridPrimljenihPor;

        public ICommand PopuniGridPrimljenihPor
        {
            get { return _popuniGridPrimljenihPor = new RelayCommand(param => PopuniGridPrimljenihPoruka(param)); }
            set { _popuniGridPrimljenihPor = value; }
        }

        private ICommand _sending;

        public ICommand Sending
        {
            get { return _sending = new RelayCommand(param => Send(param)); }
            set { _sending = value; }
        }

        private ICommand _listaPoslanihPor;

        public ICommand ListaPoslanihPor
        {
            get { return _listaPoslanihPor = new RelayCommand(param => PopuniGridPoslanihPoruka(param)); }
            set { _listaPoslanihPor = value; }
        }
        #endregion

        #region Methods
        public void FillComboKorisnicima(object parameter)
        {
            ListaKorisnika = client.ComboKorisniciPoruke(Sesija.Id_korisnik);
        }

        public void PopuniGridPrimljenihPoruka(object parameter)
        {
            ListaPrimljenihPoruka = client.ListaPrimljenihPoruka(Sesija.Id_korisnik);
        }
        public void PopuniGridPoslanihPoruka(object parameter)
        {
            ListaPoslanihPoruka = client.ListaPoslanihPoruka(Sesija.Id_korisnik);
        }
        public void Send(object parameter)
        {
            client.PosaljiPoruku(SelektovaniKorisnik.id_korisnik, Sesija.Id_korisnik, Poruka, Betreff);
            Poruka = null;
            Betreff = null;
        }

        public void PrikaziPoslanuPoruku(object parameter)
        {
           if(SelektovanaPoslanaPoruka == null)
           {
               Message = "";
           }
           else
               Message = SelektovanaPoslanaPoruka.predmet;
        }

        public void PrikaziPrimljenuPoruku(object parameter)
        {
            if (SelektovanaPrimljenaPoruka == null)
            {
                Message = "";
            }
            else
                Message = SelektovanaPrimljenaPoruka.predmet;
        }
        #endregion

        #region INofifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        } 
        #endregion
   }

}
