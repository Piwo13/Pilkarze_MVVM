using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Pilkarze_MVVM.Model;
using Pilkarze_MVVM.ViewModel.BaseClass;


namespace Pilkarze_MVVM.ViewModel
{
    internal class PilkarzeViewModel : ViewModelBase
    {
        private Pilkarze _pilkarze = new Pilkarze();

        public ObservableCollection<Pilkarz> ListaPilkarzy
        {
            get => _pilkarze.ListaPilkarzy;
            set
            {
                _pilkarze.ListaPilkarzy = value;
                onPropertyChanged(nameof(ListaPilkarzy));
            }
        }

        private string _imie = "Wprowadź imię";
        public string Imie
        {
            get => _imie;
            set
            {
                _imie = value;
                onPropertyChanged(nameof(Imie));
            }
        }
        private string _nazwisko = "Wprowadź nazwisko";
        public string Nazwisko
        {
            get => _nazwisko;
            set
            {
                _nazwisko = value;
                onPropertyChanged(nameof(Nazwisko));
            }
        }

        private int _wiek = 15;
        public int Wiek
        {
            get => _wiek;
            set
            {
                _wiek = value;
                onPropertyChanged(nameof(Wiek));
            }
        }

        private double _waga = 55;
        public double Waga
        {
            get => _waga;
            set
            {
                _waga = value;
                onPropertyChanged(nameof(Waga));
            }
        }

        private int _id = -1;
        public int Id
        {
            get => _id;
            set
            {
                _id = value;
                onPropertyChanged(nameof(Id));
            }
        }

        public IEnumerable<string> WiekLista
        {
            get
            {
                for(int i = 15; i<= 50; i++)
                {
                    yield return i.ToString();
                }
            }
        }

        private ICommand _dodaj;
        public ICommand Dodaj
        {
            get
            {
                if (_dodaj == null)
                {
                    _dodaj = new RelayCommand(x => { _pilkarze.DodajPilkarza(_imie, _nazwisko, _wiek, _waga); Reset(); }, x => (!string.IsNullOrEmpty(_imie) && !_imie.Equals("Wprowadź imię") && !string.IsNullOrEmpty(_nazwisko) && !_nazwisko.Equals("Wprowadź nazwisko")));
                }
                return _dodaj;
            }
        }

        private ICommand _edytuj;
        public ICommand Edytuj
        {
            get
            {
                if (_edytuj == null)
                {
                    _edytuj=new RelayCommand(x => { _pilkarze.EdytujPilkarza(_imie, _nazwisko, _wiek, _waga, _id);Reset(); }, x => (!string.IsNullOrEmpty(_imie) && !_imie.Equals("Wprowadź imię") && !string.IsNullOrEmpty(_nazwisko) && !_nazwisko.Equals("Wprowadź nazwisko") &&_id>=0));
                }
                return _edytuj;
            }
        }

        private ICommand _usun;
        public ICommand Usuń
        {
            get
            {
                if (_usun == null)
                {
                    _usun = new RelayCommand(x => { _pilkarze.UsunPilkarza(_id); Reset(); }, x => _id >= 0);
                }
                return _usun;
            }
        }

        private ICommand _wyczyscimie;
        public ICommand WyczyscImie
        {
            get
            {
                if (_wyczyscimie == null)
                {
                    _wyczyscimie = new RelayCommand(x => { if (Imie.Equals("Wprowadź imię")) Imie = ""; });
                }
                return _wyczyscimie;
            }
        }

        private ICommand _wyczyscnazwisko;
        public ICommand WyczyscNazwisko
        {
            get
            {
                if (_wyczyscnazwisko == null)
                {
                    _wyczyscnazwisko = new RelayCommand(x => { if (Nazwisko.Equals("Wprowadź nazwisko")) Nazwisko = ""; });
                }
                return _wyczyscnazwisko;
            }
        }

        private ICommand _zapis;
        public ICommand Zapis
        {
            get
            {
                if (_zapis == null)
                {
                    _zapis = new RelayCommand(x => _pilkarze.Zapis());
                }
                return _zapis;
            }
        }
        private ICommand _wczyt;
        public ICommand Wczyt
        {
            get
            {
                if (_wczyt == null)
                {
                    _wczyt=new RelayCommand(x => { Imie = ListaPilkarzy[Id].Imie;Nazwisko = ListaPilkarzy[Id].Nazwisko;Wiek = ListaPilkarzy[Id].Wiek;Waga = ListaPilkarzy[Id].Waga; },x=>_id>=0);
                }
                return _wczyt;
            }
        }

        private void Reset()
        {
            Imie = "Wprowadź imię";
            Nazwisko = "Wprowadź nazwisko";
            Wiek = 15;
            Waga = 55;
            Id = -1;
        }
    }
}
