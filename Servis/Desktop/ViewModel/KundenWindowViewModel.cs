using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desktop.Service;
using Servis.HelperClass;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Data;
using System.Windows;
using Mass.Data;
namespace Desktop.ViewModel
{
    public class KundenWindowViewModel: INotifyPropertyChanged, IDataErrorInfo
    {
        #region Fields
        int _id_kupac;
        int _broj_kupac;
        string _pojam;        
        string _ime;        
        string _prezime;
        string _titel;
        string _mjesto;        
        string _grupa;        
        string _slobodno_polje;        
        string _ime2;                
        string _ulica;        
        string _tel1;        
        string _tel2;        
        string _fax;        
        string _mail;       
        string _lk;        
        string _dostava_na;        
        string _dostava_od;        
        string _vk_cijena;        
        string _gotovina;        
        string _popust_gotovina;        
        string _dnevni_popust;        
        string _predstavnik;        
        string _limit_narudzbe;        
        int _tip;        
        string _adresa_dostava;        
        string _adresa_fakture;        
        string _mail2;        
        string _internet;        
        int? _tip_kupca;        
        int? _porez;        
        int _broj;        
        string _broj_detalji;        
        int _ocjena_kupca;       
        string _biljeska;        
        string _naziv;        
        string _zemlja;
        string _placa;        
        string _rabat;        
        string _adresa2;        
        string _grad;        
        string _predmet;        
        string _kontakt_osobe;        
        string _detalji_rute;
        MassServisClient client = new MassServisClient();
        private List<string> nacinPlacanja = new List<string>() { "Barverkauf", "Bankeinzug", "Kreditkarte", "Nachnahme", "Rechnung", "Scheck", "Vorkasse" };
        ObservableCollection<tbl_kupac> ListaKupaca;       
        tbl_kupac selektovaniKupac = new tbl_kupac();
        bool radioHer;
        bool radioFrau;
        bool radioFirma;
        bool radioFam;
        bool radioSteuer1;
        bool radioSteuer2;
        bool radioSteuer3;

        int _id_kupacEdit;
        int _broj_kupacEdit;       
        string _pojamEdit;        
        string _imeEdit;        
        string _prezimeEdit;        
        string _titelEdit;        
        string _mjestoEdit;        
        string _grupaEdit;
        string _slobodno_poljeEdit;        
        string _ime2Edit;        
        string _ulicaEdit;
        string _tel1Edit;
        string _tel2Edit;
        string _faxEdit;
        string _mailEdit;
        string _lkEdit;
        string _dostava_naEdit;
        string _dostava_odEdit;
        string _vk_cijenaEdit;
        string _gotovinaEdit;
        string _popust_gotovinaEdit;
        string _dnevni_popustEdit;
        string _predstavnikEdit;
        string _limit_narudzbeEdit;
        int _tipEdit;
        string _adresa_dostavaEdit;
        string _adresa_faktureEdit;
        string _mail2Edit;
        string _internetEdit;
        int? _tip_kupcaEdit;
        int? _porezEdit;
        int _brojEdit;
        string _broj_detaljiEdit;
        int _ocjena_kupcaEdit;        
        string _biljeskaEdit;
        string _nazivEdit;
        string _zemljaEdit;
        string _placaEdit;
        string _rabatEdit;
        string _adresa2Edit;
        string _gradEdit;
        string _predmetEdit;
        string _kontakt_osobeEdit;
        string _detalji_ruteEdit;
        bool radioHerEdit;
        bool radioFrauEdit;
        bool radioFirmaEdit;
        bool radioFamEdit;
        bool radioSteuer1Edit;
        bool radioSteuer2Edit;
        bool radioSteuer3Edit;
        ObservableCollection<tbl_kupac> ListaPage= new ObservableCollection<tbl_kupac>();
        int brojStranice =1;

        private int _kolicinaKupaca = 10;

        private List<int> _brojPrikazanihKupaca = new List<int>() { 10, 20, 25 };

        private int _maxStranica;

       

        #endregion

        #region Properties

        public int MaxStranica1
        {
            get { return _maxStranica; }
            set { _maxStranica = value; OnPropertyChanged("MaxStranica1"); }
        }
        public List<int> BrojPrikazanihKupaca
        {
            get { return _brojPrikazanihKupaca; }
            set { _brojPrikazanihKupaca = value; OnPropertyChanged("BrojPrikazanihKupaca"); }
        }

        public int KolicinaKupaca
        {
            get { return _kolicinaKupaca; }
            set { _kolicinaKupaca = value; OnPropertyChanged("KolicinaKupaca"); }
        }
        public Action CloseAction { get; set; }
        public int Id_kupac
        {
            get { return _id_kupac; }
            set 
            {
                _id_kupac = value;
                OnPropertyChanged("Id_kupac");
            }
        }

        public int Broj_kupac
        {
            get { return _broj_kupac; }
            set 
            { 
                _broj_kupac = value;
                OnPropertyChanged("Broj_kupac");
            }
        }

        public string Pojam
        {
            get { return _pojam; }
            set 
            { 
                _pojam = value;
                OnPropertyChanged("Pojam"); 
            }
        }        

        public string Ime
        {
            get { return _ime; }
            set 
            { 
                _ime = value;
                OnPropertyChanged("Ime");
            }
        }

        public string Prezime
        {
            get { return _prezime; }
            set 
            { 
                _prezime = value;
                OnPropertyChanged("Prezime");
            }
        }

        
        public string Titel
        {
            get { return _titel; }
            set 
            { 
                _titel = value;
                OnPropertyChanged("Titel");
            }
        }

        public string Mjesto
        {
            get { return _mjesto; }
            set 
            { 
                _mjesto = value;
                OnPropertyChanged("Mjesto");
            }
        }

