using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pilkarze_MVVM.Model
{
    class Pilkarz
    {
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int Wiek { get; set; }
        public double Waga { get; set; }

        public Pilkarz() { }
        public Pilkarz(string imie, string nazwisko, int wiek, double waga)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Wiek = wiek;
            Waga = waga;
        }

        public override string ToString()
        {
            return $"{Imie} {Nazwisko} wiek: {Wiek} lat waga: {Waga} kg";
        }

    }
}
