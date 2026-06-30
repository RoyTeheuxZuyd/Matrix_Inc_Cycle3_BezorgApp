using MatrixIncBezorgApp.Services;
using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using System.Text.Json;


namespace MatrixIncBezorgApp
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        private CancellationTokenSource? _cancelTokenSource;
        private bool _isCheckingLocation;

        private string _lat = "Not set";
        public string Lat
        {
            get => _lat;
            set
            {
                if (_lat != value)
                {
                    _lat = value;
                    OnPropertyChanged();
                }
            }
        }

        private string _long = "Not set";
        public string Long
        {
            get => _long;
            set
            {
                if (_long != value)
                {
                    _long = value;
                    OnPropertyChanged();
                }
            }
        }

        protected override async void OnAppearing()
        {
            await GetCurrentLocation();
        }

        public async Task GetCurrentLocation()
        {
            try
            {
                _isCheckingLocation = true;

                var request = new GeolocationRequest(
                    GeolocationAccuracy.Medium,
                    TimeSpan.FromSeconds(1));

                _cancelTokenSource?.Cancel();
                _cancelTokenSource?.Dispose();
                _cancelTokenSource = new CancellationTokenSource();

                var location = await Geolocation.Default.GetLocationAsync(
                    request,
                    _cancelTokenSource.Token);

                if (location != null)
                {
                    Lat = location.Latitude.ToString("F6");
                    Long = location.Longitude.ToString("F6");

                    UpdatePinOnMap(location.Latitude, location.Longitude);
                }
            }
            catch (Exception)
            {
                Lat = "Error";
                Long = "Error";
            }
            finally
            {
                _isCheckingLocation = false;
            }
        }

        private readonly HttpClient _httpClient = new();

        private void UpdatePinOnMap(double latitude, double longitude)
        {
            MainThread.BeginInvokeOnMainThread(async() =>
            {
                var myLocation = new Microsoft.Maui.Devices.Sensors.Location(latitude, longitude);

                MyMap.Pins.Clear();
                MyMap.Pins.Add(new Pin
                {
                    Label = "My Location",
                    Location = myLocation,
                    Type = PinType.Place
                });

                foreach (var package in PackageStore.Packages)
                {
                    if (package.IsScanned)
                    {
                        var locations = await Geocoding.Default.GetLocationsAsync(package.Adress);

                        var location = locations?.FirstOrDefault();

                        if (location != null)
                        {
                            MyMap.Pins.Add(new Pin
                            {
                                Label = package.PackageId,
                                Location = location,
                                Type = PinType.SavedPin
                            });
                        }
                    }
                }

                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                    myLocation,
                    Distance.FromKilometers(1)));
            });
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