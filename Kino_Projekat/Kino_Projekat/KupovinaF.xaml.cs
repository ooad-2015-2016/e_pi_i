using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Kino_Projekat
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public enum Sale { A, B, C, D };
    public enum Paketi { family, school, ladies, other };

    public sealed partial class KupovinaF : Page
    {
        int indeks = 0;

        public KupovinaF()
        {
            this.InitializeComponent();
            foreach (var f in Glavna.listaFilmova)
                comboBox_film.Items.Add(f.naziv);
        }

        private async void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            Sale s = Sale.A;
            Paketi p = Paketi.other;
            Filmovi f = new Filmovi();

            if (radioButton_salaA.IsPressed) s = Sale.A;
            else if (radioButton_salaB.IsPressed) s = Sale.B;
            else if (radioButton_salaC.IsPressed) s = Sale.C;
            else if (radioButton_salaD.IsPressed) s = Sale.D;
                                
            try
            {
                if (comboBox_paketi.SelectedValue == null || comboBox_film.SelectedValue == null) throw new Exception("Niste unijeli sva potrebna polja! ");
                foreach (var ff in Glavna.listaFilmova)
                    if (ff.naziv == comboBox_film.SelectedItem.ToString()) { f = ff; break; }
                if (comboBox_paketi.SelectedItem.ToString() == "Family") p = Paketi.family;
                else if (comboBox_paketi.SelectedItem.ToString() == "Ladies night") p = Paketi.ladies;
                else if (comboBox_paketi.SelectedItem.ToString() == "School") p = Paketi.school;
                else if (comboBox_paketi.SelectedItem.ToString() == "Other") p = Paketi.other;

                Glavna.listaKupaca.Add(new Kupci(s, p, f, checkBox_hrana.IsPressed, checkBox_pice.IsPressed, checkBox_VIP.IsPressed, checkBox_Parking.IsPressed));
                var dialog = new MessageDialog("Uspješno ste obavili transakciju.", "Uspješna transkacija");
                await dialog.ShowAsync();
                IzbrisiUneseno();
            }
            catch (Exception ex)
            {
                var dialog = new MessageDialog(ex.Message, "Greška");
                await dialog.ShowAsync();
            }
            
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            KinoF vrati = new KinoF();
            this.Frame.Navigate(vrati.GetType(), vrati);
        }

        private void IzbrisiUneseno()
        {
            radioButton_salaA.IsChecked = false;
            radioButton_salaB.IsChecked = false;
            radioButton_salaC.IsChecked = false;
            radioButton_salaD.IsChecked = false;
            checkBox_hrana.IsChecked = false;
            checkBox_pice.IsChecked = false;
            checkBox_VIP.IsChecked = false;
            checkBox_Parking.IsChecked = false;
            datePicker_dat.Date = DateTimeOffset.Now.Date;
            timePicker_dat.Time = DateTimeOffset.Now.TimeOfDay;
            brPreostalihKarata.Text = "Br. preostalih karata: ";
            comboBox_paketi.SelectedItem = null;
            comboBox_film.SelectedItem = null;
            textBlock_cijena.Text = "0 KM";
        }

        private void Ponisti_Click(object sender, RoutedEventArgs e)
        {
            IzbrisiUneseno();
        }

        private void Izracunaj_Click(object sender, RoutedEventArgs e)
        {
            if (!(comboBox_paketi.SelectedValue == null) && !(comboBox_film.SelectedValue == null))
                textBlock_cijena.Text = Kupci.IzracunajCijenuKarte(Glavna.listaFilmova[indeks], comboBox_paketi.SelectionBoxItem.ToString(), 
                checkBox_hrana.IsPressed, checkBox_pice.IsPressed, checkBox_VIP.IsPressed, checkBox_Parking.IsPressed).ToString() + " " + "KM";
        }

        private void comboBox_film_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (comboBox_film.Items.Count > 0)
            {
                comboBox_film.SelectedItem = comboBox_film.Items[0];
                for (int i = 0; i < Glavna.listaFilmova.Count; i++)
                    if (Glavna.listaFilmova[i].naziv == comboBox_film.SelectedItem.ToString()) { indeks = i; break; }
                brPreostalihKarata.Text = "Br. preostalih karata: " + Glavna.listaFilmova[indeks].brPreostalihKarata.ToString();
            }
        }
    }
}
