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
using System.Data;
using System.Windows;
using Mass.Data;

namespace Desktop.ViewModel
{
    public class AdminWindowViewModel : INotifyPropertyChanged, IDataErrorInfo
    {

        #region private fields
        //Insert User
        private string _name;
        private string _lastName;
        private string _email;
        private string _telefon;
        private string _username;
        private string _password;
        private int _userType;
        private DateTime _licence = DateTime.Now;
        private bool _radAdmin;
        private bool _radMitarbeiter;
        private bool _radSekraterin;
        private bool _radTechniker;
        private bool _radWerks;
        //Edit User
        private string _nameEdit;
        private string _lastNameEdit;
        private string _emailEdit;
        private string _telefonEdit;
        private string _usernameEdit;
        private string _passwordEdit;
        private int _userTypeEdit;
        private DateTime _licenceEdit = DateTime.Now;
        private bool _radAdminEdit;
        private bool _radMitarbeiterEdit;
        private bool _radSekraterinEdit;
        private bool _radTechnikerEdit;
        private bool _radWerksEdit;
        private string _pozadinaPocetna;
        ObservableCollection<tbl_greske> _listaBugova;  
        private p_get_User_ViewResult _selektovaniUser;
        //private ObservableCollection<tbl_korisnik> _listaKorisnika;
        private ObservableCollection<p_get_User_ViewResult> _listaKorisnika;
        private MassServisClient client = new MassServisClient();
        //Send Bug
        private string _sendBugValue;
        private int _idUserBug;
        private string _sadrzajBug;
        private bool _statusBug;
        private string _datumBug;
        tbl_greske _selektovaniBug = new tbl_greske();

        public tbl_greske SelektovaniBug
        {
            get { return _selektovaniBug; }
            set 
            { 
                _selektovaniBug = value;
                OnPropertyChanged("SelektovaniBug");
            }
        }
        #endregion     

        #region Properties

        public Action CloseAction { get; set; }
        public ObservableCollection<p_get_User_ViewResult> ListaKorisnika
        {
            get { return _listaKorisnika; }
            set { _listaKorisnika = value; OnPropertyChanged("ListaKorisnika"); }
        }
        public ObservableCollection<tbl_greske> ListaBugova
        {
            get { return _listaBugova; }
            set
            {
                _listaBugova = value;
                OnPropertyChanged("ListaBugova");
            }
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; OnPropertyChanged("Name"); }
        }
        public string LastName
        {
            get { return _lastName; }
            set { _lastName = value; OnPropertyChanged("LastName"); }
        }
        public string Email
        {
            get { return _email; }
            set { _email = value; OnPropertyChanged("Email"); }
        }
        public string Telefon
        {
            get { return _telefon; }
            set { _telefon = value; OnPropertyChanged("Telefon"); }
        }
        public string Username
        {
            get { return _username; }
            set { _username = value; OnPropertyChanged("Username"); }
        }
        public string Password
        {
            get { return _password; }
            set { _password = value; OnPropertyChanged("Password"); }
        }
        public int UserType
        {
            get { return _userType; }
            set { _userType = value; OnPropertyChanged("UserType"); }
        }
        public DateTime Licence
        {
            get { return _licence; }
            set { _licence = value; OnPropertyChanged("Licence"); }
        }
        public bool RadAdmin
        {
            get { return _radAdmin; }
            set { _radAdmin = value; OnPropertyChanged("RadAdmin"); }
        }
        public bool RadMit
        {
            get { return _radMitarbeiter; }
            set { _radMitarbeiter = value; OnPropertyChanged("RadMit"); }
        }
        public bool RadSek
        {
            get { return _radSekraterin; }
            set { _radSekraterin = value; OnPropertyChanged("RadSek"); }
        }
        public bool RadTech
        {
            get { return _radTechniker; }
            set { _radTechniker = value; OnPropertyChanged("RadTech"); }
        }
        public bool RadWerk
        {
            get { return _radWerks; }
            set { _radWerks = value; OnPropertyChanged("RadWerk"); }
        }

