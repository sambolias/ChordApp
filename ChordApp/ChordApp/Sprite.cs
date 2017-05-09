using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChordApp
{
    public class Sprite : Image
    {
        public double ImgWidth, ImgHeight;
        public double PixelDensity;

        public Sprite(string source)
        {
            Source = source;
        }

        public void scaleToScreenHeight(double height, int percent)
        {
            double scale = (height / PixelDensity) / (ImgHeight / PixelDensity);
            scale *= (double)percent / 100;
            Scale = scale;
        }

        public void scaleToScreenWidth(double width, int percent)
        {
            double scale = (width / PixelDensity) / (ImgWidth / PixelDensity);
            scale *= (double)percent / 100;
            Scale = scale;
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            ImgWidth = width;
            ImgHeight = height;

            switch (Device.RuntimePlatform)
            {
                //ios needs done
                case "Windows":
                    PixelDensity = 1;
                    break;
                case "Android":
                    PixelDensity = DependencyService.Get<IDisplaySize>().getPixelDensity();
                    break;
                default:
                    break;
            }


        }

     /*   protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            switch (Device.RuntimePlatform)
            {
                case "Android": 
                  //change translations per density
                  //will this work for TranslateTo() ?
                  if (propertyName == "TranslationY")
                    TranslationY = TranslationY * PixelDensity;
                  if (propertyName == "TranslationX")
                    TranslationX = TranslationX * PixelDensity;
                    break;
                default:
                    break;
            }
        }*/
    }
}
