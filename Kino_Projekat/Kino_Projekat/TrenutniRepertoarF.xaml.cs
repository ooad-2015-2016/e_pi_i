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
    public sealed partial class TrenutniRepertoarF : Page
    {
        int indeks = 0;

        public TrenutniRepertoarF()
        {
            this.InitializeComponent();
            pretraga.Visibility = Visibility.Collapsed;
            zanrovi.Visibility = Visibility.Collapsed;
            UciniDetaljeNevidljivim();
        }  
        
        private void zanrovi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<Zanr> skupZanrova = new List<Zanr> { Zanr.akcija, Zanr.komedija, Zanr.romansa, Zanr.triler, Zanr.djeciji, Zanr.drama, Zanr.horor, Zanr.scifi };
            rezPretrage.Items.Clear();
            foreach (var filmovi in Glavna.listaFilmova)
            {
                for (int i = 0; i < filmovi.zanr.Count; i++)
                    for (int k = 0; k < skupZanrova.Count; k++)
                        if (filmovi.zanr[i] == skupZanrova[k])
                            if(zanrovi.SelectionBoxItem.ToString() == skupZanrova[k].ToString())
                        {
                            rezPretrage.Items.Add(filmovi.naziv);
                            break;
                        }
            }
        }

        private void pretraga_TextChanging_1(TextBox sender, TextBoxTextChangingEventArgs args)
        {
            rezPretrage.Items.Clear();
            foreach (var filmovi in Glavna.listaFilmova)
                if (filmovi.naziv.StartsWith(pretraga.Text)) rezPretrage.Items.Add(filmovi.naziv);
        }

        private void radioButton_poNazivu_Checked(object sender, RoutedEventArgs e)
        {
            pretraga.Visibility = Visibility.Visible;
            zanrovi.Visibility = Visibility.Collapsed;
        }

        private void radioButton_poZanru_Checked(object sender, RoutedEventArgs e)
        {
            zanrovi.Visibility = Visibility.Visible;
            pretraga.Visibility = Visibility.Collapsed;
        }
        
        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            KinoF vrati = new KinoF();
            this.Frame.Navigate(vrati.GetType(), vrati);
        }

        private void rezPretrage_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (rezPretrage.Items.Count > 0)
            {
                checkBox_prikaziDetalje.Visibility = Visibility.Visible;
                Filmovi film = new Filmovi();
                if (rezPretrage.SelectedItem == null && rezPretrage.Items.Count > 0) rezPretrage.SelectedItem = rezPretrage.Items[0];
                for (int i = 0; i < Glavna.listaFilmova.Count; i++)
                    if (Glavna.listaFilmova[i].naziv == rezPretrage.SelectedItem.ToString()) { film = Glavna.listaFilmova[i]; indeks = i; break; }
                textBox_naziv.Text = film.naziv;
                textBox_brKarata.Text = film.brKarata.ToString();
                textBox_cijenaKarte.Text = film.cijena.ToString();
                textBox_IMDb.Text = film.IMDb.ToString();
                textBox_redatelj.Text = film.redatelj;
                textBox_sinopsis.Text = film.sinopsis;
                textBox_trajanje.Text = film.trajanjeFilma.ToString();
                textBox_uloge.Text = film.uloge;
                slikaFilma.Source = Glavna.slikeFilmova[indeks].Source;
            }
        }

        private void checkBox_prikaziDetalje_Checked(object sender, RoutedEventArgs e)
        {
            UciniDetaljeVidljivim();
        }
        
        private void UciniDetaljeVidljivim()
        {
            A1.Visibility = Visibility.Visible;
            A2.Visibility = Visibility.Visible;
            A5.Visibility = Visibility.Visible;
            A6.Visibility = Visibility.Visible;
            A7.Visibility = Visibility.Visible;
            A8.Visibility = Visibility.Visible;
            A9.Visibility = Visibility.Visible;
            A11.Visibility = Visibility.Visible;
            textBox_brKarata.Visibility = Visibility.Visible;
            textBox_cijenaKarte.Visibility = Visibility.Visible;
            textBox_IMDb.Visibility = Visibility.Visible;
            textBox_naziv.Visibility = Visibility.Visible;
            textBox_redatelj.Visibility = Visibility.Visible;
            textBox_sinopsis.Visibility = Visibility.Visible;
            textBox_trajanje.Visibility = Visibility.Visible;
            textBox_uloge.Visibility = Visibility.Visible;
            slikaFilma.Visibility = Visibility.Visible;
            IzbrisiFilm.Visibility = Visibility.Visible;
            SpasiPromjene.Visibility = Visibility.Visible;
        }

        private void UciniDetaljeNevidljivim()
        {
            A1.Visibility = Visibility.Collapsed;
            A2.Visibility = Visibility.Collapsed;
            A5.Visibility = Visibility.Collapsed;
            A6.Visibility = Visibility.Collapsed;
            A7.Visibility = Visibility.Collapsed;
            A8.Visibility = Visibility.Collapsed;
            A9.Visibility = Visibility.Collapsed;
            A11.Visibility = Visibility.Collapsed;
            textBox_brKarata.Visibility = Visibility.Collapsed;
            textBox_cijenaKarte.Visibility = Visibility.Collapsed;
            textBox_IMDb.Visibility = Visibility.Collapsed;
            textBox_naziv.Visibility = Visibility.Collapsed;
            textBox_redatelj.Visibility = Visibility.Collapsed;
            textBox_sinopsis.Visibility = Visibility.Collapsed;
            textBox_trajanje.Visibility = Visibility.Collapsed;
            textBox_uloge.Visibility = Visibility.Collapsed;
            slikaFilma.Visibility = Visibility.Collapsed;
            IzbrisiFilm.Visibility = Visibility.Collapsed;
            SpasiPromjene.Visibility = Visibility.Collapsed;
        }

        private async void SpasiPromjene_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!int.TryParse(textBox_cijenaKarte.Text, out Glavna.listaFilmova[indeks].cijena) || textBox_cijenaKarte.Text[0] == '-') throw new Exception("Cijena karte mora biti pozitivan broj!");
                if (!int.TryParse(textBox_brKarata.Text, out Glavna.listaFilmova[indeks].brKarata) || textBox_brKarata.Text[0] == '-') throw new Exception("Broj karata mora biti pozitivan cio broj!");
                if (!int.TryParse(textBox_IMDb.Text, out Glavna.listaFilmova[indeks].IMDb)) throw new Exception("Neispravan unos IMDb ocjene!");
                int ocjena = int.Parse(textBox_IMDb.Text);
                if (ocjena < 1 || ocjena > 10) throw new Exception("Ocjena mora biti između 1 i 10!");

                var dialog = new MessageDialog("Promjene su uspješno spašene!", "Uspjeh");
                await dialog.ShowAsync();
            }
            catch (Exception ex)
            {
                var dialog = new MessageDialog(ex.Message, "Greška");
                await dialog.ShowAsync();
            }
        }

        private async void IzbrisiFilm_Click(object sender, RoutedEventArgs e)
        {
            Glavna.listaFilmova.RemoveAt(indeks);
            Glavna.slikeFilmova.RemoveAt(indeks);
            UciniDetaljeNevidljivim();
            rezPretrage.Items.Clear();
            foreach (var filmovi in Glavna.listaFilmova)
                if (filmovi.naziv.StartsWith(pretraga.Text)) rezPretrage.Items.Add(filmovi.naziv);
            var dialog = new MessageDialog("Uspješno ste izbrisali film!", "Uspjeh");
            await dialog.ShowAsync();
        }

        private void checkBox_prikaziDetalje_Unchecked(object sender, RoutedEventArgs e)
        {
            UciniDetaljeNevidljivim();
        }
    }
}
