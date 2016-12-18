using System;
using Android.App;
using Android.Content.PM;
using Android.Locations;
using Android.OS;
using Xamarin.Forms.Platform.Android;

namespace Service.Droid
{
    [Activity(Label = "Service", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity, ILocationListener
    {
        private LocationManager _locMgr;
        private string _provider = LocationManager.GpsProvider;
        private object _locationProvider;

        public void OnLocationChanged(Location location)
        {
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

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
            _locMgr = GetSystemService(LocationService) as LocationManager;
            var locationCriteria = new Criteria
            {
                Accuracy = Accuracy.Coarse,
                PowerRequirement = Power.Medium
            };
            if (_locMgr != null)
            {
                _locationProvider = _locMgr.GetBestProvider(locationCriteria, true);
                if (_locationProvider != null)
                {
                    _locMgr.RequestLocationUpdates(_provider, 2000, 1, this);
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        protected override void OnPause()
        {
            base.OnPause();
            _locMgr.RemoveUpdates(this);
        }

        protected override void OnResume()
        {
            base.OnResume();
            _locMgr.RequestLocationUpdates(_provider, 2000, 1, this);
        }
    }
}