using System;
using System.Linq;
using Microsoft.Maui.Controls;
using ZXing.Net.Maui;

namespace MatrixIncBezorgApp
{
    public partial class ScannerPage : ContentPage
    {
        public ScannerPage()
        {
            InitializeComponent();
            barcodeReader.Options = new BarcodeReaderOptions
            {
                Formats = BarcodeFormats.All,
                AutoRotate = true,
                Multiple = false
            };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            barcodeReader.IsDetecting = true;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            barcodeReader.IsDetecting = false;
        }

        private void CameraBarcodeReaderView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
        {
            if (e.Results != null && e.Results.Any())
            {
                // Stop detecting while processing
                barcodeReader.IsDetecting = false;

                var first = e.Results.FirstOrDefault();
                if (first != null)
                {
                    Dispatcher.DispatchAsync(async () =>
                    {
                        await DisplayAlert("Barcode Detected", $"Format: {first.Format}\nValue: {first.Value}", "OK");
                        // Decide if you want to keep scanning or pop the page
                        barcodeReader.IsDetecting = true;
                    });
                }
            }
        }

        private async void CloseButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}