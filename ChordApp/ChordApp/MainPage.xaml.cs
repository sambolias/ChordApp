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
        private Label chord;
        Image img;

        public MainPage()
        {
            Title = "Chord View";
            InitPage();

          

            Content = new AbsoluteLayout
            {
                Children =
                {
                    img,
                    menu,
                    chord,
                  
                }
            };

            InitializeComponent();
        
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            ScreenWidth = width;
            ScreenHeight = height;
            menu = makeMenu();
            double imgHt = 238;
            double scale = ScreenHeight / imgHt;
            double move = ScreenHeight / 3;
            if (Device.RuntimePlatform == "Android")
            {
                if(ScreenHeight > ScreenWidth)
                {
                    scale *= 2;
                }
                else scale *= 5;

                move = ScreenHeight / 2;
            }
            img.Scale = scale;
            img.TranslationY = move;
            
        }

        private void InitPage()
        {
           
            img = new Image
            {
                Source = ImageSource.FromResource("ChordApp.Assets.neck.jpg"),
            };
           
           


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

            menu.SelectedIndexChanged += (object sender, EventArgs args) =>
              {
                  chord.Text = menu.SelectedItem.ToString();
              };
          
            return menu;
        }
    }
}
