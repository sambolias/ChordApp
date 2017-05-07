using Xamarin.Forms;
using ChordApp.Droid;
using Android.Content.Res;

[assembly: Dependency(typeof(DisplaySize))]
namespace ChordApp.Droid
{
    class DisplaySize : IDisplaySize
    {
        public int getDisplayPixels()
        {
           
            return 3;
        }

    }


}