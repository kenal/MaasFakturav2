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
using System.Windows.Media;
using WpfScheduler;
namespace Desktop.ViewModel
{
    //[TypeDescriptionProvider(typeof(KalendarRadnikWindowViewModelTypeDescriptionProvider))]
    public class KalendarRadnikWindowViewModel: INotifyPropertyChanged
    {
        #region Fields
        int _idKorisnik;        
        DateTime _datum;        
        DateTime _datum1;        
        int _tip;        
        bool _odobreno;        
        bool _pogledano;        
        string _text;
        private MassServisClient client = new MassServisClient();
        private ObservableCollection<tbl_korisnik> _listaKorisnika;
        private tbl_korisnik _selektovaniKorisnik;
        private List<int> _ListaSati = new List<int>() { 0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23 };        
        private List<int> _ListaMinuta = new List<int>() { 0, 10, 20, 30, 40, 50 };
        int _sat;        
        int _minuta;       
        int _sat1;        
        int _minuta1;
        bool radioTip1;       
        bool radioTip2;        
        bool radioTip3;
        
        #endregion

        public KalendarRadnikWindowViewModel()
        {
            _events = PuniListu();
        }

        #region Properties
        public int IdKorisnik
        {
            get { return _idKorisnik; }
            set 
            { 
                _idKorisnik = value;
                OnPropertyChanged("IdKorisnik");
            }
        }

        public DateTime Datum
        {
            get { return _datum; }
            set 
            { 
                _datum = value;
                OnPropertyChanged("Datum");
            }
        }