        public string NameEdit
        {
            get { return _nameEdit; }
            set { _nameEdit = value; OnPropertyChanged("NameEdit"); }
        }
        public string LastNameEdit
        {
            get { return _lastNameEdit; }
            set { _lastNameEdit = value; OnPropertyChanged("LastNameEdit"); }
        }
        public string EmailEdit
        {
            get { return _emailEdit; }
            set { _emailEdit = value; OnPropertyChanged("EmailEdit"); }
        }
        public string TelefonEdit
        {
            get { return _telefonEdit; }
            set { _telefonEdit = value; OnPropertyChanged("TelefonEdit"); }
        }

        public string UsernameEdit
        {
            get { return _usernameEdit; }
            set { _usernameEdit = value; OnPropertyChanged("UsernameEdit"); }
        }
        public string PasswordEdit
        {
            get { return _passwordEdit; }
            set { _passwordEdit = value; OnPropertyChanged("PasswordEdit"); }
        }
        public int UserTypeEdit
        {
            get { return _userTypeEdit; }
            set { _userTypeEdit = value; OnPropertyChanged("UserTypeEdit"); }
        }
        public DateTime LicenceEdit
        {
            get { return _licenceEdit; }
            set { _licenceEdit = value; OnPropertyChanged("LicenceEdit"); }
        }
        public bool RadAdminEdit
        {
            get { return _radAdminEdit; }
            set { _radAdminEdit = value; OnPropertyChanged("RadAdminEdit"); }
        }
        public bool RadMitEdit
        {
            get { return _radMitarbeiterEdit; }
            set { _radMitarbeiterEdit = value; OnPropertyChanged("RadMitEdit"); }
        }
        public bool RadSekEdit
        {
            get { return _radSekraterinEdit; }
            set { _radSekraterinEdit = value; OnPropertyChanged("RadSekEdit"); }
        }
        public bool RadTechEdit
        {
            get { return _radTechnikerEdit; }
            set { _radTechnikerEdit = value; OnPropertyChanged("RadTechEdit"); }
        }
        public bool RadWerkEdit
        {
            get { return _radWerksEdit; }
            set { _radWerksEdit = value; OnPropertyChanged("RadWerkEdit"); }
        }
        public p_get_User_ViewResult SelektovaniUser
        {
            get { return _selektovaniUser; }
            set { _selektovaniUser = value; OnPropertyChanged("SelektovaniUser"); }
        }
        public string PozadinaPocetna
        {
            get { return _pozadinaPocetna; }
            set
            {
                _pozadinaPocetna = value;
                OnPropertyChanged("PozadinaPocetna");
            }
        }
        public string SendBugValue
        {
            get { return _sendBugValue; }
            set { _sendBugValue = value; OnPropertyChanged("SendBugValue"); }
        }

        public int IdUserBug
        {
            get { return _idUserBug; }
            set { _idUserBug = value; OnPropertyChanged("idUser"); }
        }
        public string SadrzajBug
        {
            get { return _sadrzajBug; }
            set { _sadrzajBug = value; OnPropertyChanged("SadrzajBug"); }
        }
        public bool StatusBug
        {
            get { return _statusBug; }
            set { _statusBug = value; OnPropertyChanged("StatusBug"); }
        }
        public string DatumBug
        {
            get { return _datumBug; }
            set { _datumBug = value; OnPropertyChanged("DatumBug"); }
        }
        #endregion

        #region Methods
        public void InsertUser(object parameter)
        {
            UserType = -1;
            if (RadAdmin == true) { UserType = 0; }
            else if (RadMit == true) { UserType = 1; }
            else if (RadSek == true) { UserType = 2; }
            else if (RadTech == true) { UserType = 3; }
            else if (RadWerk == true) { UserType = 4; }

            string datum = Licence.ToString("yyyy-MM-dd");

            if (Name != null && LastName != null && Email != null && Telefon != null && Username != null && Password != null && UserType != -1)
            {
                client.UnesiUsera(Name, LastName, Email, Telefon, true, null, Username, Password, UserType, false, datum);
                ListaKorisnika = client.ListaUserView();
            }
        }

