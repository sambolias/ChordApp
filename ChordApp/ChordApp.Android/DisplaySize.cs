using Xamarin.Forms;
using ChordApp.Droid;
using Android.Content.Res;

[assembly: Dependency(typeof(DisplaySize))]
namespace ChordApp.Droid
{
    class DisplaySize : IDisplaySize
    {
        public int getDisplayPixelWidth()
        {            
            return MainActivity.WidthDp;
        }

        public int getDisplayPixelHeight()
        {
            return  MainActivity.HeightDp;
        }

    }


}