        public string Grupa
        {
            get { return _grupa; }
            set 
            { 
                _grupa = value;
                OnPropertyChanged("Grupa");
            }
        }

        public string Slobodno_polje
        {
            get { return _slobodno_polje; }
            set 
            { 
                _slobodno_polje = value;
                OnPropertyChanged("Slobodno_polje");
            }
        }

        public string Ime2
        {
            get { return _ime2; }
            set 
            { 
                _ime2 = value;
                OnPropertyChanged("Ime2");
            }
        }

        public string Ulica
        {
            get { return _ulica; }
            set 
            { 
                _ulica = value;
                OnPropertyChanged("Ulica");
            }
        }

        public string Tel1
        {
            get { return _tel1; }
            set 
            { 
                _tel1 = value;
                OnPropertyChanged("Tel1");
            }
        }

        public string Tel2
        {
            get { return _tel2; }
            set 
            { 
                _tel2 = value;
                OnPropertyChanged("Tel2");
            }
        }

        public string Fax
        {
            get { return _fax; }
            set 
            { 
                _fax = value;
                OnPropertyChanged("Fax");
            }
        }

        public string Mail
        {
            get { return _mail; }
            set 
            { 
                _mail = value;
                OnPropertyChanged("Mail");
            }
        }

        public string Lk
        {
            get { return _lk; }
            set 
            { 
                _lk = value;
                OnPropertyChanged("Lk");
            }
        }

        public string Dostava_na
        {
            get { return _dostava_na; }
            set 
            { 
                _dostava_na = value;
                OnPropertyChanged("Dostava_na");
            }
        }

        public string Dostava_od
        {
            get { return _dostava_od; }
            set 
            { 
                _dostava_od = value;
                OnPropertyChanged("Dostava_od");
            }
        }

        public string Vk_cijena
        {
            get { return _vk_cijena; }
            set 
            { 
                _vk_cijena = value;
                OnPropertyChanged("Vk_cijena");
            }
        }

        public string Gotovina
        {
            get { return _gotovina; }
            set 
            { 
                _gotovina = value;
                OnPropertyChanged("Gotovina");
            }
        }

        public string Popust_gotovina
        {
            get { return _popust_gotovina; }
            set 
            { 
                _popust_gotovina = value;
                OnPropertyChanged("Popust_gotovina");
            }
        }

        public string Dnevni_popust
        {
            get { return _dnevni_popust; }
            set 
            { 
                _dnevni_popust = value;
                OnPropertyChanged("Dnevni_popust");
            }
        }

        public string Predstavnik
        {
            get { return _predstavnik; }
            set
            {
                _predstavnik = value;
                OnPropertyChanged("Predstavnik");
            }
        }

        public string Limit_narudzbe
        {
            get { return _limit_narudzbe; }
            set 
            { 
                _limit_narudzbe = value;
                OnPropertyChanged("Limit_narudzbe");
            }
        }

        public int Tip
        {
            get { return _tip; }
            set 
            { 
                _tip = value;
                OnPropertyChanged("Tip");
            }
        }

        public string Adresa_dostava
        {
            get { return _adresa_dostava; }
            set 
            { 
                _adresa_dostava = value;
                OnPropertyChanged("Adresa_dostava");
            }
        }

        public string Adresa_fakture
        {
            get { return _adresa_fakture; }
            set 
            { 
                _adresa_fakture = value;
                OnPropertyChanged("Adresa_fakture");
            }
        }

        public string Mail2
        {
            get { return _mail2; }
            set 
            { 
                _mail2 = value;
                OnPropertyChanged("Mail2");
            }
        }

        public string Internet
        {
            get { return _internet; }
            set 
            { 
                _internet = value;
                OnPropertyChanged("Internet");
            }
        }

        public int? Tip_kupca
        {
            get { return _tip_kupca; }
            set 
            { 
                _tip_kupca = value;
                OnPropertyChanged("Tip_kupca");
            }
        }

        public int? Porez
        {
            get { return _porez; }
            set 
            { 
                _porez = value;
                OnPropertyChanged("Porez");
            }
        }

        public int Broj
        {
            get { return _broj; }
            set 
            { 
                _broj = value;
                OnPropertyChanged("Broj");
            }
        }

        public string Broj_detalji
        {
            get { return _broj_detalji; }
            set 
            { 
                _broj_detalji = value;
                OnPropertyChanged("Broj_detalji");
            }
        }

        public int Ocjena_kupca
        {
            get { return _ocjena_kupca; }
            set 
            { 
                _ocjena_kupca = value;
                OnPropertyChanged("Ocjena_kupca");
            }
        }

        public string Biljeska
        {
            get { return _biljeska; }
            set 
            { 
                _biljeska = value;
                OnPropertyChanged("Biljeska");
            }
        }

        public string Naziv
        {
            get { return _naziv; }
            set 
            { 
                _naziv = value;
                OnPropertyChanged("Naziv");
            }
        }

        public string Zemlja
        {
            get { return _zemlja; }
            set 
            {
                _zemlja = value;
                OnPropertyChanged("Zemlja");
            }
        }

        public string Placa
        {
            get { return _placa; }
            set 
            { 
                _placa = value;
                OnPropertyChanged("Placa");
            }
        }

        public string Rabat
        {
            get { return _rabat; }
            set 
            { 
                _rabat = value;
                OnPropertyChanged("Rabat");
            }
        }

        public string Adresa2
        {
            get { return _adresa2; }
            set 
            { 
                _adresa2 = value;
                OnPropertyChanged("Adresa2");
            }
        }

        public string Grad
        {
            get { return _grad; }
            set 
            { 
                _grad = value;
                OnPropertyChanged("Grad");
            }
        }

