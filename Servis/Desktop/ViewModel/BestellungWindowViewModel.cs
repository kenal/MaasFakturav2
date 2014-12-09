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
    public class BestellungWindowViewModel : INotifyPropertyChanged
    {
        #region Fields
        MassServisClient client = new MassServisClient();
        ObservableCollection<tbl_dobavljac> ListaDobavljaca;
        tbl_dobavljac _selektovaniDobavljac;
        #endregion

        #region Properties
        public ObservableCollection<tbl_dobavljac> ListaDobavljaca1
        {
            get { return ListaDobavljaca; }
            set 
            { 
                ListaDobavljaca = value;
                OnPropertyChanged("ListaDobavljaca1");
            }
        }

        public tbl_dobavljac SelektovaniDobavljac
        {
            get { return _selektovaniDobavljac; }
            set 
            { 
                _selektovaniDobavljac = value;
                OnPropertyChanged("SelektovaniDobavljac");
            }
        }
        #endregion

        #region ICommand
        private ICommand _puniCombo;

        public ICommand PuniCombo
        {
            get { return _puniCombo = new RelayCommand(param => PuniListu(param)); }
            set { _puniCombo = value; }
        }
        #endregion

        #region Methods
        public void PuniListu(object parameter)
        {
            ListaDobavljaca1 = client.ListaDobavljaca();
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
