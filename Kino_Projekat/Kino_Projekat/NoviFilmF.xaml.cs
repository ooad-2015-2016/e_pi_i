using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Input;
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
        
    public sealed partial class NoviFilmF : Page
    {
        Image slika = new Image();
        bool dodanaSlika = false;

        public NoviFilmF()
        {
            this.InitializeComponent();
        }

        private async void buttonUnesi_Click(object sender, RoutedEventArgs e)
        {
            List<Zanr> x = new List<Zanr>();
            if (checkBox_komedija.IsPressed) x.Add(Zanr.komedija);
            if (checkBox_romansa.IsPressed) x.Add(Zanr.romansa);
            if (checkBox_triler.IsPressed) x.Add(Zanr.triler);
            if (checkBox_akcija.IsPressed) x.Add(Zanr.akcija);
            if (checkBox_djeciji.IsPressed) x.Add(Zanr.djeciji);
            if (checkBox_scifi.IsPressed) x.Add(Zanr.scifi);
            if (checkBox_horor.IsPressed) x.Add(Zanr.horor);
            if (checkBox_drama.IsPressed) x.Add(Zanr.drama);
            try
            {
                if (textBox_naziv.Text == "" || textBox_redatelj.Text == "" || textBox_sinopsis.Text == "" || textBox_trajanje.Text == ""
                    || textBox_uloge.Text == "" || comboBox_IMDb.SelectedItem == null) throw new Exception("Niste popunili sva potrebna polja!");
                if (!dodanaSlika) throw new Exception("Niste dodali sliku!");
                DateTime T = new DateTime(datOdrzavanja.Date.Year, datOdrzavanja.Date.Month, datOdrzavanja.Date.Day, vrijemeOdrzavanja.Time.Hours, vrijemeOdrzavanja.Time.Minutes, 0);
                Glavna.listaFilmova.Add(new Filmovi(textBox_naziv.Text, textBox_redatelj.Text, textBox_uloge.Text, x, 
                    textBox_trajanje.Text, textBox_sinopsis.Text, comboBox_IMDb.SelectionBoxItem.ToString(), 
                    T, textBox_brKarata.Text, textBox_cijenaKarte.Text));
                var dialog = new MessageDialog("Uspješno ste dodali film '"+textBox_naziv.Text+"'.", "Uspješno dodavanje");
                await dialog.ShowAsync();
                PonistiUneseno();
            }
            catch (Exception ex)
            {
                var dialog = new MessageDialog(ex.Message, "Greška");
                await dialog.ShowAsync();
            }
            
        }
                
        private async void button_Click(object sender, RoutedEventArgs e)
        {
            // Set up the file picker.
            Windows.Storage.Pickers.FileOpenPicker openPicker =
                new Windows.Storage.Pickers.FileOpenPicker();
            openPicker.SuggestedStartLocation =
                Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            openPicker.ViewMode =
                Windows.Storage.Pickers.PickerViewMode.Thumbnail;

            // Filter to include a sample subset of file types.
            openPicker.FileTypeFilter.Clear();
            openPicker.FileTypeFilter.Add(".bmp");
            openPicker.FileTypeFilter.Add(".png");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".jpg");

            // Open the file picker.
            Windows.Storage.StorageFile file =
                await openPicker.PickSingleFileAsync();

            // 'file' is null if user cancels the file picker.
            if (file != null)
            {
                // Open a stream for the selected file.
                // The 'using' block ensures the stream is disposed
                // after the image is loaded.
                using (Windows.Storage.Streams.IRandomAccessStream fileStream =
                    await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
                {
                    // Set the image source to the selected bitmap.
                    Windows.UI.Xaml.Media.Imaging.BitmapImage bitmapImage =
                        new Windows.UI.Xaml.Media.Imaging.BitmapImage();

                    bitmapImage.SetSource(fileStream);
                    slika.Source = bitmapImage;
                    Glavna.slikeFilmova.Add(slika);
                    dodanaSlika = true;
                }
            }
        }
        
        private async void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("http://www.imdb.com/"));
        }

        private void Nazad_Click(object sender, RoutedEventArgs e)
        {
            KinoF vrati = new KinoF();
            this.Frame.Navigate(vrati.GetType(), vrati);
        }

        private void Ponisti_Click(object sender, RoutedEventArgs e)
        {
            PonistiUneseno();
        }

        private void PonistiUneseno()
        {
            textBox_naziv.Text = "";
            textBox_redatelj.Text = "";
            textBox_sinopsis.Text = "";
            textBox_trajanje.Text = "";
            textBox_uloge.Text = "";
            comboBox_IMDb.SelectedItem = null;
            checkBox_akcija.IsChecked = false;
            checkBox_djeciji.IsChecked = false;
            checkBox_drama.IsChecked = false;
            checkBox_horor.IsChecked = false;
            checkBox_komedija.IsChecked = false;
            checkBox_romansa.IsChecked = false;
            checkBox_scifi.IsChecked = false;
            checkBox_triler.IsChecked = false;
            datOdrzavanja.Date = DateTimeOffset.Now.Date;
            vrijemeOdrzavanja.Time = DateTimeOffset.Now.TimeOfDay;
            textBox_cijenaKarte.Text = string.Empty;
            textBox_brKarata.Text = string.Empty;
        }
    }
}
