using Android.Locations;
using Android.OS;

namespace Service.Droid.Services.GPS
{
    public class LocationListener : Java.Lang.Object, ILocationListener
    {
        private readonly LocationService _locationService;

        public LocationListener(LocationService locationService)
        {
            _locationService = locationService;
        }

        public void OnLocationChanged(Location location)
        {
            _locationService.PushLocation(location);
        }

        public void OnProviderDisabled(string provider)
        {

        }

        public void OnProviderEnabled(string provider)
        {

        }

        public void OnStatusChanged(string provider, Availability status, Bundle extras)
        {

        }
    }
}