        public void SendBug(object parameter)
        {
            string bugText = SendBugValue;
            DateTime dateNow = DateTime.Now;
            string date = dateNow.ToString("yyyy-mm-dd H:mm:ss");

            int idUser = Sesija.Id_korisnik;
            client.unesiBug(bugText, idUser, false, date);

        }

        public void InsertUserEdit(object parameter) 
        {
            int Uid = SelektovaniUser.id_korisnik;
            if (RadAdminEdit == true) { UserTypeEdit = 0; }
            else if (RadMitEdit == true) { UserTypeEdit = 1; }
            else if (RadSekEdit == true) { UserTypeEdit = 2; }
            else if (RadTechEdit == true) { UserTypeEdit = 3; }
            else if (RadWerkEdit == true) { UserTypeEdit = 4; }

            string datum = LicenceEdit.ToString("yyyy-MM-dd");

            if (NameEdit != null && LastNameEdit != null && EmailEdit != null && TelefonEdit != null && UsernameEdit != null && PasswordEdit != null && UserTypeEdit != -1)
            {
                client.EditujUsera(Uid, NameEdit, LastNameEdit, EmailEdit, TelefonEdit, true, null, UsernameEdit, PasswordEdit, UserTypeEdit, false, datum);
                ListaKorisnika = client.ListaUserView();
            }
        }

        public void PopuniEditUser(object parameter)
        {
            NameEdit = SelektovaniUser.ime;
            LastNameEdit = SelektovaniUser.prezime;
            EmailEdit = SelektovaniUser.mail;
            TelefonEdit = SelektovaniUser.telefon;
            UsernameEdit = SelektovaniUser.username;
            PasswordEdit = SelektovaniUser.password;
            if(SelektovaniUser.tip == 0){RadAdminEdit = true;}
            else if (SelektovaniUser.tip == 1) { RadMitEdit = true; }
            else if (SelektovaniUser.tip == 2) { RadSekEdit = true; }
            else if (SelektovaniUser.tip == 3) { RadTechEdit = true; }
            else if (SelektovaniUser.tip == 4) { RadWerkEdit = true; }
            LicenceEdit = SelektovaniUser.datum;
        }

