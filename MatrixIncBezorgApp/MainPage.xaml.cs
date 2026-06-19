namespace MatrixIncBezorgApp
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnMapClicked(object? sender, EventArgs e)
        {
            try
            {
                var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
                if (status != PermissionStatus.Granted)
                    status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

                if (status == PermissionStatus.Granted)
                    await Navigation.PushModalAsync(new MapPage());
                else
                    await DisplayAlert("Permission Denied", "Location permission is required for map use", "OK");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Map navigation error: {ex}");
                await DisplayAlert("Error", "Something went wrong opening the map.", "OK");
            }
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
