namespace MatrixIncBezorgApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnPackagesClicked(object? sender, EventArgs e)
        {
            await Navigation.PushAsync(new PackagesToScanPage());
        }

        private async void OnSummaryClicked(object? sender, EventArgs e)
        {
            await Navigation.PushAsync(new SummaryPage());
        }

        private async void OnScannerClicked(object? sender, EventArgs e)
        {
            try
            {
                var status = await Permissions.CheckStatusAsync<Permissions.Camera>();
                if (status != PermissionStatus.Granted)
                    status = await Permissions.RequestAsync<Permissions.Camera>();

                if (status == PermissionStatus.Granted)
                    await Navigation.PushModalAsync(new ScannerPage());
                else
                    await DisplayAlert("Permission Denied", "Camera permission is required to scan barcodes", "OK");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Scanner navigation error: {ex}");
                await DisplayAlert("Error", "Something went wrong opening the scanner.", "OK");
            }
        }
    }
    
}