        public void BrisanjeUsera(object parameter)
        {

            if (MessageBox.Show("Sind sie sicher?", "Benutzer Löschen", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                int idU = SelektovaniUser.id_korisnik;
                client.DeleteUser(idU);
                ListaKorisnika = client.ListaUserView();
            }
        }

        public void BrisanjeBuga(object parameter)
        {
            if (MessageBox.Show("Sind sie sicher?", "Bug Löschen", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                string datum = SelektovaniBug.datum;
                client.DeleteBug(datum);
                ListaBugova = client.ListaBugova();
            }
        }

        public void Close()
        {
            CloseAction();
        }

        public void EditUser(object parameter)
        {
            AdminEditWindow AWE = new AdminEditWindow(this);
            AWE.Show();
        }

        public void PromPocetna(object parameter)
        {
            if (MessageBox.Show("Sind sie sicher?", "Benutzer ändern", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (SelektovaniUser.pocetna == true)
                {
                    //Prvi parametar određuje tip metode. Jer je metoda napravljena da mjenja ili aktivan ili početna u zavisnosti od potrebe
                    client.changeUserPocetnaOrAktivan(1, SelektovaniUser.id_korisnik, false);

                }
                else if (SelektovaniUser.pocetna == false)
                {
                    //Prvi parametar određuje tip metode. Jer je metoda napravljena da mjenja ili aktivan ili početna u zavisnosti od potrebe
                    client.changeUserPocetnaOrAktivan(1, SelektovaniUser.id_korisnik, true);

                }
                PopuniGridKorisnika(parameter);
            }
           
        }

        public void PromBug(object parameter)
        {
            if (MessageBox.Show("Sind sie sicher?", "Bug ändern", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                string datumBug = SelektovaniBug.datum;

                if (SelektovaniBug.status == true)
                {
                    client.changeBugStatus(datumBug, false);
                }
                else if (SelektovaniBug.status == false)
                {
                    client.changeBugStatus(datumBug, true);

                }
                ListaBugova = client.ListaBugova();
            }
        }

        public void PromAktivan(object parameter) 
        {
            if (MessageBox.Show("Sind sie sicher?", "Benutzer ändern", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                if (SelektovaniUser.aktivan == true)
                {
                    client.changeUserPocetnaOrAktivan(2, SelektovaniUser.id_korisnik, false);
                }
                else if (SelektovaniUser.aktivan == false)
                {
                    client.changeUserPocetnaOrAktivan(2, SelektovaniUser.id_korisnik, true);
                }
                PopuniGridKorisnika(parameter);
            }
        }


        public void PopuniGridKorisnika(object parameter)
        {
            ListaKorisnika = client.ListaUserView();
        }

        public void PopuniGridBud(object parameter) 
        {
            ListaBugova = client.ListaBugova();
        }

        public void OdustaniUnos(object parameter)
        {
            Name = null;
            LastName = null;
            Email = null;
            Telefon = null;
            Username = null;
            Password = null;

        }
        #endregion

        #region ICommand User

        private ICommand _otvoriEditUser;

        public ICommand OtvoriEditUser
        {
            get { return _otvoriEditUser = new RelayCommand(param => EditUser(param)); }
            set { _otvoriEditUser = value; }
        }

        private ICommand _promjeniPocetna;

        public ICommand PromjeniPocetna
        {
            get { return _promjeniPocetna = new RelayCommand(param => PromPocetna(param)); }
            set { _promjeniPocetna = value; }
        }

        private ICommand _promjeniAktivan;

        public ICommand PromjeniAktivan
        {
            get { return _promjeniAktivan = new RelayCommand(param => PromAktivan(param)); }
            set { _promjeniAktivan = value; }
        }

        private ICommand _promjeniBug;

        public ICommand PromjeniBug
        {
            get { return _promjeniBug = new RelayCommand(param => PromBug(param)); }
            set { _promjeniBug = value; }
        }

        private ICommand _popuniEditWindow;

        public ICommand PopuniEditWindow
        {
            get { return _popuniEditWindow = new RelayCommand(param => PopuniEditUser(param)); }
            set { _popuniEditWindow = value; }
        }

        private ICommand _Unesi;

        public ICommand Unesi
        {
            get { return _Unesi = new RelayCommand(param => InsertUser(param), param => this.CanSave); }
            set { _Unesi = value; }
        }

        private ICommand _PosaljiBug;

        public ICommand PosaljiBug
        {
            get { return _PosaljiBug = new RelayCommand(param => SendBug(param)); }
            set { _PosaljiBug = value; }
        }

        private ICommand _PopuniGridBug;

        public ICommand PopuniGridBug
        {
            get { return _PopuniGridBug = new RelayCommand(param => PopuniGridBud(param)); }
            set { _PopuniGridBug = value; }
        }

        private ICommand _UnesiEdit;

        public ICommand UnesiEdit
        {
            get { return _UnesiEdit = new RelayCommand(param => InsertUserEdit(param), param => this.CanSaveEdit); }
            set { _UnesiEdit = value; }
        }

        private ICommand _popuniGridListomKorisnika;

        public ICommand PopuniGridListomKorisnika
        {
            get { return _popuniGridListomKorisnika = new RelayCommand(param => PopuniGridKorisnika(param)); }
            set { _popuniGridListomKorisnika = value; }
        }

        private ICommand _obrisiUsera;

        public ICommand ObrisiUsera
        {
            get { return _obrisiUsera = new RelayCommand(param => BrisanjeUsera(param)); }
            set { _obrisiUsera = value; }
        }
        private ICommand _obrisiBug;

        public ICommand ObrisiBug
        {
            get { return _obrisiBug = new RelayCommand(param => BrisanjeBuga(param)); }
            set { _obrisiBug = value; }
        }

        private ICommand _odustani;

        public ICommand Odustani
        {
            get { return _odustani = new RelayCommand(param => OdustaniUnos(param)); }
            set { _odustani = value; }
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
                if("Name" == columnName)
                {
                    if (String.IsNullOrEmpty(Name)) 
                        Result = "Bitte vorname eingeben.";
                }
                else if ("LastName" == columnName)
                {
                    if (String.IsNullOrEmpty(LastName))
                        Result = "Bite name eingeben.";
                }
                else if ("Username" == columnName)
                {
                    if (String.IsNullOrEmpty(Username))
                        Result = "Bitte benutzer name eingeben.";
                }
                else if ("Password" == columnName)
                {
                    if (String.IsNullOrEmpty(Password))
                        Result = "Bitte passwort eingeben.";
                }
                else if("Email" == columnName)
                {
                    if (String.IsNullOrEmpty(Email))
                        Result = "Bitte mail eingeben.";
                }
                else if ("Telefon" == columnName)
                {
                    if (String.IsNullOrEmpty(Telefon))
                        Result = "Bitte telefon eingeben.";
                }

                else if("IsValid" == columnName)
                {
                    Result = true.ToString();
                }

                if ("NameEdit" == columnName)
                {
                    if (String.IsNullOrEmpty(NameEdit))
                        Result = "Bitte vorname eingeben.";
                }
                else if ("LastNameEdit" == columnName)
                {
                    if (String.IsNullOrEmpty(LastNameEdit))
                        Result = "Bite name eingeben.";
                }
                else if ("UsernameEdit" == columnName)
                {
                    if (String.IsNullOrEmpty(UsernameEdit))
                        Result = "Bitte benutzer name eingeben.";
                }
                else if ("PasswordEdit" == columnName)
                {
                    if (String.IsNullOrEmpty(PasswordEdit))
                        Result = "Bitte passwort eingeben.";
                }
                else if ("EmailEdit" == columnName)
                {
                    if (String.IsNullOrEmpty(EmailEdit))
                        Result = "Bitte mail eingeben.";
                }
                else if ("TelefonEdit" == columnName)
                {
                    if (String.IsNullOrEmpty(TelefonEdit))
                        Result = "Bitte telefon eingeben.";
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
            "LastName",
            "Username",
            "Password",
            "Email",
            "Telefon"
        };

        public bool IsValid
        {
            get
            {
                foreach (string property in ValidatedProperties)
                {
                    if (GetValidationError(property) != null)
                        return false;
                }
                return true;
            }

            set
            {
                IsValid = value;
            }
        }

        private string GetValidationError(string propertyName)
        {
            string error = null;
            switch(propertyName)
            {
                case "Name":
                    error = this["Name"];
                    break;
                case "LastName":
                    error = this["LastName"];
                    break;
                case "Username":
                    error = this["Username"];
                    break;
                case "Password":
                    error = this["Password"];
                    break;
                case "Email":
                    error = this["Email"];
                    break;
                case "Telefon":
                    error = this["Telefon"];
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
            "NameEdit",
            "LastNameEdit",
            "UsernameEdit",
            "PasswordEdit",
            "EmailEdit",
            "TelefonEdit"
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
                case "NameEdit":
                    error = this["NameEdit"];
                    break;
                case "LastNameEdit":
                    error = this["LastNameEdit"];
                    break;
                case "UsernameEdit":
                    error = this["UsernameEdit"];
                    break;
                case "PasswordEdit":
                    error = this["PasswordEdit"];
                    break;
                case "EmailEdit":
                    error = this["EmailEdit"];
                    break;
                case "TelefonEdit":
                    error = this["TelefonEdit"];
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

        

        public string Error
        {
            get { throw new NotImplementedException(); }
        }
        #endregion
    }
}
