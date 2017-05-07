using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace ChordApp.Droid
{
    [Activity(Label = "ChordApp", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            var metrics = Resources.DisplayMetrics;
            int width = convertPxToDp(metrics.WidthPixels);
            int height = convertPxToDp(metrics.HeightPixels);
            
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
            return (int)(pixelVal / Resources.DisplayMetrics.Density);
        }
    }
}

