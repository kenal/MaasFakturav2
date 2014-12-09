using Desktop.Service;
using Servis.HelperClass;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Desktop.ViewModel
{
   public class MitarbeiterWindowViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        #region Fields
        private int _mitarbeiterNr;
        private int _titula=0;
        private string _vorname=null;
        private string _name = null;
        private DateTime _geburstdatum = DateTime.Now;
        private string _adresse = null;
        private string _telefon = null;
        private string _telefon2 = null;
        private string _handy = null;
        private string _skype = null;
        private string _fax = null;
        private string _email = null;
        private ObservableCollection<tbl_radnik> _listaRadnika;
        private ObservableCollection<tbl_korisnik> _listaKorisnika;
        private float _gehalt = 0;
        private float _stundenlohn = 0;
        private string _urlaubstage = null;
        private string _urlaubstageDuzan = null;
        private float _anzahlGehalter = 0;
        private float _wochenstunden = 0;
        private string _krankenheitstage = "";
        private string _bank = null;
        private string _blz = null;
        private string _ktoNr = null;
        private string _bic = null;
        private string _iban = null;
        private string _kontoinhaber = null;
        private string _notiz = null;
        private MassServisClient client = new MassServisClient();
        private bool _radioHerr;
        private bool _radioFrau;
        private tbl_korisnik _selektovaniKorisnik;
        private tbl_radnik _selektovaniRadnik;
        private string _pretraga;
        

        private int _mitarbeiterNrEdit = 0;
        private int _titulaEdit = 0;
        private string _vornameEdit = null;
        private string _nameEdit = null;
        private DateTime _geburstdatumEdit = DateTime.Now;
        private string _adresseEdit = null;
        private string _telefonEdit = null;
        private string _telefon2Edit = null;
        private string _handyEdit = null;
        private string _skypeEdit = null;
        private string _faxEdit = null;
        private string _emailEdit = null;
        private float _gehaltEdit = 0;
        private float _stundenlohnEdit = 0;
        private string _urlaubstageEdit = null;
        private string _urlaubstageDuzanEdit = null;
        private float _anzahlGehalterEdit = 0;
        private float _wochenstundenEdit = 0;
        private string _krankenheitstageEdit = "";
        private string _bankEdit = null;
        private string _blzEdit = null;
        private string _ktoNrEdit = null;
        private string _bicEdit = null;
        private string _ibanEdit = null;
        private string _kontoinhaberEdit = null;
        private string _notizEdit = null;
        private bool _radioHerrEdit;
        private bool _radioFrauEdit;
        private tbl_korisnik _selektovaniKorisnikEdit=null;
        private tbl_korisnik _comboKorisnik = null;
        private int _maxStranica;
        private int _selektovaniIndex;

        private int _brojStranice=1;

        private int _kolicinaRadnika = 10;
        private ObservableCollection<tbl_radnik> ListaPage = new ObservableCollection<tbl_radnik>();
        private List<int> _brojPrikazanihRadnika = new List<int>() { 10, 20, 25 };
        private bool? status;

       

       
   
      
        #endregion

        #region Properties

        public bool? Status
        {
            get { return status; }
            set { status = value; OnPropertyChanged("Status"); }
        }
        public List<int> BrojPrikazanihRadnika
        {
            get { return _brojPrikazanihRadnika; }
            set { _brojPrikazanihRadnika = value; OnPropertyChanged("BrojPrikazanihRadnika"); }
        }

        public int MaxStranica1
        {
            get { return _maxStranica; }
            set
            {
                _maxStranica = value;
                OnPropertyChanged("MaxStranica1");
            }
        }

        public int BrojStranice
        {
            get { return _brojStranice; }
            set { _brojStranice = value; OnPropertyChanged("BrojStranice"); }
        }
        public ObservableCollection<tbl_radnik> ListaPage1
        {
            get { return ListaPage; }
            set { ListaPage = value; OnPropertyChanged("ListaPage1"); }
        }
        public int KolicinaRadnika
        {
            get { return _kolicinaRadnika; }
            set { _kolicinaRadnika = value; OnPropertyChanged("KolicinaRadnika"); }
        }

        public string Pretraga
        {
            get { return _pretraga; }
            set { _pretraga = value; OnPropertyChanged("Pretraga"); }
        }

        public tbl_korisnik ComboKorisnik
        {
            get { return _comboKorisnik; }
            set { _comboKorisnik = value; OnPropertyChanged("ComboKorisnik"); }
        }
        public int SelektovaniIndex1
        {
            get { return _selektovaniIndex; }
            set { _selektovaniIndex = value; OnPropertyChanged("SelektovaniIndex"); }
        }
        public tbl_korisnik SelektovaniKorisnikEdit
        {
            get { return _selektovaniKorisnikEdit; }
            set { _selektovaniKorisnikEdit = value; OnPropertyChanged("SelektovaniKorisnikEdit"); }
        }

        public string BankEdit
        {
            get { return _bankEdit; }
            set { _bankEdit = value; OnPropertyChanged("BankEdit"); }
        }
        public Action CloseAction { get; set; }
        public bool RadioFrauEdit
        {
            get { return _radioFrauEdit; }
            set { _radioFrauEdit = value; OnPropertyChanged("RadioFrauEdit"); }
        }
        public bool RadioHerrEdit
        {
            get { return _radioHerrEdit; }
            set { _radioHerrEdit = value; OnPropertyChanged("RadioHerrEdit"); }
        }
        public string NotizEdit
        {
            get { return _notizEdit; }
            set { _notizEdit = value; OnPropertyChanged("NotizEdit"); }
        }
        public string KontoinhaberEdit
        {
            get { return _kontoinhaberEdit; }
            set { _kontoinhaberEdit = value; OnPropertyChanged("KontoinhaberEdit"); }
        }
        public string IbanEdit
        {
            get { return _ibanEdit; }
            set { _ibanEdit = value; OnPropertyChanged("IbanEdit"); }
        }
        public string BicEdit
        {
            get { return _bicEdit; }
            set { _bicEdit = value; OnPropertyChanged("BicEdit"); }
        }
        public string KtoNrEdit
        {
            get { return _ktoNrEdit; }
            set { _ktoNrEdit = value; OnPropertyChanged("KtoNrEdit"); }
        }
        public string BlzEdit
        {
            get { return _blzEdit; }
            set { _blzEdit = value; OnPropertyChanged("BlzEdit"); }
        }
        public string KrankenheitstageEdit
        {
            get { return _krankenheitstageEdit; }
            set { _krankenheitstageEdit = value; OnPropertyChanged("KrankenheitstageEdit"); }
        }
        public float WochenstundenEdit
        {
            get { return _wochenstundenEdit; }
            set { _wochenstundenEdit = value; OnPropertyChanged("WochenstundenEdit"); }
        }
        public float AnzahlGehalterEdit
        {
            get { return _anzahlGehalterEdit; }
            set { _anzahlGehalterEdit = value; OnPropertyChanged("AnzahlGehlaterEdit"); }
        }
        public string UrlaubstageDuzanEdit
        {
            get { return _urlaubstageDuzanEdit; }
            set { _urlaubstageDuzanEdit = value; OnPropertyChanged("UrlaubstageDuzanEdit"); }
        }
        public string UrlaubstageEdit
        {
            get { return _urlaubstageEdit; }
            set { _urlaubstageEdit = value; OnPropertyChanged("UrlaubstageEdit"); }
        }
        public float StundenlohnEdit
        {
            get { return _stundenlohnEdit; }
            set { _stundenlohnEdit = value; OnPropertyChanged("StundenlohnEdit"); }
        }
        public float GehaltEdit
        {
            get { return _gehaltEdit; }
            set { _gehaltEdit = value; OnPropertyChanged("GehaltEdit"); }
        }
        public string EmailEdit
        {
            get { return _emailEdit; }
            set { _emailEdit = value; OnPropertyChanged("EmailEdit"); }
        }
        public string FaxEdit
        {
            get { return _faxEdit; }
            set { _faxEdit = value; OnPropertyChanged("FaxEdit"); }
        }
        public string SkypeEdit
        {
            get { return _skypeEdit; }
            set { _skypeEdit = value; OnPropertyChanged("SkypeEdit"); }
        }
        public string HandyEdit
        {
            get { return _handyEdit; }
            set { _handyEdit = value; OnPropertyChanged("HandyEdit"); }
        }
        public string Telefon2Edit
        {
            get { return _telefon2Edit; }
            set { _telefon2Edit = value; OnPropertyChanged("Telefon2Edit"); }
        }
        public string TelefonEdit
        {
            get { return _telefonEdit; }
            set { _telefonEdit = value; OnPropertyChanged("TelefonEdit"); }
        }
        public string AdresseEdit
        {
            get { return _adresseEdit; }
            set { _adresseEdit = value; OnPropertyChanged("AdresseEdit"); }
        }
        public DateTime GeburstdatumEdit
        {
            get { return _geburstdatumEdit; }
            set { _geburstdatumEdit = value; OnPropertyChanged("GeburstdatumEdit"); }
        }
        public string NameEdit
        {
            get { return _nameEdit; }
            set { _nameEdit = value; OnPropertyChanged("NameEdit"); }
        }
        public string VornameEdit
        {
            get { return _vornameEdit; }
            set { _vornameEdit = value; OnPropertyChanged("VornameEdit"); }
        }
        public int TitulaEdit
        {
            get { return _titulaEdit; }
            set { _titulaEdit = value; OnPropertyChanged("TitulaEdit"); }
        }
        public int MitarbeiterNrEdit
        {
            get { return _mitarbeiterNrEdit; }
            set { _mitarbeiterNrEdit = value; OnPropertyChanged("MitarbeuterNrEdit"); }
        }
        public tbl_radnik SelektovaniRadnik
        {
            get { return _selektovaniRadnik; }
            set { _selektovaniRadnik = value; OnPropertyChanged("SelektovaniRadnik"); }
        }

        public tbl_korisnik SelektovaniKorisnik
        {
            get { return _selektovaniKorisnik; }
            set { _selektovaniKorisnik = value; OnPropertyChanged("SelektovaniKorisnik"); }
        }
        public ObservableCollection<tbl_korisnik> ListaKorisnika
        {
            get { return _listaKorisnika; }
            set { _listaKorisnika = value; OnPropertyChanged("ListaKorisnika"); }
        }
       public int MitarbeiterNr
       {
           get { return _mitarbeiterNr; }
           set { _mitarbeiterNr = value; OnPropertyChanged("MitarbeiterNr"); }

       }
       public int Titula
       {
           get { return _titula; }
           set { _titula = value; OnPropertyChanged("Titula"); }
       }

       public string Vorname
       {
           get { return _vorname; }
           set { _vorname = value; OnPropertyChanged("Vorname"); }
       }
       public string Name
       {
           get { return _name; }
           set { _name = value; OnPropertyChanged("Name"); }
       }

       public DateTime Geburstdatum
       {
           get { return _geburstdatum; }
           set { _geburstdatum = value; OnPropertyChanged("Geburstdatum"); }
       }


       public string Adresse
       {
           get { return _adresse; }
           set { _adresse = value; OnPropertyChanged("Adresse"); }
       }

       public string Telefon
       {
           get { return _telefon; }
           set { _telefon = value; OnPropertyChanged("Telefon"); }
       }
       public string Telefon2
       {
           get { return _telefon2; }
           set { _telefon2 = value; OnPropertyChanged("Telefon2"); }
       }

       public string Handy
       {
           get { return _handy; }
           set { _handy = value; OnPropertyChanged("Handy"); }
       }

       public string Skype
       {
           get { return _skype; }
           set { _skype = value; OnPropertyChanged("Skype"); }
       }
       public string Fax
       {
           get { return _fax; }
           set { _fax = value; OnPropertyChanged("Fax"); }
       }
       public string Email
       {
           get { return _email; }
           set { _email = value; OnPropertyChanged("Email"); }
       }
       public ObservableCollection<tbl_radnik> ListaRadnika
       {
           get { return _listaRadnika; }
           set { _listaRadnika = value; OnPropertyChanged("ListaRadnika"); }
       }
       public float Gehalt
       {
           get { return _gehalt; }
           set { _gehalt = value; OnPropertyChanged("Gehalt"); }
       }
       public float Stundenlohn
       {
           get { return _stundenlohn; }
           set { _stundenlohn = value; OnPropertyChanged("Stundenlohn"); }
       }

       public string Urlaubstage
       {
           get { return _urlaubstage; }
           set { _urlaubstage = value; OnPropertyChanged("Urlaubstage"); }
       }
       public string UrlaubstageDuzan
       {
           get { return _urlaubstageDuzan; }
           set { _urlaubstageDuzan = value; OnPropertyChanged("UrlaubstageDuzan"); }
       }
       public float AnzahlGehalter
       {
           get { return _anzahlGehalter; }
           set { _anzahlGehalter = value; OnPropertyChanged("AnzahlGehalter"); }
       }
       public float Wochenstunden
       {
           get { return _wochenstunden; }
           set { _wochenstunden = value; OnPropertyChanged("Wochenstunden"); }
       }
       public string Krankenheitstage
       {
           get { return _krankenheitstage; }
           set { _krankenheitstage = value; OnPropertyChanged("Krankenheitstage"); }
       }
       public string Bank
       {
           get { return _bank; }
           set { _bank = value; OnPropertyChanged("Bank"); }
       }
       public string Blz
       {
           get { return _blz; }
           set { _blz = value; OnPropertyChanged("Blz"); }
       }
       public string KtoNr
       {
           get { return _ktoNr; }
           set { _ktoNr = value; OnPropertyChanged("KtoNr"); }
       }
       public string Bic
       {
           get { return _bic; }
           set { _bic = value; OnPropertyChanged("Bic"); }
       }
       public string Iban
       {
           get { return _iban; }
           set { _iban = value; OnPropertyChanged("Iban"); }
       }
       public string Kontoinhaber
       {
           get { return _kontoinhaber; }
           set { _kontoinhaber = value; OnPropertyChanged("Kontoinhaber"); }
       }
       public string Notiz
       {
           get { return _notiz; }
           set { _notiz = value; OnPropertyChanged("Notiz"); }
       }
       public bool RadioHerr
       {
           get { return _radioHerr; }
           set { _radioHerr = value; OnPropertyChanged("RadioHerr"); }
       }
       public bool RadioFrau
       {
           get { return _radioFrau; }
           set { _radioFrau = value; OnPropertyChanged("RadioFrau"); }
       }
       #endregion

        #region Methods
           public void Paginacija(int stranica)
           {
               int neUzimati = 0;

               if (ListaRadnika != null)
               {
                   int brojPrikaza = stranica * KolicinaRadnika;
                   if (brojPrikaza > ListaRadnika.Count())
                       brojPrikaza = ListaRadnika.Count();
                   int ostatak = brojPrikaza % KolicinaRadnika;
                   if (ostatak != 0)
                       neUzimati = brojPrikaza - ostatak;
                   else
                       neUzimati = brojPrikaza - KolicinaRadnika;
                   var x = ListaRadnika.Skip(neUzimati).Take(KolicinaRadnika);
                   ListaPage1.Clear();
                   ListaPage1 = new ObservableCollection<tbl_radnik>(x);

               }
               MaxStranica();
          
           }

           public void PromjeniStatus(object parameter)
           {
           
               if (SelektovaniRadnik.status == true)
               {
                   client.ChangeWorkerStatus(SelektovaniRadnik.id_radnik, false);
               }
               else
                   client.ChangeWorkerStatus(SelektovaniRadnik.id_radnik, true);
               PopuniGrid(parameter);
               Paginacija(BrojStranice);
           }

      
           public void FillGridRadnikPage(object parameter)
           {
               Paginacija(BrojStranice);

           }
           public void FillGridRadnikPage2(object parameter)
           {
               BrojStranice++;
               Paginacija(BrojStranice);

           }

           public void FillGridRadnikBack(object parameter)
           {
               BrojStranice--;
               Paginacija(BrojStranice);
           }

           public void FillGridRadnikFirst(object parameter)
           {
               BrojStranice = 1;
               Paginacija(BrojStranice);
           }

           public void FillGridRadnikLast(object parameter)
           {
               if (ListaRadnika != null)
               {
                   double pozicija = Convert.ToDouble(ListaRadnika.Count()) / KolicinaRadnika;
                   if (pozicija % 1 == 0)
                       BrojStranice = Convert.ToInt32(pozicija);
                   else
                   {
                       BrojStranice = Convert.ToInt32(pozicija - ((pozicija * 10) % 10)/10) + 1;
                   }
                   
                   Paginacija(BrojStranice);
               }

           }

           public void MaxStranica()
           {
               if (ListaRadnika != null)
               {
                   int a = ListaRadnika.Count();
                   double pozicija = Convert.ToDouble(a) / KolicinaRadnika;
                   if (pozicija % 1 == 0)
                       MaxStranica1 = Convert.ToInt32(pozicija);
                   else
                   {
                       MaxStranica1 = Convert.ToInt32(pozicija - ((pozicija * 10) % 10) / 10) + 1;
                   }                 
               
               }
           }

     
           public void TraziRadnika(object parameter)
           {
               ListaRadnika = client.PretraziRadnika(Pretraga);
           }
           public void Close()
           {
               CloseAction();
          
           }
           public void Unesi(object parameter)
           {
               if (RadioFrau == true)
               {
                   Titula =1;
               }
               if (RadioHerr == true)
               {
                   Titula = 0;
               }
    
               client.UnesiRadnika(MitarbeiterNr, Titula, Name, Vorname, Adresse, Telefon, Telefon2, Handy, Fax,Skype, Email, Gehalt, Stundenlohn, Urlaubstage, UrlaubstageDuzan, AnzahlGehalter,
               Krankenheitstage, Bank, Blz, Bic, KtoNr, Iban, Kontoinhaber, Notiz, Geburstdatum, SelektovaniKorisnik.id_korisnik);
               MitarbeiterNr= client.MitarbeiterNr();
               Titula=0;
               Vorname=null; 
               Name=null;
               //Geburstdatum=;
               Adresse=null;
               Telefon=null; 
               Telefon2=null; 
               Handy=null;
               Skype=null; 
               Fax=null; 
               Email=null;
               Gehalt=0;
               Stundenlohn=0;
               Urlaubstage=null;
               UrlaubstageDuzan=null;
               AnzahlGehalter=0;
               Wochenstunden=0;
               Krankenheitstage=null; 
               Bank=null;
               Blz=null;
               KtoNr=null;
               Bic=null;
               Iban=null;
               Kontoinhaber=null;
               Notiz = null;
               PopuniGrid(parameter);
               Paginacija(BrojStranice);

           }
           public void PopuniGrid(object parameter)
           {
               ListaRadnika = client.ListaRadnika();
               MitarbeiterNr = client.MitarbeiterNr();
           }
           public void Odustani(object parameter)
           {
               MitarbeiterNr = 0;
               Titula = 0;
               Vorname = null;
               Name = null;
               //Geburstdatum=;
               Adresse = null;
               RadioFrau = false;
               RadioHerr = false;
               Telefon = null;
               Telefon2 = null;
               Handy = null;
               Skype = null;
               Fax = null;
               Email = null;
               Gehalt = 0;
               Stundenlohn = 0;
               Urlaubstage = null;
               UrlaubstageDuzan = null;
               AnzahlGehalter = 0;
               Wochenstunden = 0;
               Krankenheitstage = null;
               Bank = null;
               Blz = null;
               KtoNr = null;
               Bic = null;
               Iban = null;
               Kontoinhaber = null;
               Notiz = null;
           }
           public void popuniCombo(object parameter)
           {
               ListaKorisnika = client.ComboKorisnici();
           }

           public void PopuniEditRadnik(object parameter)
           {
               MitarbeiterNrEdit = Convert.ToInt32(SelektovaniRadnik.sifra_radnik);
               Titula = SelektovaniRadnik.tip;
               if (Titula == 0)
               {
                   RadioHerrEdit = true;
               }
               if (Titula == 1)
               {
                   RadioFrauEdit = true;
               }
               NameEdit= SelektovaniRadnik.ime;
               VornameEdit= SelektovaniRadnik.prezime;
               AdresseEdit= SelektovaniRadnik.adresa;
               TelefonEdit= SelektovaniRadnik.tel1;
               Telefon2Edit= SelektovaniRadnik.tel2;
               HandyEdit= SelektovaniRadnik.mobitel;
               FaxEdit= SelektovaniRadnik.fax;
               SkypeEdit = SelektovaniRadnik.skype;
               EmailEdit= SelektovaniRadnik.email;
               GehaltEdit= (float)SelektovaniRadnik.zarada;
               StundenlohnEdit= (float)SelektovaniRadnik.satnica;
               UrlaubstageEdit= SelektovaniRadnik.odmor;
               UrlaubstageDuzanEdit= SelektovaniRadnik.odmor_na;
               AnzahlGehalterEdit = (float)SelektovaniRadnik.broj_plate;
               KrankenheitstageEdit= SelektovaniRadnik.bolovanje;
               BankEdit= SelektovaniRadnik.banka;
               BlzEdit= SelektovaniRadnik.blz;
               BicEdit= SelektovaniRadnik.bic;
               KtoNrEdit= SelektovaniRadnik.KtoNr;
               IbanEdit= SelektovaniRadnik.iban;
               KontoinhaberEdit= SelektovaniRadnik.vlasnik_racuna;
               NotizEdit= SelektovaniRadnik.biljeska;
               if (SelektovaniRadnik.datum != null)
                   GeburstdatumEdit = Convert.ToDateTime(SelektovaniRadnik.datum);
               else
                   GeburstdatumEdit = DateTime.Now;
           }
           public void RadnikEdit(object parameter)
           {
           
               tbl_radnik radnik = new tbl_radnik();
               radnik.id_radnik = SelektovaniRadnik.id_radnik;
               radnik.sifra_radnik = MitarbeiterNrEdit;
               radnik.tip = TitulaEdit;
               radnik.ime = NameEdit;
               radnik.prezime = VornameEdit;
               radnik.adresa = AdresseEdit;
               radnik.tel1 = TelefonEdit;
               radnik.tel2 = Telefon2Edit;
               radnik.mobitel = HandyEdit;
               radnik.fax = FaxEdit;
               radnik.skype = SkypeEdit;
               radnik.email = EmailEdit;
               radnik.zarada = Convert.ToDecimal(GehaltEdit);
               radnik.satnica = Convert.ToDecimal(StundenlohnEdit);
               radnik.odmor = UrlaubstageEdit;
               radnik.odmor_na = UrlaubstageDuzanEdit;
               radnik.broj_plate = Convert.ToDecimal(AnzahlGehalterEdit);
               radnik.bolovanje = KrankenheitstageEdit;
               radnik.banka = BankEdit;
               radnik.blz = BlzEdit;
               radnik.bic = BicEdit;
               radnik.KtoNr = KtoNrEdit;
               radnik.iban = IbanEdit;
               radnik.vlasnik_racuna = KontoinhaberEdit;
               radnik.biljeska = NotizEdit;
               radnik.datum = GeburstdatumEdit;
         
               client.UpdateRadnika(radnik,Convert.ToInt32(ComboKorisnik.id_korisnik));
               PopuniGrid(parameter);
               Paginacija(BrojStranice);
               ZatvoriWindow.Execute(this);
               SelektovaniRadnik = null;

           }
           public void OtvoriEditRadnik(object parameter)
           {
               MitarbeiterWindowEdit MWE = new MitarbeiterWindowEdit(this);
               MWE.Show();
           }
           public void BrisanjeRadnika(object parameter)
           {

               int sifraRadnik = SelektovaniRadnik.sifra_radnik;
               client.DeleteRadnik(sifraRadnik);
               PopuniGrid(parameter);
               Paginacija(BrojStranice);

       
           }

           public void OdaberiSelektovanogKorisnika(object parameter)
           {
               SelektovaniKorisnikEdit = client.VratiKorisnika(SelektovaniRadnik.id_korisnik_FK);
           }
           public void SelektovaniIndex(object parameter)
           {
      
               for (int i = 0; i < ListaKorisnika.Count(); i++)
               {
                   if (ListaKorisnika[i].id_korisnik == SelektovaniKorisnikEdit.id_korisnik)
                   {
                       ComboKorisnik = ListaKorisnika[i];
                       break;
                   }
              
               }
           
           }
           public void ZatvoriEditRadnik(object parameter)
           {
               ZatvoriWindow.Execute(this);
           }

     
         #endregion


        #region ICommand Members
           private ICommand _search;

           public ICommand Search
           {
               get { return _search = new RelayCommand(param =>TraziRadnika(param)); }
               set { _search = value; }
           }
           private ICommand _closeEditRadnik;

           public ICommand CloseEditRadnik
           {
               get { return _closeEditRadnik = new RelayCommand(param => ZatvoriEditRadnik(param)); }
               set { _closeEditRadnik = value; }
           }

           private ICommand _cancel;
           public ICommand Cancel
           {
               get { return _cancel = new RelayCommand(param=> Odustani(param)); }
               set { _cancel = value; }
           }

           private ICommand _selektuj;

           public ICommand Selektuj
           {
               get { return _selektuj = new RelayCommand(param => SelektovaniIndex(param)); }
               set { _selektuj = value; }
           }

           private ICommand _comboSelektovan;

           public ICommand ComboSelektovan
           {
               get { return _comboSelektovan = new RelayCommand(param => OdaberiSelektovanogKorisnika(param)); }
               set { _comboSelektovan = value; }
           }

           private ICommand _otvoriEditRadnik;

           public ICommand OtvoriEditRadnik1
           {
               get { return _otvoriEditRadnik = new RelayCommand(param =>OtvoriEditRadnik(param)); }
               set { _otvoriEditRadnik = value; }
           }

           private ICommand _popuniEditWindow;

           public ICommand PopuniEditWindow
           {
               get { return _popuniEditWindow = new RelayCommand(param => PopuniEditRadnik(param)); }
               set { _popuniEditWindow = value;  }
           }

           private ICommand zatvoriWindow;

           public ICommand ZatvoriWindow
           {
               get { return zatvoriWindow = new RelayCommand(param => Close()); }
               set { zatvoriWindow = value; }
           }

           private ICommand _obrisiRadnika;

           public ICommand ObrisiRadnika
           {
               get { return _obrisiRadnika = new RelayCommand(param => BrisanjeRadnika(param)); }
               set { _obrisiRadnika = value; }
           }

           private ICommand _urediRadnika;

           public ICommand UrediRadnika
           {
               get { return _urediRadnika = new RelayCommand(param => RadnikEdit(param), param => this.CanSaveEdit); }
               set { _urediRadnika = value; }
           }

           private ICommand PopuniComboKorisnika;

           public ICommand PopuniComboKorisnika1
           {
               get { return PopuniComboKorisnika= new RelayCommand(param=> popuniCombo(param)); }
               set { PopuniComboKorisnika = value; }
           }

           private ICommand _popuniGridListomRadnika;

           public ICommand PopuniGridListomRadnika
           {
               get { return _popuniGridListomRadnika = new RelayCommand(param=> PopuniGrid(param)); }
               set { _popuniGridListomRadnika = value; }
           }

           private ICommand _dodajRadnika;

           public ICommand DodajRadnika
           {
               get { return _dodajRadnika = new RelayCommand(param=> Unesi(param), param=> this.CanSave); }
               set { _dodajRadnika = value; }
           }

           private ICommand _paging;

           public ICommand Paging
           {
               get { return _paging = new RelayCommand(param => FillGridRadnikPage(param)); }
               set { _paging = value; }
           }
           private ICommand _paging2;

           public ICommand Paging2
           {
               get { return _paging2 = new RelayCommand(param => FillGridRadnikPage2(param),param => this.CanNext); }
               set { _paging2 = value; }
           }

           private ICommand _pagingRikverc;

           public ICommand PagingRikverc
           {
               get { return _pagingRikverc = new RelayCommand(param => FillGridRadnikBack(param), param=> this.CanLast); }
               set { _pagingRikverc = value; }
           }
           private ICommand _prebaciNaPrvi;

           public ICommand PrebaciNaPrvi
           {
               get { return _prebaciNaPrvi = new RelayCommand(param => FillGridRadnikFirst(param)); }
               set { _prebaciNaPrvi = value; }
           }

           private ICommand _prebaciNaZadnji;

           public ICommand PrebaciNaZadnji
           {
               get { return _prebaciNaZadnji = new RelayCommand(param => FillGridRadnikLast(param)); }
               set { _prebaciNaZadnji = value; }
           }

           private ICommand _changeStat;

           public ICommand ChangeStat
           {
               get { return _changeStat = new RelayCommand(param => PromjeniStatus(param)); }
               set { _changeStat = value; }
           }
       #endregion

        #region INotifyProperty Members

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
                if ("MitarbeiterNr" == columnName)
                {
                    if (MitarbeiterNr <= 0)
                        Result = "Broj mora biti veći od nule.";
                }
                else if ("Vorname" == columnName)
                {
                    if (String.IsNullOrEmpty(Vorname))
                        Result = "Unesite ime.";
                }
                else if ("Name" == columnName)
                {
                    if (String.IsNullOrEmpty(Name))
                        Result = "Unesite prezime.";
                }
                else if ("Adresse" == columnName)
                {
                    if (String.IsNullOrEmpty(Adresse))
                        Result = "Unesite adresu.";
                }
                else if ("Telefon" == columnName)
                {
                    if (String.IsNullOrEmpty(Telefon))
                        Result = "Unesite telefon.";
                }
                else if ("Email" == columnName)
                {
                    if (String.IsNullOrEmpty(Email))
                        Result = "Unesite mail.";
                }
                
                else if ("IsValid" == columnName)
                    Result = true.ToString();

                if("MitarbeiterNrEdit" == columnName)
                {
                    if (MitarbeiterNrEdit <= 0)
                        Result = "Broj mora biti veći od nule.";
                }
                else if ("VornameEdit" == columnName)
                {
                    if (String.IsNullOrEmpty(VornameEdit))
                        Result = "Unesite ime.";
                }
                else if ("NameEdit" == columnName)
                {
                    if (String.IsNullOrEmpty(NameEdit))
                        Result = "Unesite prezime.";
                }
                else if ("AdresseEdit" == columnName)
                {
                    if (String.IsNullOrEmpty(AdresseEdit))
                        Result = "Unesite adresu.";
                }
                else if ("TelefonEdit" == columnName)
                {
                    if (String.IsNullOrEmpty(TelefonEdit))
                        Result = "Unesite telefon.";
                }
                else if ("EmailEdit" == columnName)
                {
                    if (String.IsNullOrEmpty(EmailEdit))
                        Result = "Unesite mail.";
                }
                else if ("IsValidEdit" == columnName)
                    Result = true.ToString();

                return Result;
            }
        }

        static readonly string[] ValidatedProperties =
       {
           "MitarbeiterNr",
           "Vorname",
           "Name",
           "Adresse",
           "Telefon",
           "Email",
       };

       public bool IsValid
        {
            get
            {
                foreach(string property in ValidatedProperties)
                {
                    if (GetValidationError(property) != null)
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
               case "MitarbeiterNr":
                   error = this["MitarbeiterNr"];
                   break;
               case "Vorname":
                   error = this["Vorname"];
                   break;
               case "Name":
                   error = this["Name"];
                   break;
               case "Adresse":
                   error = this["Adresse"];
                   break;
               case "Telefon":
                   error = this["Telefon"];
                   break;
               case "Email":
                   error = this["Email"];
                   break;
               default:
                   error = null;
                   throw new Exception("Unexpected property being validated on Service");
           }
           return error;
       }

       static readonly string[] ValidatedPropertiesEdit =
       {
           "MitarbeiterNrEdit",
           "VornameEdit",
           "NameEdit",
           "AdresseEdit",
           "TelefonEdit",
           "EmailEdit",
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
               case "MitarbeiterNrEdit":
                   error = this["MitarbeiterNrEdit"];
                   break;
               case "VornameEdit":
                   error = this["VornameEdit"];
                   break;
               case "NameEdit":
                   error = this["NameEdit"];
                   break;
               case "AdresseEdit":
                   error = this["AdresseEdit"];
                   break;
               case "TelefonEdit":
                   error = this["TelefonEdit"];
                   break;
               case "EmailEdit":
                   error = this["EmailEdit"];
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

       protected bool CanLast
       {
           get
           {
               return IsMin;
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

       public string Error
       {
           get { throw new NotImplementedException(); }
       }

        

        #endregion
    }
}
