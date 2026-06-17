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
using System.Windows.Shapes;
using Personal_Finance_Tracker.Modeli;

namespace Personal_Finance_Tracker
{
    /// <summary>
    /// Interaction logic for DodajTransakcijuWindow.xaml
    /// </summary>
    
    public partial class DodajTransakcijuWindow : Window
    {
        public Transakcija NovaTransakcija { get; set; }
       

        public DodajTransakcijuWindow()
        {
            InitializeComponent();
        }
        public DodajTransakcijuWindow(Transakcija t)
        {
            InitializeComponent();
            NovaTransakcija = t;
            txtNaziv.Text = t.Naziv;
            txtIznos.Text = t.Iznos.ToString();
            txtKategorija.Text = t.Kategorija;
            datapicker.SelectedDate = t.Datum;
            if (t.Tip == "Prihod")
            {
                comboBox.SelectedIndex = 0;
            }
            else
            {
                comboBox.SelectedIndex = 1;
            }
        }

        private void btnSacuvaj_Click(object sender, RoutedEventArgs e)
        {
            string Naziv = txtNaziv.Text;
            decimal Iznos = Decimal.Parse(txtIznos.Text);
            string Kategorija = txtKategorija.Text;
            string Tip = comboBox.Text;
            DateTime Datum = datapicker.SelectedDate.Value;
            if (NovaTransakcija == null)
            {
                NovaTransakcija = new Transakcija();
            }
            NovaTransakcija.Naziv = Naziv;
            NovaTransakcija.Iznos = Iznos;
            NovaTransakcija.Kategorija = Kategorija;
            NovaTransakcija.Tip = Tip;
            NovaTransakcija.Datum = Datum;
            DialogResult = true;
            Close();
            }
           

        
    }
}
