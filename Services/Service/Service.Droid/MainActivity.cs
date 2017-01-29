using System;
using Android.App;
using Android.Content.PM;
using Android.OS;
using Service.Droid.Services.GPS;
using TinyIoC;
using Xamarin.Forms.Platform.Android;

namespace Service.Droid
{
    [Activity(Label = "Service", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Xamarin.Forms.Forms.Init(this, bundle);
            RegisterServices();
            LoadApplication(new App());
        }

        private void RegisterServices()
        {
            var container = TinyIoCContainer.Current;
            container.Register(this);
            container.Register<ILocationService, LocationService>();
        }
    }
}