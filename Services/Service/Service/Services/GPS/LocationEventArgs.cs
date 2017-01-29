using System;
using Android.Locations;

namespace Service.Droid.Services.GPS
{
    public class LocationEventArgs : EventArgs
    {
        public LocationEventArgs(Location location)
        {
            Location = location;
        }

        public Location Location { get; set; }
    }
}