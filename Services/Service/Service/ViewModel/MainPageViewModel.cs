using System.ComponentModel;
using System.Runtime.CompilerServices;
using Service.Droid.Services.GPS;

namespace Service.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private readonly ILocationService _locationService;

        public MainPageViewModel(ILocationService locationService)
        {
            _locationService = locationService;
            _locationService.LocationChanged += _locationService_LocationChanged;
        }

        public string Location { get; set; }

        private void _locationService_LocationChanged(object sender, LocationEventArgs e)
        {
            Location = e.Location.Longitude + ", " + e.Location.Latitude;
            OnPropertyChanged("Location");
        }

        public void OnAppearing()
        {
            _locationService.RequestLocation();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void OnDisappering()
        {
            _locationService.StopRequests();
        }
    }
}
