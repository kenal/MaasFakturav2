using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Desktop.Service;
using System.Windows.Input;
using Servis.HelperClass;
using System.Collections.ObjectModel;

namespace Desktop.ViewModel
{
   public class LieferantWindowViewModel : INotifyPropertyChanged, IDataErrorInfo
    {
        #region Fields
        private int _IdLieferant;
        private int _LieferantNr;
        private int _Titula;
        private string _Vorname;
        private string _Name;
        private string _Land;
        private string _Adresse;
        private string _Telefon;
        private string _Telefon2;
        private string _Handy;
        private string _Skype;
        private string _Fax;
        private string _Mail;
        private string _Branche;
        private string _Skonto;
        private float _Tage;
        private string _Zahlbar;
        private float _Rabatt;
        private bool _Bankeinzug;
        private int _Steuer;
        private string _Bank;
        private string _BLZ;
        private string _KtoNr;
        private string _BIC;
        private string _IBAN;
        private string _Kontoinhaber;
        private float _Umsatz;
        private string _Zahlweise;
        private string _Notiz;
        private MassServisClient client = new MassServisClient();
        private bool radioHer;
        private bool radioFrau;
        private bool radioFirma;
        private bool radioSteuer1;
        private bool radioSteuer2;
        private bool radioSteuer3;
        private List<string> nacinPlacanja = new List<string>() { "Barverkauf", "Bankeinzug", "Kreditkarte", "Nachnahme", "Rechnung","Scheck","Vorkasse" };
        private ObservableCollection<tbl_dobavljac> ListaDobavljaca;
        private tbl_dobavljac selektovaniDobavljac = new tbl_dobavljac();
        private string _pretraga;
        private int _maxStranica;     
     

       
       private int logovaniKorisnik;

       

        private int _IdLieferantEdit;
        private int _LieferantNrEdit;
        private int _TitulaEdit;
        private string _VornameEdit;
        private string _NameEdit;
        private string _LandEdit;
        private string _AdresseEdit;
        private string _TelefonEdit;
        private string _Telefon2Edit;
        private string _HandyEdit;
        private string _SkypeEdit;
        private string _FaxEdit;
        private string _MailEdit;
        private string _BrancheEdit;
        private string _SkontoEdit;
        private float _TageEdit;
        private string _ZahlbarEdit;
        private float _RabattEdit;
        private bool _BankeinzugEdit;
        private int _SteuerEdit;
        private string _BankEdit;
        private string _BLZEdit;
        private string _KtoNrEdit;
        private string _BICEdit;
        private string _IBANEdit;
        private string _KontoinhaberEdit;
        private float _UmsatzEdit;
        private string _ZahlweiseEdit;
        private string _NotizEdit;
        private bool radioHerEdit;
        private bool radioFrauEdit;
        private bool radioFirmaEdit;
        private bool radioSteuer1Edit;
        private bool radioSteuer2Edit;
        private bool radioSteuer3Edit;

        private int _brojStranice=1;
        private ObservableCollection<tbl_dobavljac> ListaPage = new ObservableCollection<tbl_dobavljac>();
        private List<int> _brojPrikazanihDobavljaca = new List<int>() { 10, 20, 25 };
        private int _kolicinaDobavljaca = 10;
        private string selektovanaZemlja;

        #endregion
     

       #region Properties