        public DateTime Datum1
        {
            get { return _datum1; }
            set 
            { 
                _datum1 = value;
                OnPropertyChanged("Datum1");
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

        public bool Odobreno
        {
            get { return _odobreno; }
            set 
            { 
                _odobreno = value;
                OnPropertyChanged("Odobreno");
            }
        }

        public bool Pogledano
        {
            get { return _pogledano; }
            set 
            { 
                _pogledano = value;
                OnPropertyChanged("Pogledano");
            }
        }

        public string Text
        {
            get { return _text; }
            set 
            { 
                _text = value;
                OnPropertyChanged("Text");
            }
        }

        public ObservableCollection<tbl_korisnik> ListaKorisnika
        {
            get { return _listaKorisnika; }
            set { _listaKorisnika = value; OnPropertyChanged("ListaKorisnika"); }
        }

        public tbl_korisnik SelektovaniKorisnik
        {
            get { return _selektovaniKorisnik; }
            set { _selektovaniKorisnik = value; OnPropertyChanged("SelektovaniKorisnik"); }
        }

        public List<int> ListaSati
        {
            get { return _ListaSati; }
            set 
            { 
                _ListaSati = value;
                OnPropertyChanged("ListaSati");
            }
        }
        public List<int> ListaMinuta
        {
            get { return _ListaMinuta; }
            set 
            { 
                _ListaMinuta = value;
                OnPropertyChanged("ListaMinuta");
            }
        }

        public int Sat
        {
            get { return _sat; }
            set
            {
                _sat = value;
                OnPropertyChanged("Sat");
            }
        }

        public int Minuta
        {
            get { return _minuta; }
            set
            {
                _minuta = value;
                OnPropertyChanged("Minuta");
            }
        }
        public int Sat1
        {
            get { return _sat1; }
            set
            {
                _sat1 = value;
                OnPropertyChanged("Sat1");
            }
        }

        public int Minuta1
        {
            get { return _minuta1; }
            set
            {
                _minuta1 = value;
                OnPropertyChanged("Minuta1");
            }
        }

        public bool RadioTip1
        {
            get { return radioTip1; }
            set
            {
                radioTip1 = value;
                Tip = 1;
                OnPropertyChanged("RadioTip1");
            }
        }

        public bool RadioTip2
        {
            get { return radioTip2; }
            set
            {
                radioTip2 = value;
                Tip = 2;
                OnPropertyChanged("RadioTip2");
            }
        }

        public bool RadioTip3
        {
            get { return radioTip3; }
            set
            {
                radioTip3 = value;
                Tip = 3;
                OnPropertyChanged("RadioTip3");
            }
        }
        #endregion

        #region ICommand
        private ICommand _otvoriDodaj;

        public ICommand OtvoriDodaj
        {
            get { return _otvoriDodaj = new RelayCommand(param => OtvoriDodajKalendar(param)); }
            set { _otvoriDodaj = value; }
        }

        private ICommand PopuniComboKorisnika;

        public ICommand PopuniComboKorisnika1
        {
            get { return PopuniComboKorisnika = new RelayCommand(param => popuniCombo(param)); }
            set { PopuniComboKorisnika = value; }
        }

        private ICommand _izvrsiUnos;

        public ICommand IzvrsiUnos
        {
            get { return _izvrsiUnos = new RelayCommand(param => Unos(param)); }
            set { _izvrsiUnos = value; }
        }
        #endregion

        #region Methods
        public void OtvoriDodajKalendar(object parameter)
        {
            KalendarRadnikDodajWindow kd = new KalendarRadnikDodajWindow(this);
            kd.Show();
        }

        public void popuniCombo(object parameter)
        {
            ListaKorisnika = client.ComboKorisnici();
            
        }

        public void Unos(object parameter)
        {
            
            CurrentEvent = new Event();
            if (RadioTip1 == true)
                CurrentEvent.Color = Brushes.Turquoise;
            else if (RadioTip2 == true)
                CurrentEvent.Color = Brushes.Chocolate;
            else if (RadioTip3 == true)
                CurrentEvent.Color = Brushes.Magenta;
            else
                CurrentEvent.Color = Brushes.Red;
            
            CurrentEvent.Start = Datum;
            CurrentEvent.End = Datum1;
            UnosUBazu();
            WpfScheduleEvents.Add(CurrentEvent);

            
        }

        public void UnosUBazu()
        {
            tbl_mit_kalendar EventKalendar = new tbl_mit_kalendar();
            
            TimeSpan ts = new TimeSpan(Sat, Minuta, 0);
            TimeSpan ts1 = new TimeSpan(Sat1, Minuta1, 0);
            Datum = Datum.Date + ts;
            Datum1 = Datum1.Date + ts1;
            EventKalendar.datum = Datum;
            EventKalendar.datu1 = Datum1;
            EventKalendar.tip = Tip;
            EventKalendar.biljeska = Text;            
            client.UnesiEventMitarbeiter(EventKalendar, SelektovaniKorisnik.id_korisnik);
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

        #region EventsRegion
        public TimeSpan StartJourney
        {
            get
            {
                return TimeSpan.FromHours(7);
            }
        }

        public TimeSpan EndJourney
        {
            get
            {
                return TimeSpan.FromHours(19);
            }
        }

        private ObservableCollection<Event> _events;
        public ObservableCollection<Event> WpfScheduleEvents
        {
            get
            {
                if (_events == null)
                    _events = PuniListu();
                return _events;
            }
            set
            {
                if (_events != value)
                {
                    _events = value;
                    OnPropertyChanged("WpfScheduleEvents");
                }

            }
        }

        public ObservableCollection<Event> PuniListu()
        {
            ObservableCollection<Event> Lista = new ObservableCollection<Event>();
            foreach (var p in client.ListaEventaMitarbeiter())
            {
                Event e = new Event();
                e.Start = Convert.ToDateTime(p.datum);
                e.End = Convert.ToDateTime(p.datu1);
                e.Subject = p.biljeska;
                e.Description = p.id_kalendar + " " + p.id_korisnik_FK;
                if (p.tip == 1)
                    e.Color = Brushes.Turquoise;
                else if (p.tip == 2)
                    e.Color = Brushes.Chocolate;
                else if(p.tip == 3)
                    e.Color = Brushes.Magenta;
                Lista.Add(e);
            }
            return Lista;
        }

        #region CurrentEvent
        private Event _currentEvent;
        public Event CurrentEvent
        {
            get { return _currentEvent; }
            set
            {
                if (_currentEvent == value) return;
                _currentEvent = value;
                OnPropertyChanged("CurrentEvent");
            }
        }
        #endregion

        #region IsOpen
        private bool _isOpen;

        public bool IsOpen
        {
            get { return _isOpen; }
            set 
            {
                if (_isOpen == value) return;
                _isOpen = value;
                OnPropertyChanged("IsOpen");
            }
        }
        #endregion

        #region Commands
        RelayCommand _EditEventCommand;
        public ICommand EditEventCommand
        {
            get
            {
                if (_EditEventCommand == null) _EditEventCommand = new RelayCommand(EditEvent);
                return _EditEventCommand;
            }
        }

        private void EditEvent(object param)
        {
            WpfScheduler.Event e = param as WpfScheduler.Event;
            CurrentEvent = WpfScheduleEvents.Single(ev => ev.Id == e.Id);
            IsOpen = true;
        }
        #endregion

        #region NewEventCommand
        RelayCommand _NewEventCommand;

        public ICommand NewEventCommand
        {
            get
            {
                if (_NewEventCommand == null) _NewEventCommand = new RelayCommand(NewEvent);
                return _NewEventCommand;
            }
        }

        private void NewEvent(object param)
        {
            DateTime date = (DateTime) param;
            Datum = date;
            Datum1 = date.AddHours(1);
            
            KalendarRadnikDodajWindow krdw = new KalendarRadnikDodajWindow(this);
            krdw.Show();
            
            

        }
        #endregion

        #region CancelEditCommand
        RelayCommand _CancelEditCommand;
        public ICommand CancelEditCommand
        {
            get
            {
                if (_CancelEditCommand == null) _CancelEditCommand = new RelayCommand(param => this.CancelEdit());
                return _CancelEditCommand;
            }
        }

        private void CancelEdit()
        {
            if (!WpfScheduleEvents.Contains(CurrentEvent))
                CurrentEvent = null;
            IsOpen = false;
        }
        #endregion

        #region SaveEventCommand
        RelayCommand _SaveEventCommand;
        public ICommand SaveEventCommand
        {
            get
            {
                if (_SaveEventCommand == null) _SaveEventCommand = new RelayCommand(param => this.SaveEvent());
                return _SaveEventCommand;
            }
        }

        private void SaveEvent()
        {
            if (!WpfScheduleEvents.Contains(CurrentEvent))
            {
                WpfScheduleEvents.Add(CurrentEvent);
            }

            IsOpen = false;
            OnPropertyChanged("WpfScheduleEvents");
        }

        
        #endregion

        //#region ViewModelRefresh
        //private static string ErrorViewModelTypeHasToMatch = "The type of the new View Model has to match that of the old View Model.";

        //private Func<object> creatorMethod;

        //public KalendarRadnikWindowViewModel(object innerViewModel, Func<object> creatorMethod = null)
        //{
        //    this.InnerViewModel = innerViewModel;
        //    this.creatorMethod = creatorMethod;
        //}

        //public KalendarRadnikWindowViewModel(Func<object> creatorMethod)
        //{
        //    this.InnerViewModel = (this.creatorMethod = creatorMethod)();            
        //}

        //public KalendarRadnikWindowViewModel(Type innerViewModelType)
        //{
        //    this.InnerViewModel = Activator.CreateInstance(innerViewModelType);
        //}

        //internal object InnerViewModel { get; private set; }
        //#endregion
        #endregion
    }
}
