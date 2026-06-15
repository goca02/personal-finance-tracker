using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Tracker.Modeli
{
    public class Transakcija
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public decimal Iznos { get; set; }
        public DateTime Datum { get; set; }
        public string Kategorija { get; set; }
        public string Tip { get; set; }

        

    }
}