        public string Predmet
        {
            get { return _predmet; }
            set 
            { 
                _predmet = value;
                OnPropertyChanged("Predmet");
            }
        }

        public string Kontakt_osobe
        {
            get { return _kontakt_osobe; }
            set 
            { 
                _kontakt_osobe = value;
                OnPropertyChanged("Kontakt_osobe");
            }
        }

        public string Detalji_rute
        {
            get { return _detalji_rute; }
            set 
            { 
                _detalji_rute = value;
                OnPropertyChanged("Detalji_rute");
            }
        }

        public List<string> NacinPlacanja
        {
            get { return nacinPlacanja; }
            set 
            { 
                nacinPlacanja = value;
                OnPropertyChanged("NacinPlacanja");
            }
        }

        public ObservableCollection<tbl_kupac> ListaKupaca1
        {
            get { return ListaKupaca; }
            set 
            { 
                ListaKupaca = value;
                OnPropertyChanged("ListaKupaca1");
            }
        }

        public ObservableCollection<tbl_kupac> ListaPage1
        {
            get { return ListaPage; }
            set 
            { 
                ListaPage = value;
                OnPropertyChanged("ListaPage1");
            }
        }

        public tbl_kupac SelektovaniKupac
        {
            get { return selektovaniKupac; }
            set 
            { 
                selektovaniKupac = value;
                OnPropertyChanged("SelektovaniKupac");
            }
        }

        public bool RadioHer
        {
            get { return radioHer; }
            set 
            { 
                radioHer = value;
                OnPropertyChanged("RadioHer");
            }
        }

        public bool RadioFrau
        {
            get { return radioFrau; }
            set 
            { 
                radioFrau = value;
                OnPropertyChanged("RadioFrau");
            }
        }

        public bool RadioFirma
        {
            get { return radioFirma; }
            set 
            { 
                radioFirma = value;
                OnPropertyChanged("RadioFirma");
            }
        }

        public bool RadioFam
        {
            get { return radioFam; }
            set 
            { 
                radioFam = value;
                OnPropertyChanged("RadioFam");
            }
        }

        public bool RadioSteuer1
        {
            get { return radioSteuer1; }
            set 
            { 
                radioSteuer1 = value;
                OnPropertyChanged("RadioSteuer1");
            }
        }

        public bool RadioSteuer2
        {
            get { return radioSteuer2; }
            set 
            { 
                radioSteuer2 = value;
                OnPropertyChanged("RadioSteuer2");
            }
        }

        public bool RadioSteuer3
        {
            get { return radioSteuer3; }
            set 
            { 
                radioSteuer3 = value;
                OnPropertyChanged("RadioSteuer3");
            }
        }

        public int Id_kupacEdit
        {
            get { return _id_kupacEdit; }
            set 
            { 
                _id_kupacEdit = value;
                OnPropertyChanged("Id_kupacEdit");
            }
        }

        public int Broj_kupacEdit
        {
            get { return _broj_kupacEdit; }
            set 
            { 
                _broj_kupacEdit = value;
                OnPropertyChanged("Broj_kupacEdit");
            }
        }

        public string PojamEdit
        {
            get { return _pojamEdit; }
            set 
            { 
                _pojamEdit = value;
                OnPropertyChanged("PojamEdit");
            }
        }

        public string ImeEdit
        {
            get { return _imeEdit; }
            set 
            { 
                _imeEdit = value;
                OnPropertyChanged("ImeEdit");
            }
        }

        public string PrezimeEdit
        {
            get { return _prezimeEdit; }
            set 
            { 
                _prezimeEdit = value;
                OnPropertyChanged("PrezimeEdit");
            }
        }

        public string TitelEdit
        {
            get { return _titelEdit; }
            set 
            { 
                _titelEdit = value;
                OnPropertyChanged("TitelEdit");
            }
        }

        public string MjestoEdit
        {
            get { return _mjestoEdit; }
            set 
            { 
                _mjestoEdit = value;
                OnPropertyChanged("MjestoEdit");
            }
        }

        public string GrupaEdit
        {
            get { return _grupaEdit; }
            set 
            { 
                _grupaEdit = value;
                OnPropertyChanged("GrupaEdit");
            }
        }

        public string Slobodno_poljeEdit
        {
            get { return _slobodno_poljeEdit; }
            set 
            { 
                _slobodno_poljeEdit = value;
                OnPropertyChanged("Slobodno_poljeEdit");
            }
        }

        public string Ime2Edit
        {
            get { return _ime2Edit; }
            set 
            { 
                _ime2Edit = value;
                OnPropertyChanged("Ime2Edit");
            }
        }

        public string UlicaEdit
        {
            get { return _ulicaEdit; }
            set 
            { 
                _ulicaEdit = value;
                OnPropertyChanged("UlicaEdit");
            }
        }

        public string Tel1Edit
        {
            get { return _tel1Edit; }
            set 
            { 
                _tel1Edit = value;
                OnPropertyChanged("Tel1Edit");
            }
        }

        public string Tel2Edit
        {
            get { return _tel2Edit; }
            set 
            { 
                _tel2Edit = value;
                OnPropertyChanged("Tel2Edit");
            }
        }

        public string FaxEdit
        {
            get { return _faxEdit; }
            set 
            { 
                _faxEdit = value;
                OnPropertyChanged("FaxEdit");
            }
        }

        public string MailEdit
        {
            get { return _mailEdit; }
            set 
            { 
                _mailEdit = value;
                OnPropertyChanged("MailEdit");
            }
        }

        public string LkEdit
        {
            get { return _lkEdit; }
            set 
            { 
                _lkEdit = value;
                OnPropertyChanged("LkEdit");
            }
        }

        public string Dostava_naEdit
        {
            get { return _dostava_naEdit; }
            set 
            { 
                _dostava_naEdit = value;
                OnPropertyChanged("Dostava_naEdit");
            }
        }

