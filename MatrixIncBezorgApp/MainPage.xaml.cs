namespace MatrixIncBezorgApp
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
        private async void OnMapClicked(object? sender, EventArgs e)
        {
            var status = await Permissions.CheckStatusAsync<Permissions.LocationWhenInUse>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();
            }

            if (status == PermissionStatus.Granted)
            {
                await Navigation.PushModalAsync(new MapPage());
            }
            else
            {
                await DisplayAlert("Permission Denied", "Location Permission is required for map use", "OK");
            }
        }

        private async void OnScannerClicked(object? sender, EventArgs e)
        {
            var status = await Permissions.CheckStatusAsync<Permissions.Camera>();
            if (status != PermissionStatus.Granted)
            {
                status = await Permissions.RequestAsync<Permissions.Camera>();
            }

            if (status == PermissionStatus.Granted)
            {
                await Navigation.PushModalAsync(new ScannerPage());
            }
            else
            {
                await DisplayAlert("Permission Denied", "Camera permission is required to scan barcodes", "OK");
            }
        }
    }
}
