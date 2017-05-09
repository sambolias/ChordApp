using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ChordApp
{
    public partial class MainPage : ContentPage
    {
        private Picker menu;
        private static double ScreenWidth, ScreenHeight;
        private static double transRt, transLt;
        private Label chord;
        private Image git;
        private Sprite fret;
        private Fretboard neck;
       

        public MainPage()
        {
            Title = "Chord View";
            
            InitializeComponent();
            InitPage();
           
            neck = new Fretboard(10,10);
         //   git = neck.neck;

            Content = new AbsoluteLayout
            {
                Children =
                {
                    neck.neck,                   
                    menu,
                    chord,                  
                }
            };
            
            
        
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            ScreenWidth = width;
            ScreenHeight = height;

        /*    Device.BeginInvokeOnMainThread(() =>
            {
                neck = new Fretboard(ScreenWidth, ScreenHeight);
                git = neck.neck;
            });
            UpdateChildrenLayout();*/
         //   chord.Text = "This shit is happening"+ Convert.ToString(ScreenWidth);
            
           

            menu = makeMenu();
            chord.TranslationX = ScreenWidth / 2;

         /*   double imgHt = 238;
            double imgWd = 1172;
            double scale = ScreenHeight / imgHt;
            double move = ScreenHeight / 2 - imgHt/2;
            //   transRt = -imgWd * scale / 3.3;
            //  transLt = imgWd * scale / 2.9;
            transRt = -imgWd  / 2 - ScreenWidth/2;
            transLt = imgWd / 2 + ScreenWidth/2;
            
            if (Device.RuntimePlatform == "Android")
            {
                var aht = DependencyService.Get<IDisplaySize>().getDisplayPixelHeight();
                var adens = DependencyService.Get<IDisplaySize>().getPixelDensity();
                scale = (aht / adens) / (imgHt / adens);
                move = aht / adens / 2.0;
            }
            git.Scale = scale;
            git.TranslationY = move;
            */
        //    fret.scaleToScreenHeight(ScreenHeight,10);
           
        }

        private void InitPage()
        {
           
            git = new Image
            {
                Source = ImageSource.FromResource("ChordApp.Assets.neck.jpg"),
            };

            fret = new Sprite("ChordApp.Assets.fret.png");


            chord = new Label
            {               
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            };

            menu = makeMenu();
           
        }

        private Picker makeMenu()
        {
        //  figure out menu width
        //    double menuWidth = ScreenWidth*.5;

            Picker menu = new Picker
            {
                Title = "Chords",
                HorizontalOptions=LayoutOptions.CenterAndExpand,               
                Margin =new Thickness(10),                
            };            

            menu.Items.Add("C#");
            menu.Items.Add("D");

            menu.SelectedIndexChanged += async (object sender, EventArgs args) =>
              {
                  chord.Text = menu.SelectedItem.ToString();
                  if (chord.Text == "C#")
                      await git.TranslateTo(transLt, git.TranslationY);
                  if (chord.Text == "D")
                      await git.TranslateTo(transRt, git.TranslationY);
              };
          
            return menu;
        }
    }
}
