﻿using Android.App;
using Android.Content.PM;
using Android.OS;

namespace CustomMasterDetail2.Droid
{
    [Activity (Label = "CustomMasterDetail2", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);
            Xamarin.Forms.Forms.Init (this, bundle);
            LoadApplication (new App());
        }
    }
}

