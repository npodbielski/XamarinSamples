using System;

namespace Service.Droid.Services.GPS
{
    public interface ILocationService
    {
        event EventHandler<LocationEventArgs> LocationChanged;

        void RequestLocation();

        void StopRequests();
    }
}