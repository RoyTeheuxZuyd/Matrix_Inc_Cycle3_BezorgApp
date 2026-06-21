using System.Linq;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;
using MatrixIncBezorgApp.Models;
using MatrixIncBezorgApp.Services;

namespace MatrixIncBezorgApp
{
    public partial class SummaryPage : ContentPage
    {
        public ObservableCollection<PackageItem> MissingPackages { get; set; } = new ObservableCollection<PackageItem>();
        public ObservableCollection<PackageItem> ScannedPackages { get; set; } = new ObservableCollection<PackageItem>();

        public SummaryPage()
        {
            InitializeComponent();
            missingPackagesList.ItemsSource = MissingPackages;
            scannedPackagesList.ItemsSource = ScannedPackages;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateLists();
        }

        private void UpdateLists()
        {
            MissingPackages.Clear();
            ScannedPackages.Clear();

            foreach (var package in PackageStore.Packages)
            {
                if (package.IsScanned)
                {
                    ScannedPackages.Add(package);
                }
                else
                {
                    MissingPackages.Add(package);
                }
            }
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }

        private async void OnNextClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new BusVolgeladenPage());
        }
    }
}
