using Android.Locations;
using System;
using Android.Content;

namespace Service.Droid.Services.GPS
{
    public class LocationService : ILocationService
    {
        public LocationListener Listener;
        private readonly LocationManager _locMgr;
        private readonly Criteria _locationCriteria;

        public LocationService(MainActivity activity)
        {
            _locMgr = activity.GetSystemService(Context.LocationService) as LocationManager;
            Listener = new LocationListener(this);
            _locationCriteria = new Criteria
            {
                Accuracy = Accuracy.Coarse,
                PowerRequirement = Power.Medium
            };
            if (_locMgr == null)
            {
                throw new Exception("No LocationManager instance!");
            }
        }

        public event EventHandler<LocationEventArgs> LocationChanged;

        public void RequestLocation()
        {
            var provider = _locMgr.GetBestProvider(_locationCriteria, true);
            if (provider == null)
            {
                throw new Exception("No GPS provider could be found for given criteria!");
            }
            _locMgr.RequestLocationUpdates(provider, 2000, 1, Listener);
        }

        public void StopRequests()
        {
            _locMgr.RemoveUpdates(Listener);
        }

        internal void PushLocation(Location location)
        {
            OnLocationChanged(new LocationEventArgs(location));
        }

        protected virtual void OnLocationChanged(LocationEventArgs e)
        {
            LocationChanged?.Invoke(this, e);
        }
    }
}