        public string Dostava_odEdit
        {
            get { return _dostava_odEdit; }
            set 
            {
                _dostava_odEdit = value;
                OnPropertyChanged("Dostava_odEdit");
            }
        }

        public string Vk_cijenaEdit
        {
            get { return _vk_cijenaEdit; }
            set 
            { 
                _vk_cijenaEdit = value;
                OnPropertyChanged("Vk_cijenaEdit");
            }
        }

        public string GotovinaEdit
        {
            get { return _gotovinaEdit; }
            set 
            { 
                _gotovinaEdit = value;
                OnPropertyChanged("GotovinaEdit");
            }
        }

        public string Popust_gotovinaEdit
        {
            get { return _popust_gotovinaEdit; }
            set 
            { 
                _popust_gotovinaEdit = value;
                OnPropertyChanged("Popust_gotovinaEdit");
            }
        }

        public string Dnevni_popustEdit
        {
            get { return _dnevni_popustEdit; }
            set 
            { 
                _dnevni_popustEdit = value;
                OnPropertyChanged("Dnevni_popustEdit");
            }
        }

        public string PredstavnikEdit
        {
            get { return _predstavnikEdit; }
            set 
            { 
                _predstavnikEdit = value;
                OnPropertyChanged("PredstavnikEdit");
            }
        }

        public string Limit_narudzbeEdit
        {
            get { return _limit_narudzbeEdit; }
            set 
            { 
                _limit_narudzbeEdit = value;
                OnPropertyChanged("Limit_narudzbeEdit");
            }
        }

        public int TipEdit
        {
            get { return _tipEdit; }
            set 
            { 
                _tipEdit = value;
                OnPropertyChanged("TipEdit");
            }
        }

        public string Adresa_dostavaEdit
        {
            get { return _adresa_dostavaEdit; }
            set 
            { 
                _adresa_dostavaEdit = value;
                OnPropertyChanged("Adresa_dostavaEdit");
            }
        }

        public string Adresa_faktureEdit
        {
            get { return _adresa_faktureEdit; }
            set 
            { 
                _adresa_faktureEdit = value;
                OnPropertyChanged("Adresa_faktureEdit");
            }
        }

        public string Mail2Edit
        {
            get { return _mail2Edit; }
            set 
            { 
                _mail2Edit = value;
                OnPropertyChanged("Mail2Edit");
            }
        }

        public string InternetEdit
        {
            get { return _internetEdit; }
            set 
            { 
                _internetEdit = value;
                OnPropertyChanged("InternetEdit");
            }
        }

        public int? Tip_kupcaEdit
        {
            get { return _tip_kupcaEdit; }
            set 
            { 
                _tip_kupcaEdit = value;
                OnPropertyChanged("Tip_kupcaEdit");
            }
        }

        public int? PorezEdit
        {
            get { return _porezEdit; }
            set 
            { 
                _porezEdit = value;
                OnPropertyChanged("PorezEdit");
            }
        }

        public int BrojEdit
        {
            get { return _brojEdit; }
            set 
            { 
                _brojEdit = value;
                OnPropertyChanged("BrojEdit");
            }
        }

        public string Broj_detaljiEdit
        {
            get { return _broj_detaljiEdit; }
            set 
            { 
                _broj_detaljiEdit = value;
                OnPropertyChanged("Broj_detaljiEdit");
            }
        }

        public int Ocjena_kupcaEdit
        {
            get { return _ocjena_kupcaEdit; }
            set 
            { 
                _ocjena_kupcaEdit = value;
                OnPropertyChanged("Ocjena_kupcaEdit");
            }
        }

        public string BiljeskaEdit
        {
            get { return _biljeskaEdit; }
            set 
            { 
                _biljeskaEdit = value;
                OnPropertyChanged("BiljeskaEdit");
            }
        }

        public string NazivEdit
        {
            get { return _nazivEdit; }
            set 
            { 
                _nazivEdit = value;
                OnPropertyChanged("NazivEdit");
            }
        }

        public string ZemljaEdit
        {
            get { return _zemljaEdit; }
            set 
            { 
                _zemljaEdit = value;
                OnPropertyChanged("ZemljaEdit");
            }
        }

        public string PlacaEdit
        {
            get { return _placaEdit; }
            set 
            { 
                _placaEdit = value;
                OnPropertyChanged("PlacaEdit");
            }
        }

        public string RabatEdit
        {
            get { return _rabatEdit; }
            set 
            { 
                _rabatEdit = value;
                OnPropertyChanged("RabatEdit");
            }
        }

        public string Adresa2Edit
        {
            get { return _adresa2Edit; }
            set 
            { 
                _adresa2Edit = value;
                OnPropertyChanged("Adresa2Edit");
            }
        }

        public string GradEdit
        {
            get { return _gradEdit; }
            set 
            { 
                _gradEdit = value;
                OnPropertyChanged("GradEdit");
            }
        }

        public string PredmetEdit
        {
            get { return _predmetEdit; }
            set 
            { 
                _predmetEdit = value;
                OnPropertyChanged("PredmetEdit");
            }
        }

        public string Kontakt_osobeEdit
        {
            get { return _kontakt_osobeEdit; }
            set 
            { 
                _kontakt_osobeEdit = value;
                OnPropertyChanged("Kontakt_osobeEdit");
            }
        }

        public string Detalji_ruteEdit
        {
            get { return _detalji_ruteEdit; }
            set 
            { 
                _detalji_ruteEdit = value;
                OnPropertyChanged("Detalji_ruteEdit");
            }
        }

        public bool RadioHerEdit
        {
            get { return radioHerEdit; }
            set 
            { 
                radioHerEdit = value;
                OnPropertyChanged("RadioHerEdit"); 
            }
        }

