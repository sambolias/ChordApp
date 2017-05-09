using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace ChordApp.Droid
{
    [Activity(Label = "ChordApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ScreenOrientation = ScreenOrientation.Landscape, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public static int WidthDp, HeightDp;
        public static double pxDensity;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            var metrics = Resources.DisplayMetrics;
            WidthDp = metrics.WidthPixels;
            HeightDp = metrics.HeightPixels;
            pxDensity = Resources.DisplayMetrics.Density;          

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }      
    }
}

