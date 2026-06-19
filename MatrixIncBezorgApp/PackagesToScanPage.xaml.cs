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
    }
}