        public string SelektovanaZemlja
        {
            get { return this.selektovanaZemlja; }
            set
            {
                this.selektovanaZemlja = value;
                this.OnPropertyChanged("SelektovanaZemlja");
            }
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
        public int KolicinaDobavljaca
        {
            get { return _kolicinaDobavljaca; }
            set { _kolicinaDobavljaca = value; OnPropertyChanged("KolicinaDobavljaca"); }
        }
        public List<int> BrojPrikazanihDobavljaca
        {
            get { return _brojPrikazanihDobavljaca; }
            set { _brojPrikazanihDobavljaca = value; OnPropertyChanged("BrojPrikazanihDobavljaca"); }
        }

        public ObservableCollection<tbl_dobavljac> ListaPage1
        {
            get { return ListaPage; }
            set { ListaPage = value; OnPropertyChanged("ListaPage1"); }
        }

        public int BrojStranice
        {
            get { return _brojStranice; }
            set { _brojStranice = value; OnPropertyChanged("BrojStranice"); }
        }
        public string Pretraga
        {
            get { return _pretraga; }
            set { _pretraga = value; OnPropertyChanged("Pretraga"); }
        }
        public int LogovaniKorisnik
        {
            get { return logovaniKorisnik; }
            set { logovaniKorisnik = value;  }
        }

        
        public Action CloseAction { get; set; }
        public bool RadioSteuer3Edit
        {
            get { return radioSteuer3Edit; }
            set { radioSteuer3Edit = value; OnPropertyChanged("RadioSteuer3Edit"); }
        }
        public bool RadioSteuer2Edit
        {
            get { return radioSteuer2Edit; }
            set { radioSteuer2Edit = value; OnPropertyChanged("RadioSteuer2Edit"); }
        }
        public bool RadioSteuer1Edit
        {
            get { return radioSteuer1Edit; }
            set { radioSteuer1Edit = value; OnPropertyChanged("RadioSteuer1Edit"); }
        }
        public bool RadioFirmaEdit
        {
            get { return radioFirmaEdit; }
            set { radioFirmaEdit = value; OnPropertyChanged("RadioFirmaEdit"); }
        }
        public bool RadioFrauEdit
        {
            get { return radioFrauEdit; }
            set { radioFrauEdit = value; OnPropertyChanged("RadioFrauEdit"); }
        }
        public string NotizEdit
        {
            get { return _NotizEdit; }
            set { _NotizEdit = value; OnPropertyChanged("NotizEdit"); }
        }
        public bool RadioHerEdit
        {
            get { return radioHerEdit; }
            set { radioHerEdit = value; OnPropertyChanged("RadioHerEdit"); }
        }
        public string ZahlweiseEdit
        {
            get { return _ZahlweiseEdit; }
            set { _ZahlweiseEdit = value; OnPropertyChanged("ZahlweiseEdit"); }
        }
        public float UmsatzEdit
        {
            get { return _UmsatzEdit; }
            set { _UmsatzEdit = value; OnPropertyChanged("UmsatzEdit"); }
        }
        public string KontoinhaberEdit
        {
            get { return _KontoinhaberEdit; }
            set { _KontoinhaberEdit = value; OnPropertyChanged("KontoinhaberEdit"); }
        }
        public string IBANEdit
        {
            get { return _IBANEdit; }
            set { _IBANEdit = value; OnPropertyChanged("IBANEdit"); }
        }
        public string BICEdit
        {
            get { return _BICEdit; }
            set { _BICEdit = value; OnPropertyChanged("BICEdit"); }
        }
        public string KtoNrEdit
        {
            get { return _KtoNrEdit; }
            set { _KtoNrEdit = value; OnPropertyChanged("KtoNrEdit"); }
        }
        public string BLZEdit
        {
            get { return _BLZEdit; }
            set { _BLZEdit = value; OnPropertyChanged("BLZEdit"); }
        }
        public string BankEdit
        {
            get { return _BankEdit; }
            set { _BankEdit = value; OnPropertyChanged("BankEdit"); }
        }

        public int IdLieferantEdit
        {
            get { return _IdLieferantEdit; }
            set { _IdLieferantEdit = value; OnPropertyChanged("IdLieferantEdit"); }
        }

        public int LieferantNrEdit
        {
            get { return _LieferantNrEdit; }
            set { _LieferantNrEdit = value; OnPropertyChanged("LieferantNrEdit"); }
        }

        public int SteuerEdit
        {
            get { return _SteuerEdit; }
            set { _SteuerEdit = value; OnPropertyChanged("SteuerEdit"); }
        }
        public bool BankeinzugEdit
        {
            get { return _BankeinzugEdit; }
            set { _BankeinzugEdit = value; OnPropertyChanged("BankeinugEdit"); }
        }
        public float RabattEdit
        {
            get { return _RabattEdit; }
            set { _RabattEdit = value; OnPropertyChanged("RabbatEdit"); }
        }
        public string ZahlbarEdit
        {
            get { return _ZahlbarEdit; }
            set { _ZahlbarEdit = value; OnPropertyChanged("ZahlbarEdit"); }
        }
        public float TageEdit
        {
            get { return _TageEdit; }
            set { _TageEdit = value; OnPropertyChanged("TageEdit"); }
        }
        public string SkontoEdit
        {
            get { return _SkontoEdit; }
            set { _SkontoEdit = value; OnPropertyChanged("SkontoEdit"); }
        }
        public string BrancheEdit
        {
            get { return _BrancheEdit; }
            set { _BrancheEdit = value; OnPropertyChanged("BrancheEdit"); }
        }
        public string MailEdit
        {
            get { return _MailEdit; }
            set { _MailEdit = value; OnPropertyChanged("MailEdit"); }
        }
        public string FaxEdit
        {
            get { return _FaxEdit; }
            set { _FaxEdit = value; OnPropertyChanged("FaxEdit"); }
        }
        public string SkypeEdit
        {
            get { return _SkypeEdit; }
            set { _SkypeEdit = value; OnPropertyChanged("SkypeEdit"); }
        }
        public string HandyEdit
        {
            get { return _HandyEdit; }
            set { _HandyEdit = value; OnPropertyChanged("HandyEdit"); }
        }
        public string Telefon2Edit
        {
            get { return _Telefon2Edit; }
            set { _Telefon2Edit = value; OnPropertyChanged("Telefon2Edit"); }
        }
        public string TelefonEdit
        {
            get { return _TelefonEdit; }
            set { _TelefonEdit = value; OnPropertyChanged("TelefonEdit"); }
        }
        public int TitulaEdit
        {
            get { return _TitulaEdit; }
            set { _TitulaEdit = value; OnPropertyChanged("TitulaEdit"); }
        }
        public string AdresseEdit
        {
            get { return _AdresseEdit; }
            set { _AdresseEdit = value; OnPropertyChanged("AdresseEdit"); }
        }

        public string VornameEdit
        {
            get { return _VornameEdit; }
            set { _VornameEdit = value; OnPropertyChanged("VornameEdit"); }
        }
        public string LandEdit
        {
            get { return _LandEdit; }
            set { _LandEdit = value; OnPropertyChanged("LandEdit"); }
        }
        public string NameEdit
        {
            get { return _NameEdit; }
            set { _NameEdit = value; OnPropertyChanged("NameEdit"); }
        }
      
        public tbl_dobavljac SelektovaniDobavljac
        {
            get { return selektovaniDobavljac; }
            set {
                selektovaniDobavljac = value;
                OnPropertyChanged("SelektovaniDobavljac");
            }
        }

       
        public ObservableCollection<tbl_dobavljac> ListaDobavljaca1
        {
            get { return ListaDobavljaca; }
            set { ListaDobavljaca = value; OnPropertyChanged("ListaDobavljaca1"); }
        }
        public List<string> NacinPlacanja
        {
            get { return nacinPlacanja; }
            set { nacinPlacanja = value; OnPropertyChanged("NacinPlacanja"); }
        }

        public bool RadioSteuer3
        {
            get { return radioSteuer3; }
            set { 
                radioSteuer3 = value;
                OnPropertyChanged("RadioSteuer3");
                }
        }

        public bool RadioSteuer2
        {
            get { return radioSteuer2; }
            set { 
                radioSteuer2 = value;
                 OnPropertyChanged("RadioSteuer2");
            }
        }

        public bool RadioSteuer1
        {
            get { return radioSteuer1; }
            set { 
                radioSteuer1 = value;
                OnPropertyChanged("RadioSteuer1");
            }
        }

        public bool RadioFirma
        {
            get { return radioFirma; }
            set { radioFirma = value; OnPropertyChanged("RadioFirma"); }
        }

        public bool RadioFrau
        {
            get { return radioFrau; }
            set { radioFrau = value; OnPropertyChanged("RadioFrau"); }
        }
        public int IdLieferant
        {
            get { return _IdLieferant; }
            set { 
                _IdLieferant = value;
                OnPropertyChanged("IdLieferant");
                }
        }
       public int LieferantNr
       {
           get { return _LieferantNr; }
           set { 
               _LieferantNr = value;
               OnPropertyChanged("LieferantNr");
                  }
       }
       public int Titula
       {
           get { return _Titula; }
           set {
               _Titula = value;
               OnPropertyChanged("Titula");
           }
       }
       public string Vorname
       {
           get { return _Vorname; }
           set {
               _Vorname = value; 
               OnPropertyChanged("Vorname");
           }
       }
       public string Name
       {
           get { return _Name; }
           set { _Name = value;
               OnPropertyChanged("Name"); }
       }
       public string Land
       {
           get { return _Land; }
           set { _Land = value; }
       }
       public string Adresse
       {
           get { return _Adresse; }
           set {
               _Adresse = value; 
               OnPropertyChanged("Adresse");
           }
       }
       public string Telefon
       {
           get { return _Telefon; }
           set { 
               _Telefon = value; 
               OnPropertyChanged("Telefon"); 
              }
       }
       public string Telefon2
       {
           get { return _Telefon2; }
           set {
               _Telefon2 = value; 
               OnPropertyChanged("Telefon2");
                }
       }
       public string Handy
       {
           get { return _Handy; }
           set {
               _Handy = value; 
               OnPropertyChanged("Handy"); 
                }
       }
       public string Skype
       {
           get { return _Skype; }
           set { 
               _Skype = value;
               OnPropertyChanged("Skype");
           }
       }
       public string Fax
       {
           get { return _Fax; }
           set {
               _Fax = value; 
               OnPropertyChanged("Fax"); 
                }
       }
       public string Mail
       {
           get { return _Mail; }
           set {
               _Mail = value;
               OnPropertyChanged("Mail");
                }
       }
       public string Branche
       {
           get { return _Branche; }
           set { _Branche = value; 
               OnPropertyChanged("Branche"); }
       }
       public string Skonto
       {
           get { return _Skonto; }
           set { 
               _Skonto = value;
               OnPropertyChanged("Skonto");
                }
       }
       public float Tage
       {
           get { return _Tage; }
           set {
               _Tage = value;
               OnPropertyChanged("Tage"); 
                }
       }
       public string Zahlbar
       {
           get { return _Zahlbar; }
           set {
               _Zahlbar = value; 
               OnPropertyChanged("Zahlbar"); 
                 }
       }
       public float Rabatt
       {
           get { return _Rabatt; }
           set { _Rabatt = value; 
               OnPropertyChanged("Rabatt");
                }
       }

       public bool Bankeinzug
       {
           get { return _Bankeinzug; }
           set { 
               _Bankeinzug = value;
               OnPropertyChanged("Bankeinzug"); 
                }
       }
       public int Steuer
       {
           get { return _Steuer; }
           set {
               _Steuer = value;
               OnPropertyChanged("Steuer"); 
                }
       }
       public string Bank
       {
           get { return _Bank; }
           set { 
               _Bank = value;
               OnPropertyChanged("Bank");
                }
       }
       public string BLZ
       {
           get { return _BLZ; }
           set { 
               _BLZ = value;
               OnPropertyChanged("BLZ"); 
                }
       }
       public string KtoNr
       {
           get { return _KtoNr; }
           set { 
               _KtoNr = value; 
               OnPropertyChanged("KtoNr"); 
                }
       }

       public string BIC
       {
           get { return _BIC; }
           set { 
               _BIC = value; 
               OnPropertyChanged("BIC"); 
           }

       }
       public string IBAN
       {
           get { return _IBAN; }
           set { 
               _IBAN = value; 
               OnPropertyChanged("IBAN");
           }
       }
       public string Kontoinhaber
       {
           get { return _Kontoinhaber; }
           set { 
               _Kontoinhaber = value; 
               OnPropertyChanged("Kontoinhaber");
           }
       }
       public float Umsatz
       {
           get { return _Umsatz; }
           set {
               _Umsatz = value;
               OnPropertyChanged("Umsatz");
                }
       }
       public string Zahlweise
       {
           get { return _Zahlweise; }
           set { 
               _Zahlweise = value;
               OnPropertyChanged("Zahlweise");
            }
       }
       public string Notiz
       {
           get { return _Notiz; }
           set { _Notiz = value;
               OnPropertyChanged("Notiz");
           }
       }

       public bool RadioHer
       {
           get { return radioHer; }
           set {
               radioHer = value; 
               OnPropertyChanged("RadioHer"); 
                }
       }
       #endregion

       #region ICommand Members
       private ICommand _search;

       public ICommand Search
       {
           get { return _search = new RelayCommand(param => TraziDobavljaca(param)); }
           set { _search = value; }
       }
       private ICommand odustaniUnos;

       public ICommand OdustaniUnos
       {
           get { return odustaniUnos = new RelayCommand(param => Odustani(param)); }
           set { odustaniUnos = value; }
       }
       private ICommand _Unesi;

       public ICommand Unesi
       {
           get 
           {
               if (_Unesi == null)
                   _Unesi = new RelayCommand(param => this.InsertDobavljac(param), param => this.CanSave); 
               return _Unesi;
           }
           set { _Unesi = value; }
       }

       private ICommand _PopuniGrid;

       public ICommand PopuniGrid
       {
           get { return _PopuniGrid = new RelayCommand(param => FillGridDobavljaca(param)); }
           set { _PopuniGrid = value; }
       }

       private ICommand _obrisidobavljaca;

       public ICommand Obrisidobavljaca
       {
           get { return _obrisidobavljaca = new RelayCommand(param => ObrisiDobavljac(param)); }
           set { _obrisidobavljaca = value; }
       }

       private ICommand _Update;

       public ICommand Update
       {
           get { return _Update = new RelayCommand(param => PopuniUpdate(param)); }
           set { _Update = value; }
       }

       private ICommand updatajDobavljaca;

       public ICommand UpdatajDobavljaca
       {
           get 
           {
               if (updatajDobavljaca == null)
                   updatajDobavljaca = new RelayCommand(param => IzvrsiUpdate(param), param => this.CanSaveEdit);
               return updatajDobavljaca;
           }
           set { updatajDobavljaca = value; }
       }
       private ICommand _UrediDobavljaca;

       public ICommand UrediDobavljaca1
       {
           get { return _UrediDobavljaca= new RelayCommand(param=> OtvoriEditDobavljac(param)); }
           set { _UrediDobavljaca = value; }
       }
       private ICommand zatvoriWindow;

       public ICommand ZatvoriWindow
       {
           get { return zatvoriWindow = new RelayCommand(param =>Close()); }
           set { zatvoriWindow = value; }
       }

       private ICommand _paging;

       public ICommand Paging
       {
           get { return _paging = new RelayCommand(param => FillGridLieferantPage(param)); }
           set { _paging = value; }
       }
       private ICommand _paging2;

       public ICommand Paging2
       {
           get { return _paging2 = new RelayCommand(param => FillGridLieferantPage2(param), param => this.CanNext); }
           set { _paging2 = value; }
       }

       private ICommand _pagingRikverc;

       public ICommand PagingRikverc
       {
           get { return _pagingRikverc = new RelayCommand(param => FillGridLieferantBack(param), param => this.CanLast); }
           set { _pagingRikverc = value; }
       }
       private ICommand _prebaciNaPrvi;

       public ICommand PrebaciNaPrvi
       {
           get { return _prebaciNaPrvi = new RelayCommand(param => FillGridLieferantFirst(param)); }
           set { _prebaciNaPrvi = value; }
       }

       private ICommand _prebaciNaZadnji;

       public ICommand PrebaciNaZadnji
       {
           get { return _prebaciNaZadnji = new RelayCommand(param => FillGridLieferantLast(param)); }
           set { _prebaciNaZadnji = value; }
       }
     
       #endregion

       #region Methods
       public void Paginacija(int stranica)
       {
           int neUzimati = 0;

           if (ListaDobavljaca1 != null)
           {
               int brojPrikaza = stranica * KolicinaDobavljaca;
               if (brojPrikaza > ListaDobavljaca1.Count())
                   brojPrikaza = ListaDobavljaca1.Count();
               int ostatak = brojPrikaza % KolicinaDobavljaca;
               if (ostatak != 0)
                   neUzimati = brojPrikaza - ostatak;
               else
                   neUzimati = brojPrikaza - KolicinaDobavljaca;
               var x = ListaDobavljaca1.Skip(neUzimati).Take(KolicinaDobavljaca);
               ListaPage1.Clear();
               ListaPage1 = new ObservableCollection<tbl_dobavljac>(x);

           }
           LieferantNr = client.LieferantNr();
           MaxStranica();
       }
       public void FillGridLieferantPage(object parameter)
       {
           Paginacija(BrojStranice);
           
       }
       public void FillGridLieferantPage2(object parameter)
       {
           BrojStranice++;
           Paginacija(BrojStranice);

       }

       public void FillGridLieferantBack(object parameter)
       {
           BrojStranice--;
           Paginacija(BrojStranice);
       }

       public void FillGridLieferantFirst(object parameter)
       {
           BrojStranice = 1;
           Paginacija(BrojStranice);
       }

       public void FillGridLieferantLast(object parameter)
       {
           if (ListaDobavljaca1 != null)
           {
               int a = ListaDobavljaca1.Count();
               double pozicija = Convert.ToDouble(a) / KolicinaDobavljaca;
               if (pozicija % 1 == 0)
                   BrojStranice = Convert.ToInt32(pozicija);
               else
                   BrojStranice = Convert.ToInt32(pozicija - ((pozicija * 10) % 10) / 10) + 1;
               Paginacija(BrojStranice);
           }
           
       }

       public void MaxStranica()
       {
           if (ListaDobavljaca1 != null)
           {
               int a = ListaDobavljaca1.Count();
               double pozicija = Convert.ToDouble(a) / KolicinaDobavljaca;
               if (pozicija % 1 == 0)
                   MaxStranica1 = Convert.ToInt32(pozicija);
               else
               {
                   MaxStranica1 = Convert.ToInt32(pozicija - ((pozicija * 10) % 10) / 10) + 1;
               }

           }
       }

       public void TraziDobavljaca(object parameter)
       {
           ListaDobavljaca1 = client.PretraziDobavljaca(Pretraga);
           Paginacija(BrojStranice);

       }
       public void Odustani(object parameter)
       {
           Titula = 0;
           Vorname = null;
           Name = null;
           Land = null;
           Adresse = null;
           Telefon = null;
           Telefon2 = null;
           Handy = null;
           Skype = null;
           Fax = null;
           Mail = null;
           Branche = null;
           Skonto = null;
           Tage = 0;
           Rabatt = 0;
           Bank = null;
           BLZ = null;
           KtoNr = null;
           BIC = null;
           IBAN = null;
           Kontoinhaber = null;
           Umsatz = 0;
           Zahlweise = null;
           Notiz = null;
           RadioFirma = false;
           RadioFrau = false;
           RadioHer = false;
           RadioSteuer1 = false;
           RadioSteuer2 = false;
           RadioSteuer3 = false;
       }
       public void InsertDobavljac(object parameter)
       {
           if (RadioHer == true) 
           { Titula = 0; }
           else if (RadioFrau == true)
           {
               Titula = 1;
           }
           else if (RadioFirma == true)
           {
               Titula = 2;
           }
           int porez=0;
           if (RadioSteuer1 == true)
           { porez = 0; }
           else if (RadioSteuer2 == true)
           {
               porez = 1;
           }
           else if (RadioSteuer3 == true)
           {
               porez = 2;
           }


           tbl_dobavljac dobavljac = new tbl_dobavljac();
           dobavljac.broj_dobavljaca = LieferantNr;
           dobavljac.tip = Titula;
           dobavljac.prezime = Vorname; ;
           dobavljac.ime = Name;
           dobavljac.zemlja = Land;
           dobavljac.adresa = Adresse;
           dobavljac.tel1 = Telefon;
           dobavljac.tel2 = Telefon2;
           dobavljac.mobitel = Handy;
           dobavljac.skype = Skype;
           dobavljac.fax = Fax;
           dobavljac.email = Mail;
           dobavljac.poslovanje = Branche;
           dobavljac.popust = Skonto;
           dobavljac.broj_dana = Convert.ToDecimal(Tage);
           dobavljac.rabat = Convert.ToDecimal(Rabatt);
           dobavljac.banka = Bank;
           dobavljac.blz = BLZ;
           dobavljac.KtoNr = KtoNr;
           dobavljac.bic = BIC;
           dobavljac.iban = IBAN;
           dobavljac.vlasnik_racuna = Kontoinhaber;
           dobavljac.promet = Convert.ToDecimal(Umsatz);
           dobavljac.nacin_placanja = Zahlweise;
           dobavljac.biljeska = Notiz;
           dobavljac.porez = porez;
           dobavljac.id_korisnik_FK = LogovaniKorisnik;



          
           client.UnesiDobavljaca(dobavljac);
           FillGridDobavljaca(parameter);
           Paginacija(BrojStranice);

           LieferantNr = client.LieferantNr();
           Titula=0; 
           Vorname=null;
           Name=null;
           Land=null;
           Adresse=null;
           Telefon=null;
           Telefon2=null;
           Handy=null;
           Skype=null;
           Fax=null;
           Mail=null; 
           Branche=null; 
           Skonto=null;
           Tage=0; 
           Rabatt=0; 
           Bank=null;
           BLZ=null;
           KtoNr = null;
           BIC=null;
           IBAN=null;
           Kontoinhaber=null;
           Umsatz=0;
           Zahlweise=null; 
           Notiz=null;
           RadioFirma = false;
           RadioFrau = false;
           RadioHer = false;
           RadioSteuer1=false;
           RadioSteuer2 = false;
           RadioSteuer3 = false;
       }
       public void FillGridDobavljaca(object parameter)
       {

           ListaDobavljaca1 = client.ListaDobavljaca();
       }

       public void ObrisiDobavljac(object parameter)
       {
           int br = Convert.ToInt32(SelektovaniDobavljac.broj_dobavljaca);
           client.ObrisiDobavljaca(br);
           FillGridDobavljaca(parameter);
           Paginacija(BrojStranice);

       }

       public void OtvoriEditDobavljac(object parameter)
       {

           LieferantWindowEdit LWE = new LieferantWindowEdit(this);
           LWE.Show();

       }
       public void Close()
       {
           CloseAction();
           
       }
       public void PopuniUpdate(object parameter)
       {
 
  
           VornameEdit = selektovaniDobavljac.prezime;
           NameEdit = SelektovaniDobavljac.ime;
           LandEdit = SelektovaniDobavljac.zemlja;
           AdresseEdit = SelektovaniDobavljac.adresa;
           TelefonEdit = SelektovaniDobavljac.tel1;
           Telefon2Edit = SelektovaniDobavljac.tel2;
           HandyEdit = SelektovaniDobavljac.mobitel;
           LieferantNrEdit = Convert.ToInt32(SelektovaniDobavljac.broj_dobavljaca);
           SkypeEdit = SelektovaniDobavljac.skype;
           FaxEdit = SelektovaniDobavljac.fax;
           MailEdit = SelektovaniDobavljac.email;
           BrancheEdit = SelektovaniDobavljac.poslovanje;
           SkontoEdit = SelektovaniDobavljac.popust;
           TageEdit = (float)SelektovaniDobavljac.broj_dana;
           RabattEdit = (float)SelektovaniDobavljac.rabat;
           BankEdit = SelektovaniDobavljac.banka;
           BLZEdit = SelektovaniDobavljac.blz;
           KtoNrEdit = SelektovaniDobavljac.KtoNr;
           BICEdit = SelektovaniDobavljac.bic;
           IBANEdit = SelektovaniDobavljac.iban;
           KontoinhaberEdit = SelektovaniDobavljac.vlasnik_racuna;
           UmsatzEdit = (float)SelektovaniDobavljac.promet;
           ZahlweiseEdit = SelektovaniDobavljac.nacin_placanja;
           NotizEdit = SelektovaniDobavljac.biljeska;
           if (Convert.ToInt32(SelektovaniDobavljac.tip) == 0)
           {
               RadioHerEdit = true;
           }
           else if (Convert.ToInt32(SelektovaniDobavljac.tip) == 1)
               RadioFrauEdit = true;
           else if (Convert.ToInt32(SelektovaniDobavljac.tip) == 2)
           {
               RadioFirmaEdit = true;
           }

           if (Convert.ToInt32(SelektovaniDobavljac.porez) == 0)
           {
               RadioSteuer1Edit = true;
           }
           else if (Convert.ToInt32(SelektovaniDobavljac.porez) == 1)
               RadioSteuer2Edit = true;
           else if (Convert.ToInt32(SelektovaniDobavljac.porez) == 2)
           {
               RadioSteuer3Edit = true;
           }
       }
       public void IzvrsiUpdate(object parameter)
       {
           tbl_dobavljac dobavljac = new tbl_dobavljac();
           dobavljac.id_dobavljac = SelektovaniDobavljac.id_dobavljac;
           dobavljac.broj_dobavljaca =LieferantNrEdit;

           //dobavljac.tip = TitulaEdit;

           dobavljac.prezime = VornameEdit;
           dobavljac.ime = NameEdit;
           dobavljac.zemlja = LandEdit;
           dobavljac.adresa = AdresseEdit;
           dobavljac.tel1 = TelefonEdit;
           dobavljac.tel2 = Telefon2Edit;
           dobavljac.mobitel = HandyEdit;
           dobavljac.skype = SkypeEdit;
           dobavljac.fax = FaxEdit;
           dobavljac.email = MailEdit;
           dobavljac.poslovanje = BrancheEdit;
           dobavljac.popust = SkontoEdit;
           dobavljac.broj_dana = Convert.ToDecimal(TageEdit);
           dobavljac.rabat = Convert.ToDecimal(RabattEdit);
           dobavljac.banka = BankEdit;
           dobavljac.blz = BLZEdit;
           dobavljac.KtoNr = KtoNrEdit;
           dobavljac.bic = BICEdit;
           dobavljac.iban = IBANEdit;
           dobavljac.vlasnik_racuna = KontoinhaberEdit;
           dobavljac.promet = Convert.ToDecimal(UmsatzEdit);
           dobavljac.nacin_placanja = ZahlweiseEdit;
           dobavljac.biljeska = NotizEdit;
           if (RadioSteuer1Edit == true)
           {
               dobavljac.porez = 0;
           }
           else if (RadioSteuer2Edit == true)
           {
               dobavljac.porez = 1;
           }
           else if (RadioSteuer3Edit == true)
           {
               dobavljac.porez = 2;
           }
           client.UpdateDobavljac(dobavljac);
           FillGridDobavljaca(parameter);
           ZatvoriWindow.Execute(this);
           CloseAction = null;
           Paginacija(BrojStranice);
          

         
           
         
       }

    
       #endregion

       #region INoftiyPropertyChanged Members
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
                
                if ("Vorname" == columnName)
                {
                    if (String.IsNullOrEmpty(Vorname))
                    {
                        Result = "Unesite ime.";
                    }
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
                else if ("Mail" == columnName)
                {
                    if (String.IsNullOrEmpty(Mail))
                        Result = "Unesite mail.";
                }

                if ("LieferantNrEdit" == columnName)
                {
                    if (LieferantNrEdit <= 0)
                        Result = "Broj mora biti veći od nule.";
                }
                else if ("VornameEdit" == columnName)
                {
                    if (String.IsNullOrEmpty(VornameEdit))
                    {
                        Result = "Unesite ime.";
                    }
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
                else if ("MailEdit" == columnName)
                {
                    if (String.IsNullOrEmpty(MailEdit))
                        Result = "Unesite mail.";
                }
                else if("IsValid" == columnName)
                {
                    Result = true.ToString();
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
           "Name",
           "Vorname",
           "Adresse",
           "Telefon",
           "Mail"
       };

       static readonly string[] ValidatedPropertiesEdit =
       {
           "NameEdit",
           "VornameEdit",
           "AdresseEdit",
           "TelefonEdit",
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
               case "MailEdit":
                   error = this["MailEdit"];
                   break;
               default:
                   error = null;
                   throw new Exception("Unexpected property being validated on Service");
           }
           return error;
       }
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
           switch(propertyName)
           {
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
               case "Mail":
                   error = this["Mail"];
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
       protected bool CanSave
       {
           get
           {
               return IsValid;
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
           get { throw new NotImplementedException();}
       }
        #endregion
    }

}
