using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

//todo clean up constants in loadChord(),XatFret(), and YatString()
//solve series in nutToFret()
//figure out display inconsistencies

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
     
        public Fretboard()
        {           
            ScreenWidth = 500;
            ScreenHeight = 500;

            AdjustDisplayforDevice();

            InitImages();
        }

        public void updateDisplaySize(double screenwidth, double screenheight)
        {
            ScreenWidth = screenwidth;
            ScreenHeight = screenheight;

            AdjustDisplayforDevice();
            AdjustImagesforDisplay();
        }
   
        public async void loadChord(Chord chord)
        {
            int leftFret = chord.getLeftmostFret()-1;
            double ScaleLength = (neckWidth - 173.0) / PixelDensity * 2.0 * neck.Scale; //in 2 places...

            hideFrets();

            await neck.TranslateTo(XatFret(leftFret), neck.TranslationY);

            int i = 0;
            double fretOffset;
            double midFret;
            foreach(var fret in chord.frets)
            {
                midFret = nutToFret(fret.fretNum, ScaleLength) - nutToFret(fret.fretNum-1, ScaleLength);
                fretOffset = nutToFret(fret.fretNum-1, ScaleLength) - nutToFret(leftFret, ScaleLength);
                fretOffset += midFret / 4.5;
                this.frets[i].IsVisible=true;
                this.frets[i].TranslationX = fretOffset+fretWidth*frets[i].Scale/2.0;
                this.frets[i].TranslationY = YatString(fret.stringNum);
               
                i++;
            }

        }

        //fret inlay at top of designated fret should be at left side of screen
        public double XatFret(int fretNum)
        {
                                                                                // V /4.5 on Android --figure out
                                                                                // V /3.3 on BigScreen
                                                                                // V /2.3 on Laptop
            double XatNut = neckWidth / PixelDensity * neck.Scale / 2.0 - ScreenWidth/4.5;
            //scale length is double the length to the 12th fret
            //http://www.liutaiomottola.com/formulae/fret.htm
            double ScaleLength = (neckWidth - 173.0) / PixelDensity * 2.0 * neck.Scale;

            return XatNut - nutToFret(fretNum, ScaleLength);
        }

        private double nutToFret(int fret, double scaleLength)
        {
            const double fretConst = 17.817;
            double NutToFret=0;
            double bridgeToFret;
            
            //once this works solve as nonrecursive
            for(int i = fret; i > 0; i--)
            {
                bridgeToFret = scaleLength - NutToFret;
                NutToFret = bridgeToFret / fretConst + NutToFret;
            }

            return NutToFret;
        }

        private double YatString(int stringNum)
        {
            //dummy
            //theres definitely a more
            //clever way to do this
            List<int> stringY = new List<int>
            {
                21,45,68,94,120, 149
            };
            return stringY[stringNum - 1] * neck.Scale / PixelDensity;
        }

        private double scaleToScreenHeight(double imgHeight, int percent)
        {
            double scale = ScreenHeight * PixelDensity / imgHeight;
            scale *= (double)percent / 100.0;
            return scale;
        }

        private double scaleToScreenWidth(double imgWidth, int percent)
        {
            double scale = ScreenWidth * PixelDensity / imgWidth;
            scale *= (double)percent / 100.0;
            return scale;
        }

        private void hideFrets()
        {
            foreach(var fret in frets)
            {
                fret.IsVisible = false;
            }
        }

        private void InitImages()
        {
            neck = new Image();
            neck.Source = ImageSource.FromResource("ChordApp.Assets.neck.jpg");
           
            frets = new List<Image>();
            var fretSource = ImageSource.FromResource("ChordApp.Assets.fret.png");
          
            for(int i = 0; i < 4; i++)
            {
                frets.Add(new Image());
            }
            foreach (var fret in frets)
            {
                fret.Source = fretSource;
                fret.IsVisible = false;
            }

            AdjustImagesforDisplay();
        }

        private void AdjustImagesforDisplay()
        {
            neck.Scale = scaleToScreenHeight(neckHeight, 100);
            neck.TranslationY = ScreenHeight / 2 - neckHeight / PixelDensity / 2;

            var fretScale = scaleToScreenHeight(fretHeight, 10);
            foreach (var fret in frets)
            {              
                fret.Scale = fretScale;
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
                    ScreenWidth = DependencyService.Get<IDisplaySize>().getDisplayPixelWidth() / PixelDensity;
                    ScreenHeight = DependencyService.Get<IDisplaySize>().getDisplayPixelHeight() / PixelDensity;
                    break;
                default:
                    break;
            }
        //theres still an inconsistancy in the displays
        //    neckWidth /= PixelDensity;  neckHeight /= PixelDensity;
        //    fretWidth /= PixelDensity;  fretHeight /= PixelDensity;
        }
    }
}