        public bool RadioFrauEdit
        {
            get { return radioFrauEdit; }
            set 
            { 
                radioFrauEdit = value;
                OnPropertyChanged("RadioFrauEdit");
            }
        }

        public bool RadioFirmaEdit
        {
            get { return radioFirmaEdit; }
            set 
            { 
                radioFirmaEdit = value;
                OnPropertyChanged("RadioFirmaEdit");
            }
        }

        public bool RadioFamEdit
        {
            get { return radioFamEdit; }
            set 
            { 
                radioFamEdit = value;
                OnPropertyChanged("RadioFamEdit");
            }
        }

        public bool RadioSteuer1Edit
        {
            get { return radioSteuer1Edit; }
            set 
            { 
                radioSteuer1Edit = value;
                OnPropertyChanged("RadioSteuer1Edit");
            }
        }

        public bool RadioSteuer2Edit
        {
            get { return radioSteuer2Edit; }
            set 
            { 
                radioSteuer2Edit = value;
                OnPropertyChanged("RadioSteuer2Edit");
            }
        }

        public bool RadioSteuer3Edit
        {
            get { return radioSteuer3Edit; }
            set 
            { 
                radioSteuer3Edit = value;
                OnPropertyChanged("RadioSteuer3Edit");
            }
        }

        public int BrojStranice
        {
            get { return brojStranice; }
            set { brojStranice = value; OnPropertyChanged("BrojStranice"); }
        }
        #endregion

        #region ICommandMembers
        private ICommand odustaniUnos;
        public ICommand OdustaniUnos
        {
            get { return odustaniUnos = new RelayCommand(param => Odustani(param)); }
            set { odustaniUnos = value; }
        }

        private ICommand _Unesi;
        public ICommand Unesi
        {
            get { return _Unesi = new RelayCommand(param => InsertKupac(param), param => this.CanSave); }
            set { _Unesi = value; }
        }

        private ICommand _PopuniGrid;

        public ICommand PopuniGrid
        {
            get { return _PopuniGrid = new RelayCommand(param => FillGridKupca(param)); }
            set { _PopuniGrid = value; }
        }

        private ICommand _obrisikupca;

        public ICommand ObrisiKupca
        {
            get { return _obrisikupca = new RelayCommand(param => ObrisiKupac(param)); }
            set { _obrisikupca = value; }
        }

        private ICommand _Update;

        public ICommand Update
        {
            get { return _Update = new RelayCommand(param => PopuniUpdate(param)); }
            set { _Update = value; }
        }

        private ICommand updatajkupca;

        public ICommand UpdatajKupca
        {
            get { return updatajkupca = new RelayCommand(param => IzvrsiUpdate(param), param => this.CanSaveEdit); }
            set { updatajkupca = value; }
        }
        private ICommand _UrediKupca;

        public ICommand UrediKupca1
        {
            get { return _UrediKupca = new RelayCommand(param => OtvoriEditKupac(param)); }
            set { _UrediKupca = value; }
        }
        private ICommand zatvoriWindow;

        public ICommand ZatvoriWindow
        {
            get { return zatvoriWindow = new RelayCommand(param => Close()); }
            set { zatvoriWindow = value; }
        }

        private ICommand _paging;

        public ICommand Paging
        {
            get { return _paging = new RelayCommand(param => FillGridKupcaPage(param)); }
            set { _paging = value; }
        }
        private ICommand _paging2;

        public ICommand Paging2
        {
            get { return _paging2 = new RelayCommand(param => FillGridKupcaPage2(param), param => this.CanNext); }
            set { _paging2 = value; }
        }

        private ICommand _pagingRikverc;

        public ICommand PagingRikverc
        {
            get { return _pagingRikverc = new RelayCommand(param => FillGridKupcaBack(param), param => this.CanLast); }
            set { _pagingRikverc = value; }
        }
        private ICommand _prebaciNaPrvi;

        public ICommand PrebaciNaPrvi
        {
            get { return _prebaciNaPrvi = new RelayCommand(param => FillGridKupcaFirst(param)); }
            set { _prebaciNaPrvi = value; }
        }

        private ICommand _prebaciNaZadnji;

        public ICommand PrebaciNaZadnji
        {
            get { return _prebaciNaZadnji = new RelayCommand(param => FillGridKupcaLast(param)); }
            set { _prebaciNaZadnji = value; }
        }
        #endregion

        #region Methods
        public void Paginacija(int stranica)
        {
            int neUzimati=10;
            
            if (ListaKupaca1 != null)
            {
                int brojPrikaza = stranica * KolicinaKupaca;
                if (brojPrikaza > ListaKupaca1.Count())
                    brojPrikaza = ListaKupaca1.Count();
                int ostatak = brojPrikaza % KolicinaKupaca;
                if (ostatak != 0)
                    neUzimati = brojPrikaza - ostatak;
                else
                    neUzimati = brojPrikaza - KolicinaKupaca;
                var x= ListaKupaca1.Skip(neUzimati).Take(brojPrikaza);
                ListaPage1.Clear();
                ListaPage1 = new ObservableCollection<tbl_kupac>(x);
            }
            Broj_kupac = client.KundenNr();
            MaxStranica();
        }
        public void Odustani(object parameter)
        {
            Broj = 0;
            
            Tip_kupca = 0;
            Ime = null;
            Prezime = null;
            Titel = null;
            Ime2 = null;
            Grad = null;
            Adresa_dostava = null;
            Adresa_fakture = null;
            Adresa2 = null;
            Tel1 = null;
            Tel2 = null;
            Fax = null;
            Mail = null;
            Internet = null;
            Popust_gotovina = null;
            Dnevni_popust = null;
            Placa = null;
            Rabat = null;
            Biljeska = null;

        }

