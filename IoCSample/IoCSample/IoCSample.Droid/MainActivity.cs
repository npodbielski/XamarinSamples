using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using TinyIoC;
using ViewFactory.ViewFactory;
using VFactory = ViewFactory.ViewFactory.ViewFactory;

namespace IoCSample.Droid
{
    [Activity (Label = "IoCSample", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);
            
            Xamarin.Forms.Forms.Init (this, bundle);
            var container = TinyIoCContainer.Current;
            RegisterServices(container);
            var app = new App();
            app.RegisterServices(container);
            LoadApplication (app);
        }

        private void RegisterServices(TinyIoCContainer container)
        {
            container.Register<IViewFactory, VFactory>();
        }
    }
}

