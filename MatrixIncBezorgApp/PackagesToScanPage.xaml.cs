using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using MatrixIncBezorgApp.Models;
using MatrixIncBezorgApp.Services;

namespace MatrixIncBezorgApp
{
    public partial class PackagesToScanPage : ContentPage
    {
        public ObservableCollection<PackageItem> Packages { get; set; }

        public PackagesToScanPage()
        {
            InitializeComponent();

            Packages = PackageStore.Packages;
            packagesList.ItemsSource = Packages;
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void OnNextClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ScannerPage());
        }
    }
}
