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
using Personal_Finance_Tracker.Baza;

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
            DatabaseManager.GetInstance().InitializeDatabase();
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

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            DodajTransakcijuWindow prozor = new DodajTransakcijuWindow();

            if (prozor.ShowDialog() == true)
            {
                
                kontroler.Dodaj(prozor.NovaTransakcija);
                dgTransakcije.ItemsSource = null;
                dgTransakcije.ItemsSource = kontroler.VratiTransakcije();
                lblIznos.Content = IzracunajIznos();
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (dgTransakcije.SelectedItem == null)
            {
                MessageBox.Show("Morate da prvo selektujete transakciju!","Savet");
                return;
            }
            Transakcija t = (Transakcija)dgTransakcije.SelectedItem;
            MessageBoxResult rezultat = MessageBox.Show("Da li ste sigurni da zelite da obrisete ovu transakciju?","Potvrda brisanja",MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (rezultat == MessageBoxResult.No)
            {
                return;
            }
            kontroler.Obrisi(t);
            dgTransakcije.ItemsSource = null;
            dgTransakcije.ItemsSource = kontroler.VratiTransakcije();
            lblIznos.Content = IzracunajIznos();

        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (dgTransakcije.SelectedItem == null)
            {
                MessageBox.Show("Morate da selektujete transakciju!", "Savet");
                return;
            }
            Transakcija t = (Transakcija)dgTransakcije.SelectedItem;
            DodajTransakcijuWindow prozor = new DodajTransakcijuWindow(t);
            if (prozor.ShowDialog() == true)
            {
                kontroler.Izmeni(prozor.NovaTransakcija);
                dgTransakcije.ItemsSource = null;
                dgTransakcije.ItemsSource = kontroler.VratiTransakcije();
                lblIznos.Content = IzracunajIznos();
            }
        }
    }
}
