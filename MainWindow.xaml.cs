using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Personal_Finance_Tracker.Kontroler;
using Personal_Finance_Tracker.Modeli;

namespace Personal_Finance_Tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private KontrolerTransakcija kontroler;
        public MainWindow()
        {
            InitializeComponent();

            kontroler = new KontrolerTransakcija();
            dgTransakcije.ItemsSource = kontroler.VratiTransakcije();
            lblIznos.Content = IzracunajIznos();
        }

        private string IzracunajIznos()
        {
            decimal iznos=0;
            List<Transakcija> t = kontroler.VratiTransakcije();
            for(int i = 0; i < t.Count; i++) {
                if (t[i].Tip == "Prihod")
                {
                    iznos += t[i].Iznos;
                }
                else
                {
                    iznos -= t[i].Iznos;
                }
            }
            return iznos + " RSD";
        }
    }
}
