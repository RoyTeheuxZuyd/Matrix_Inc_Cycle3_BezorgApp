using MatrixIncBezorgApp.Models;
using MatrixIncBezorgApp.Services;
using System.Collections.ObjectModel;
using MatrixIncBezorgApp.Models;
using MatrixIncBezorgApp.Services;

namespace MatrixIncBezorgApp;

public partial class ConfirmDelivery : ContentPage
{
    public ObservableCollection<PackageItem> UndeliveredPackages { get; set; } = new ObservableCollection<PackageItem>();
    public ObservableCollection<PackageItem> DeliveredPackages { get; set; } = new ObservableCollection<PackageItem>();

    public ConfirmDelivery()
    {
        InitializeComponent();
        undeliveredPackagesList.ItemsSource = UndeliveredPackages;
        deliveredPackagesList.ItemsSource = DeliveredPackages;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        UpdateLists();
    }

    private void UpdateLists()
    {
        UndeliveredPackages.Clear();
        DeliveredPackages.Clear();

        foreach (var package in PackageStore.Packages)
        {
            if (package.IsDelivered && package.IsScanned)
            {
                DeliveredPackages.Add(package);
            }
            else
            if (package.IsScanned)
            {
                UndeliveredPackages.Add(package);
            }
        }
    }

    [Obsolete]
    private async void OnPackageClicked(object sender, SelectionChangedEventArgs e)
     {
        if (e.CurrentSelection.FirstOrDefault() is PackageItem tapped)
        {
            bool answer = await DisplayAlert("Are you sure", "Do you want to proceed?", "OK", "Cancel");

        
            if (answer)
            {
                tapped.IsDelivered = !tapped.IsDelivered;
                UpdateLists();
                ((CollectionView)sender).SelectedItem = null; // reset so it can be tapped again
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
