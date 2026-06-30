 using System;
using System.Linq;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using ZXing.Net.Maui;
using MatrixIncBezorgApp.Services;

namespace MatrixIncBezorgApp
{
    public partial class ScannerPage : ContentPage
    {
        private ObservableCollection<string> scannedPackages;

        public ScannerPage()
        {
            InitializeComponent();
            scannedPackages = new ObservableCollection<string>();
            scannedList.ItemsSource = scannedPackages;

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
                    Dispatcher.DispatchAsync(() =>
                    {
                        var barcodeValue = first.Value;
                        if (!scannedPackages.Contains(barcodeValue))
                        {
                            scannedPackages.Insert(0, barcodeValue);

                            // Mark in global store
                            var package = PackageStore.Packages.FirstOrDefault(p => p.PackageId == barcodeValue);
                            if (package != null)
                            {
                                package.IsScanned = true;
                            }
                        }

                        // Keep scanning
                        barcodeReader.IsDetecting = true;
                    });
                }
            }
        }

        /*
        private async void CloseButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void OnNextClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SummaryPage());
        }
    }
}