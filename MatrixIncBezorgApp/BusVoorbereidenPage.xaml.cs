using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixIncBezorgApp;

public partial class BusVoorbereidenPage : ContentPage
{
    public BusVoorbereidenPage()
    {
        InitializeComponent();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnNextClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new PackagesToScanPage());
    }
}