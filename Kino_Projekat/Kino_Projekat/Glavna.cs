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

namespace Kino_Projekat
{
    abstract class Glavna
    {
        public static List<Filmovi> listaFilmova = new List<Filmovi>();
        public static List<RegVIP> listaRegVIP = new List<RegVIP>();
        public static List<Kupci> listaKupaca = new List<Kupci>();
        public static List<Image> slikeFilmova = new List<Image>();
        public static List<Image> slikeVIP = new List<Image>();

    }
}
