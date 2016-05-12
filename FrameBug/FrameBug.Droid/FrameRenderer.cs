using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using FrameBug.Droid;
using Xamarin.Forms;
using Color = Android.Graphics.Color;

//[assembly: ExportRenderer(typeof(Frame), typeof(FrameRenderer))]
namespace FrameBug.Droid
{
    public class FrameRenderer : Xamarin.Forms.Platform.Android.FrameRenderer
    {
        public override void SetBackgroundColor(Color color)
        {
            //base.SetBackgroundColor(color);
        }
    }
}