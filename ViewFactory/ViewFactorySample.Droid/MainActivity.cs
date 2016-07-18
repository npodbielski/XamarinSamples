using Android.App;
using Android.Content.PM;
using Android.OS;
using XForms = Xamarin.Forms.Forms;
using Xamarin.Forms.Platform.Android;

namespace ViewFactorySample
{
    [Activity(Label = "ViewFactory", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            XForms.Init(this, bundle);
            LoadApplication(new App());
        }
    }
}

