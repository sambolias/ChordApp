using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChordApp
{
    
    class Fretboard
    {
        private double ScreenWidth, ScreenHeight;
        private double PixelDensity = 1;
        private double neckWidth = 1172, neckHeight = 238;        
        private double fretWidth = 200, fretHeight = 200;
        public Image neck;
        public List<Image> frets;

        public Fretboard(double screenwidth, double screenheight)
        {
            ScreenWidth = screenwidth;
            ScreenHeight = screenheight;

            AdjustDisplayforDevice();

            InitImages();
        }

        private double scaleToScreenHeight(double imgHeight, int percent)
        {
            double scale = (ScreenHeight / PixelDensity) / (imgHeight / PixelDensity);
            scale *= (double)percent / 100;
            return scale;
        }

        private double scaleToScreenWidth(double imgWidth, int percent)
        {
            double scale = (ScreenWidth / PixelDensity) / (imgWidth / PixelDensity);
            scale *= (double)percent / 100;
            return scale;
        }

        private void InitImages()
        {
            neck = new Image();
            neck.Source = ImageSource.FromResource("ChordApp.Assets.neck.jpg");
            neck.Scale = scaleToScreenHeight(neckHeight, 100);
            neck.TranslationY = ScreenHeight / 2 - neckHeight / 2;

            frets = new List<Image>();
            var fretSource = ImageSource.FromResource("ChordApp.Assets.fret.png");
            var fretScale = scaleToScreenHeight(fretHeight, 10);
            for(int i = 0; i < 3; i++)
            {
                frets.Add(new Image());
            }
            foreach (var fret in frets)
            {
                fret.Source = fretSource;
                fret.Scale = fretScale;
                fret.IsVisible = false;
            }
        }

        private void AdjustDisplayforDevice()
        {
            switch (Device.RuntimePlatform)
            {
                //ios needs done
                case "UWP":
                    ScreenWidth = DependencyService.Get<IDisplaySize>().getDisplayPixelWidth();
                    ScreenHeight = DependencyService.Get<IDisplaySize>().getDisplayPixelHeight();
                    break;
                case "Android":
                    PixelDensity = DependencyService.Get<IDisplaySize>().getPixelDensity();
                    ScreenWidth = PixelDensity * DependencyService.Get<IDisplaySize>().getDisplayPixelWidth();
                    ScreenHeight = PixelDensity * DependencyService.Get<IDisplaySize>().getDisplayPixelHeight();
                    break;
                default:
                    break;
            }

            neckWidth *= PixelDensity;  neckHeight *= PixelDensity;
            fretWidth *= PixelDensity;  fretHeight *= PixelDensity;
    }
    }
}