        public void InsertKupac(object parameter)
        {
            Pojam = Prezime;
            if (RadioHer == true)
                Tip_kupca = 0;
            else if (RadioFrau == true)
                Tip_kupca = 1;
            else if (RadioFirma == true)
            {
                Tip_kupca = 2;
                Pojam = Ime2;
            }
                
            else if (RadioFam == true)
                Tip_kupca = 3;

            if (RadioSteuer1 == true)
                Porez = 0;
            else if (RadioSteuer2 == true)
                Porez = 1;
            else if (RadioSteuer3 == true)
                Porez = 2;

            tbl_kupac kupac = new tbl_kupac();
            kupac.adresa_dostava = Adresa_dostava;
            kupac.adresa_fakture = Adresa_fakture;
            kupac.adresa2 = Adresa2;
            kupac.biljeska = Biljeska;
            kupac.broj = Broj;
            kupac.broj_detalji = Broj_detalji;
            kupac.detalji_rute = Detalji_rute;
            kupac.dnevni_popust = Dnevni_popust;
            kupac.dostava_na = Dostava_na;
            kupac.dostava_od = Dostava_od;
            kupac.fax = Fax;
            kupac.gotovina = Gotovina;
            kupac.grad = Grad;
            kupac.grupa = Grupa;
            kupac.ime = Ime;
            kupac.ime2 = Ime2;
            kupac.interner = Internet;
            kupac.kontakt_osobe = Kontakt_osobe;
            kupac.limit_narudzbe = Limit_narudzbe;
            kupac.lk = Lk;
            kupac.mail = Mail;
            kupac.mail2 = Mail2;
            kupac.mjesto = Mjesto;
            kupac.naziv = Naziv;
            kupac.ocjena_kupca = Ocjena_kupca;
            kupac.placa = Placa;
            kupac.pojam = Pojam;
            kupac.popust_gotovina = Popust_gotovina;
            kupac.porez = Porez;
            kupac.predmet = Predmet;
            kupac.predstavnik = Predstavnik;
            kupac.prezime = Prezime;
            kupac.rabat = Rabat;
            kupac.slobodno_polje = Slobodno_polje;
            kupac.tel1 = Tel1;
            kupac.tel2 = Tel2;
            kupac.tip = Tip;
            kupac.tip_kupca = Tip_kupca;
            kupac.vk_cijena = Vk_cijena;
            kupac.zemlja = Zemlja;
            kupac.broj_kupac = Broj_kupac;
            kupac.pojam = Pojam;
            client.UnesiKupca(kupac);
            FillGridKupca(parameter);
            Paginacija(BrojStranice);

            Broj = 0;
            Tip_kupca = 0;
            Ime = null;
            Prezime = null;
            Titel = null;
            Ime2 = null;
            Grad = null;
            Adresa_dostava = null;
            Adresa_fakture = null;
            Adresa2 = null;
            Tel1 = null;
            Tel2 = null;
            Fax = null;
            Mail = null;
            Internet = null;
            Popust_gotovina = null;
            Dnevni_popust = null;
            Placa = null;
            Rabat = null;
            Biljeska = null;
        }

        public void FillGridKupca(object parameter)
        {
            ListaKupaca1 = client.ListaKupaca();            
        }
        public void FillGridKupcaPage(object parameter)
        {
            Paginacija(BrojStranice);
            
        }

        public void FillGridKupcaPage2(object parameter)
        {
            BrojStranice++;
            Paginacija(BrojStranice);
           
        }

        public void FillGridKupcaBack(object parameter)
        {
            BrojStranice--;
            Paginacija(BrojStranice);
        }

        public void FillGridKupcaFirst(object parameter)
        {
            BrojStranice = 1;
            Paginacija(BrojStranice);
        }

        public void FillGridKupcaLast(object parameter)
        {
            if (ListaKupaca1!=null)
            {
                int a = ListaKupaca1.Count();
                double pozicija = Convert.ToDouble(a) / KolicinaKupaca;
                if (pozicija % 1 == 0)
                    BrojStranice = Convert.ToInt32(pozicija);
                else                
                    BrojStranice = Convert.ToInt32(pozicija - ((pozicija * 10) % 10) / 10) + 1;
                Paginacija(BrojStranice);                
            }

        }

        public void MaxStranica()
        {
            if (ListaKupaca1 != null)
            {
                int a = ListaKupaca1.Count();
                double pozicija = Convert.ToDouble(a) / KolicinaKupaca;
                if (pozicija % 1 == 0)
                    MaxStranica1 = Convert.ToInt32(pozicija);
                else
                {
                    MaxStranica1 = Convert.ToInt32(pozicija - ((pozicija * 10) % 10) / 10) + 1;
                }

            }
        }
        
        public void ObrisiKupac(object parameter)
        {
            int br = Convert.ToInt32(SelektovaniKupac.broj_kupac);
            client.ObrisiKupca(br);
            FillGridKupca(parameter);
            Paginacija(BrojStranice);

        }

