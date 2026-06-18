using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal_Finance_Tracker.Modeli;
using Personal_Finance_Tracker.Baza;

namespace Personal_Finance_Tracker.Kontroler
{
    class KontrolerTransakcija
    {
        

        public KontrolerTransakcija()
        {
            
        }

        public List<Transakcija> VratiTransakcije()
        {
            return DatabaseManager.GetInstance().VratiSve();
        }

        public void Dodaj(Transakcija t)
        {
            DatabaseManager.GetInstance().Dodaj(t);
        }

        public void Obrisi(Transakcija t)
        {
            DatabaseManager.GetInstance().Obrisi(t);
        }

        public void Izmeni(Transakcija t)
        {
            DatabaseManager.GetInstance().Izmeni(t);
        }


    }
}
