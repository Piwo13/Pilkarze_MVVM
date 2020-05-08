using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Text.Json;
using System.IO;

namespace Pilkarze_MVVM.Model
{
    class Pilkarze
    {
        public ObservableCollection<Pilkarz> ListaPilkarzy { get; set; } = new ObservableCollection<Pilkarz>();

        public Pilkarze()
        {
            if (File.Exists("Pilkarze.json"))
            {
                byte[] json = File.ReadAllBytes("Pilkarze.json");
                var readOnlySpan = new ReadOnlySpan<byte>(json);
                ListaPilkarzy = JsonSerializer.Deserialize<ObservableCollection<Pilkarz>>(readOnlySpan);
            }
        }

        public void DodajPilkarza(string imie, string nazwisko,int wiek,double waga)
        {
            ListaPilkarzy.Add(new Pilkarz(imie, nazwisko, wiek, waga));
        }

        public void EdytujPilkarza(string imie,string nazwisko,int wiek,double waga,int id)
        {
            ListaPilkarzy[id] = new Pilkarz(imie, nazwisko, wiek, waga);
        }

        public void UsunPilkarza(int id)
        {
            ListaPilkarzy.RemoveAt(id);
        }

        public void Zapis()
        {
            byte[] json = JsonSerializer.SerializeToUtf8Bytes(ListaPilkarzy);
            File.WriteAllBytes("Pilkarze.json", json);
        }
    }
}
