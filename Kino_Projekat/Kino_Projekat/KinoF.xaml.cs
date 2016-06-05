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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Kino_Projekat
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class KinoF : Page
    {
        public KinoF()
        {
            InitializeComponent();
        }

        private void Novosti_Click(object sender, RoutedEventArgs e)
        {
            NovostiF a = new NovostiF();
            Frame.Navigate(a.GetType(), a);
        }

        private void TrenRepertoar_Click(object sender, RoutedEventArgs e)
        {
            TrenutniRepertoarF b = new TrenutniRepertoarF();
            Frame.Navigate(b.GetType(), b);
        }

        private void RegVIPclana_Click(object sender, RoutedEventArgs e)
        {
            RegVIPF c = new RegVIPF();
            Frame.Navigate(c.GetType(), c);
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            NoviFilmF d = new NoviFilmF();
            Frame.Navigate(d.GetType(), d);
        }

        private void Kupovina_Click(object sender, RoutedEventArgs e)
        {
            KupovinaF k = new KupovinaF();
            Frame.Navigate(k.GetType(), k);
        }

        private void Izvjestaji_Click(object sender, RoutedEventArgs e)
        {
            IzvjestajiF i = new IzvjestajiF();
            Frame.Navigate(i.GetType(), i);
        }
    }
}
