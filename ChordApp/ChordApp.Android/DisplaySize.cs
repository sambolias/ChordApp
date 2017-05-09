using Xamarin.Forms;
using ChordApp.Droid;

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

        public double getPixelDensity()
        {
            return MainActivity.pxDensity;
        }

    }


}