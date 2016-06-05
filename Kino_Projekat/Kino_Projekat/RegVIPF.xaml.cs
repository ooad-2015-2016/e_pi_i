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
    public sealed partial class RegVIPF : Page
    {
        bool dodanaSlika = false;
        Image pocetnaSlika = new Image();

        public RegVIPF()
        {
            this.InitializeComponent();
            pocetnaSlika.Source = slikaProfila.Source;
        }
        
        private async void Potvrdi_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textBox_imePrez.Text == "" || textBox_LicnaKarta.Text == "" || textBox_mail.Text == "" || textBox_telefon.Text == ""
                    || textBox_ClanskaKarta.Text == "") throw new Exception("Niste popunili sva polja!");
                if (!dodanaSlika) Glavna.slikeVIP.Add(pocetnaSlika); //ako nije dodao sliku onda ostaje default-na pocetna slika
                Glavna.listaRegVIP.Add(new RegVIP(textBox_imePrez.Text, textBox_LicnaKarta.Text, textBox_ClanskaKarta.Text,
                    textBox_telefon.Text, textBox_mail.Text, checkBox_obavijesti.IsPressed, datRodjenja.Date.DateTime));
                IzbrisiUneseno();
                var dial = new MessageDialog("Uspješno ste dodali novog člana.", "Uspješno dodavanje");
                await dial.ShowAsync();
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

        private async void image_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
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
                    slikaProfila.Source = bitmapImage;
                    Glavna.slikeVIP.Add(slikaProfila);
                    dodanaSlika = true;
                }
            }
        }

        private void IzbrisiUneseno()
        {
            textBox_ClanskaKarta.Text = "";
            textBox_imePrez.Text = "";
            textBox_LicnaKarta.Text = "";
            textBox_mail.Text = "";
            textBox_telefon.Text = "";
            datRodjenja.Date = new DateTimeOffset(DateTime.Today);
            slikaProfila = pocetnaSlika;
            checkBox_obavijesti.IsChecked = false;
        }

        private void Ponisti_Click(object sender, RoutedEventArgs e)
        {
            IzbrisiUneseno();
        }
    }
}
