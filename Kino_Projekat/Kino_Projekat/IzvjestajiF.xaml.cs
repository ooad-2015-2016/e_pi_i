using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class IzvjestajiF : Page
    {
        public IzvjestajiF()
        {
            this.InitializeComponent();
            PopuniTabelu();
        }
        
        void PopuniTabelu()
        {
            int parking = 0, hrana=0, pice=0, film_da=0, film_ne=0;
            double profit = 0;

            foreach (var k in Glavna.listaKupaca)
            {
                if (k.parking) parking++;
                if (k.hrana) hrana++;
                if (k.pice) pice++;
                profit += k.cijenaKarte;
            }
            foreach(var f in Glavna.listaFilmova)
            {
                if (f.datOdrzavanja > DateTime.Today) film_ne++;
                else film_da++;
            }

            ukBrNarucenihMjestaParkinga.Text = "Ukupan broj naručenih mjesta parkinga: " + parking.ToString();
            ukBrNarucenihPorcijaHrane.Text = "Ukupna broj naručenih porcija hrane: " + hrana.ToString();
            ukBrNarucenihPorcijaPica.Text = "Ukupan broj naručenih porcija pića: " + pice.ToString();
            ukBrNeodgledanihFilmova.Text = "Ukupan broj neodgledanih filmova: " + film_ne.ToString();
            ukBrOdgledanihFilmova.Text = "Ukupan broj odgledanih filmova: " + film_da.ToString();
            ukBrojKupaca.Text = "Ukupan broj kupaca: " + Glavna.listaKupaca.Count.ToString();
            ukBrojVIP.Text = "Ukupan broj VIP članova: " + Glavna.listaRegVIP.Count.ToString();
            ukProfit.Text = "Ukupan profit: " + profit.ToString() + " KM";
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            KinoF vrati = new KinoF();
            this.Frame.Navigate(vrati.GetType(), vrati);
        }
    }
}