        public void OtvoriEditKupac(object parameter)
        {
            KundenWindowEdit kwe = new KundenWindowEdit(this);
            kwe.Show();

        }
        public void Close()
        {
            CloseAction();
        }
        public void PopuniUpdate(object parameter)
        {
            Id_kupacEdit = selektovaniKupac.id_kupac;
            Broj_kupacEdit = Convert.ToInt32(selektovaniKupac.broj_kupac);
            Adresa_dostavaEdit = selektovaniKupac.adresa_dostava;
            Adresa_faktureEdit = selektovaniKupac.adresa_fakture;
            Adresa2Edit = selektovaniKupac.adresa2;
            PojamEdit = selektovaniKupac.pojam;
            ImeEdit = selektovaniKupac.ime;
            PrezimeEdit = selektovaniKupac.prezime;
            MjestoEdit = selektovaniKupac.mjesto;
            GrupaEdit = selektovaniKupac.grupa;
            Slobodno_poljeEdit = selektovaniKupac.slobodno_polje;
            Ime2Edit = selektovaniKupac.ime2;
            UlicaEdit = selektovaniKupac.ulica;
            Tel1Edit = selektovaniKupac.tel1;
            Tel2Edit = selektovaniKupac.tel2;
            FaxEdit = selektovaniKupac.fax;
            MailEdit = selektovaniKupac.mail;
            LkEdit = selektovaniKupac.lk;
            Dostava_naEdit = selektovaniKupac.dostava_na;
            Dostava_odEdit = selektovaniKupac.dostava_od;
            Vk_cijenaEdit = selektovaniKupac.vk_cijena;
            GotovinaEdit = selektovaniKupac.gotovina;
            Popust_gotovinaEdit = selektovaniKupac.popust_gotovina;
            Dnevni_popustEdit = selektovaniKupac.dnevni_popust;
            PredstavnikEdit = selektovaniKupac.predstavnik;
            Limit_narudzbeEdit = selektovaniKupac.limit_narudzbe;
            TipEdit = Convert.ToInt32(selektovaniKupac.tip);
            Mail2Edit = selektovaniKupac.mail2;
            InternetEdit = selektovaniKupac.interner;
            Tip_kupcaEdit = Convert.ToInt32(selektovaniKupac.tip_kupca);
            PorezEdit = Convert.ToInt32(selektovaniKupac.porez);
            BrojEdit = Convert.ToInt32(selektovaniKupac.broj);
            Broj_detaljiEdit = selektovaniKupac.broj_detalji;
            Ocjena_kupcaEdit = Convert.ToInt32(selektovaniKupac.ocjena_kupca);
            BiljeskaEdit = selektovaniKupac.biljeska;
            NazivEdit = selektovaniKupac.naziv;
            ZemljaEdit = selektovaniKupac.zemlja;
            PlacaEdit = selektovaniKupac.placa;
            RabatEdit = selektovaniKupac.rabat;
            GradEdit = selektovaniKupac.grad;
            PredmetEdit = selektovaniKupac.predmet;
            Kontakt_osobeEdit = selektovaniKupac.kontakt_osobe;
            Detalji_ruteEdit = selektovaniKupac.detalji_rute;
            TitelEdit = selektovaniKupac.titel;

            if (selektovaniKupac.tip_kupca == 0)
                RadioHerEdit = true;
            else if (selektovaniKupac.tip_kupca == 1)
                RadioFrauEdit = true;
            else if (selektovaniKupac.tip_kupca == 2)
                RadioFirmaEdit = true;
            else if (selektovaniKupac.tip_kupca == 3)
                RadioFamEdit = true;

            if (selektovaniKupac.porez == 0)
                RadioSteuer1Edit = true;
            else if (selektovaniKupac.porez == 1)
                RadioSteuer2Edit = true;
            else if (selektovaniKupac.porez == 2)
                RadioSteuer3Edit = true;

            
        }
        public void IzvrsiUpdate(object parameter)
        {
            tbl_kupac kupac = new tbl_kupac();
            kupac.id_kupac = selektovaniKupac.id_kupac;
            kupac.adresa_dostava = Adresa_dostavaEdit;
            kupac.adresa_fakture = Adresa_faktureEdit;
            kupac.adresa2 = Adresa2Edit;
            kupac.biljeska = BiljeskaEdit;
            kupac.broj = BrojEdit;
            kupac.broj_detalji = Broj_detaljiEdit;
            kupac.broj_kupac = Broj_kupacEdit;
            kupac.detalji_rute = Detalji_ruteEdit;
            kupac.dnevni_popust = Dnevni_popustEdit;
            kupac.dostava_na = Dostava_naEdit;
            kupac.dostava_od = Dostava_odEdit;
            kupac.fax = FaxEdit;
            kupac.gotovina = GotovinaEdit;
            kupac.grad = GradEdit;
            kupac.grupa = GrupaEdit;
            kupac.ime = ImeEdit;
            kupac.interner = InternetEdit;
            kupac.kontakt_osobe = Kontakt_osobeEdit;
            kupac.limit_narudzbe = Limit_narudzbeEdit;
            kupac.lk = LkEdit;
            kupac.mail = MailEdit;
            kupac.mail2 = Mail2Edit;
            kupac.mjesto = MjestoEdit;
            kupac.naziv = NazivEdit;
            kupac.ocjena_kupca = Ocjena_kupcaEdit;
            kupac.placa = PlacaEdit;
            kupac.popust_gotovina = Popust_gotovinaEdit;
            kupac.predmet = PredmetEdit;
            kupac.predstavnik = PredstavnikEdit;
            kupac.prezime = PrezimeEdit;
            kupac.rabat = RabatEdit;
            kupac.slobodno_polje = Slobodno_poljeEdit;
            kupac.tel1 = Tel1Edit;
            kupac.tel2 = Tel2Edit;
            kupac.tip = TipEdit;
            kupac.titel = TitelEdit;
            kupac.ulica = UlicaEdit;
            kupac.vk_cijena = Vk_cijenaEdit;
            kupac.zemlja = ZemljaEdit;

            PojamEdit = PrezimeEdit;
            if (RadioHerEdit == true)
                kupac.tip_kupca = 0;
            else if (RadioFrauEdit == true)
                kupac.tip_kupca = 1;
            else if (RadioFirmaEdit == true)
            {
                kupac.tip_kupca = 2;
                PojamEdit = Ime2Edit;
            }
            else if (RadioFamEdit == true)
                kupac.tip_kupca = 3;

            if (RadioSteuer1Edit == true)
                PorezEdit = 0;
            else if (RadioSteuer2Edit == true)
                PorezEdit = 1;
            else if (RadioSteuer3Edit == true)
                PorezEdit = 2;
            else
                PorezEdit = null;
            kupac.pojam = PojamEdit;
            kupac.porez = PorezEdit;
            client.UpdateKupac(kupac);
            FillGridKupca(parameter);
            ZatvoriWindow.Execute(this);
            Paginacija(BrojStranice);

        }
        #endregion

        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region IDataErrorInfo
        public string this[string columnName]
        {
            get
            {
                string Result = null;
                if ("Ime" == columnName)
                {
                    if (String.IsNullOrEmpty(Ime))
                        Result = "Unesite ime.";
                }
                else if("Prezime" == columnName)
                {
                    if (String.IsNullOrEmpty(Prezime))
                        Result = "Unesite prezime.";
                }
                else if ("Adresa_dostava" == columnName)
                {
                    if (String.IsNullOrEmpty(Adresa_dostava))
                        Result = "Unesite adresu dostave.";
                }
                else if ("Adresa_fakture" == columnName)
                {
                    if (String.IsNullOrEmpty(Adresa_fakture))
                        Result = "Unesite adresu racuna.";
                }
                else if ("Tel1" == columnName)
                {
                    if (String.IsNullOrEmpty(Tel1))
                        Result = "Unesite telefon.";
                }
                else if ("Mail" == columnName)
                {
                    if (String.IsNullOrEmpty(Mail))
                        Result = "Unesite mail.";
                }

                else if ("IsValid" == columnName)
                {
                    Result = true.ToString();
                }

                if ("ImeEdit" == columnName)
                {
                    if (String.IsNullOrEmpty(ImeEdit))
                        Result = "Unesite ime.";
                }
                else if ("PrezimeEdit" == columnName)
                {
                    if (String.IsNullOrEmpty(PrezimeEdit))
                        Result = "Unesite prezime.";
                }
                else if ("Adresa_dostavaEdit" == columnName)
                {
                    if (String.IsNullOrEmpty(Adresa_dostavaEdit))
                        Result = "Unesite adresu dostave.";
                }
                else if ("Adresa_faktureEdit" == columnName)
                {
                    if (String.IsNullOrEmpty(Adresa_faktureEdit))
                        Result = "Unesite adresu racuna.";
                }
                else if ("Tel1Edit" == columnName)
                {
                    if (String.IsNullOrEmpty(Tel1Edit))
                        Result = "Unesite telefon.";
                }
                else if ("MailEdit" == columnName)
                {
                    if (String.IsNullOrEmpty(MailEdit))
                        Result = "Unesite mail.";
                }

                else if ("IsValidEdit" == columnName)
                {
                    Result = true.ToString();
                }

                return Result;
            }
        }

