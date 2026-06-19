using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Devices.Sensors;
using Microsoft.Maui.Maps;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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

        private async void OnGetLocationClicked(object sender, EventArgs e)
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

        private void UpdatePinOnMap(double latitude, double longitude)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                var location = new Microsoft.Maui.Devices.Sensors.Location(latitude, longitude);

                MyMap.Pins.Clear();
                MyMap.Pins.Add(new Pin
                {
                    Label = "My Location",
                    Location = location,
                    Type = PinType.Place
                });

                MyMap.MoveToRegion(MapSpan.FromCenterAndRadius(
                    location,
                    Distance.FromKilometers(1)));
            });
        }
        private async void CloseButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }
    }
}