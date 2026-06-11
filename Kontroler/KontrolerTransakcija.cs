using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal_Finance_Tracker.Modeli;

namespace Personal_Finance_Tracker.Kontroler
{
    class KontrolerTransakcija
    {
        private List<Transakcija> transakcije;

        public KontrolerTransakcija()
        {
            transakcije = new List<Transakcija>();

            transakcije.Add(new Transakcija { Id=1,Naziv="Plata",Iznos=120000,Datum=DateTime.Today,Kategorija="Prihod",Tip="Prihod"});
            transakcije.Add(new Transakcija { Id = 2, Naziv = "Lidl", Iznos = 3500, Datum = DateTime.Today.AddDays(-1), Kategorija = "Hrana", Tip = "Rashod" });
            transakcije.Add(new Transakcija { Id = 3, Naziv = "Gorivo", Iznos = 4000, Datum = DateTime.Today.AddDays(-2), Kategorija = "Prevoz", Tip = "Rashod" });
        }

        public List<Transakcija> VratiTransakcije()
        {
            return transakcije;
        }

        public void Dodaj(Transakcija t)
        {
            transakcije.Add(t);
        }


    }
}