        static readonly string[] ValidatedProperties = 
        {
            "Ime",
            "Prezime",
            "Adresa_dostava",
            "Adresa_fakture",
            "Tel1",
            "Mail"
        };

        public bool IsValid
        {
            get
            {
                foreach (string property in ValidatedProperties)
                {
                    if(GetValidationError(property) != null)
                        return false;
                }
                return true;
            }
        }

        private string GetValidationError(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "Ime":
                    error = this["Ime"];
                    break;
                case "Prezime":
                    error = this["Prezime"];
                    break;
                case "Adresa_dostava":
                    error = this["Adresa_dostava"];
                    break;
                case "Adresa_fakture":
                    error = this["Adresa_fakture"];
                    break;
                case "Tel1":
                    error = this["Tel1"];
                    break;
                case "Mail":
                    error = this["Mail"];
                    break;
                default:
                    error = null;
                    throw new Exception("Unexpected property being validated on Service");
            }
            return error;
        }

        protected bool CanSave
        {
            get
            {
                return IsValid;
            }
        }

        static readonly string[] ValidatedPropertiesEdit = 
        {
            "ImeEdit",
            "PrezimeEdit",
            "Adresa_dostavaEdit",
            "Adresa_faktureEdit",
            "Tel1Edit",
            "MailEdit"
        };

        public bool IsValidEdit
        {
            get
            {
                foreach (string property in ValidatedPropertiesEdit)
                {
                    if (GetValidationErrorEdit(property) != null)
                        return false;
                }
                return true;
            }
        }

        private string GetValidationErrorEdit(string propertyName)
        {
            string error = null;
            switch (propertyName)
            {
                case "ImeEdit":
                    error = this["ImeEdit"];
                    break;
                case "PrezimeEdit":
                    error = this["PrezimeEdit"];
                    break;
                case "Adresa_dostavaEdit":
                    error = this["Adresa_dostavaEdit"];
                    break;
                case "Adresa_faktureEdit":
                    error = this["Adresa_faktureEdit"];
                    break;
                case "Tel1Edit":
                    error = this["Tel1Edit"];
                    break;
                case "MailEdit":
                    error = this["MailEdit"];
                    break;
                default:
                    error = null;
                    throw new Exception("Unexpected property being validated on Service");
            }
            return error;
        }

        protected bool CanSaveEdit
        {
            get
            {
                return IsValidEdit;
            }
        }

        public bool IsMin
        {
            get
            {
                if (BrojStranice == 1)
                    return false;
                else
                    return true;
            }
        }

        public bool IsMax
        {
            get
            {
                if (BrojStranice == MaxStranica1)
                    return false;
                else 
                    return true;
            }
        }

        protected bool CanNext
        {
            get
            {
                return IsMax;
            }
        }


        protected bool CanLast
        {
            get 
            { 
                return IsMin; 
            }
        }

        public string Error
        {
            get { throw new NotImplementedException(); }
        }
        #endregion
       
    }
}
