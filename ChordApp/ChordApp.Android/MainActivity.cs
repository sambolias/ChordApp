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
            WidthDp = convertPxToDp(metrics.WidthPixels);
            HeightDp = convertPxToDp(metrics.HeightPixels);
            pxDensity = Resources.DisplayMetrics.Density;
            //for touch, play with later
            /*GestureDetector.IOnGestureListener listener;
            MotionEvent e1;
            e1.Action = MotionEventActions.Scroll;
            
            listener.OnScroll(e1, e1, 2, 3);
            GestureDetector touch = new GestureDetector(listener);*/

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        private int convertPxToDp(float pixelVal)
        {
            return (int)(pixelVal);///Resources.DisplayMetrics.Density);
        }
    }
}

