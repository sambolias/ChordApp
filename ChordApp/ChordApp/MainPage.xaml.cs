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
        private Label altChord;
        private Fretboard neck;
        private ChordList chordList;
        private Button alts;
        private string lastChord="";
       
        public MainPage()
        {
            Title = "Chord View";
            
            InitializeComponent();
            chordList = new ChordList();
            menu = makeMenu();

            //this will be part of Fretboard probably
            chord = new Label
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            };//

            altChord = new Label
            {
                TranslationX = 900,
                IsVisible = false,
            };

            neck = new Fretboard();

            //make fn
            alts = new Button
            {
                Text = "View Alternate Chord",
                TranslationX = 1000,
                IsVisible = false,
            };
            alts.Clicked += (object s, EventArgs a) =>
            {
                var c = chordList.showAlternate(chord.Text);
                neck.loadChord(c);
                altChord.Text = c.chord;
                if (altChord.Text != chord.Text)
                    altChord.IsVisible = true;
                else
                    altChord.IsVisible = false;
            };//


            Content = new AbsoluteLayout
            {
                Children =
                {
                    neck.neck,    
                    neck.frets[0],
                    neck.frets[1],
                    neck.frets[2],
                    menu,
                    alts,
                    altChord,
                    chord,                  
                }
            };                               
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            ScreenWidth = width;
            ScreenHeight = height;

            neck.updateDisplaySize(ScreenWidth, ScreenHeight);
      
            menu = makeMenu();
            chord.TranslationX = ScreenWidth / 2;

           // chord.Text = Convert.ToString(neck.neck.TranslationX);
            transRt = -1170  / 2 - ScreenWidth/2;
            transLt = 1170 / 2 + ScreenWidth/2;                     
           
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

            /*menu.Items.Add("C");
            menu.Items.Add("C#");
            menu.Items.Add("D");*/

            foreach (var chord in chordList.chordList)
            {
                menu.Items.Add(chord.Key);
            }

            menu.SelectedIndexChanged += /*async*/ (object sender, EventArgs args) =>
              {
                  
                  chord.Text = menu.SelectedItem.ToString();
                  altChord.IsVisible = false;

                  if (lastChord != "")
                      chordList.chordList[lastChord].reset();
                  lastChord = chord.Text;

                  neck.loadChord(chordList.chordList[chord.Text]);
                  if (chordList.chordList[chord.Text].hasAlternates())
                      alts.IsVisible = true;
                  else
                      alts.IsVisible = false;
                 /* List<Fret> test = new List<Fret>();
                  test.Add(new Fret(2, 4));
                  test.Add(new Fret(3, 5));
                  test.Add(new Fret(4, 6));
                  Chord testChord = new Chord("C", test);

                  if (chord.Text == "C")
                      neck.loadChord(testChord);

                  if (chord.Text == "C#")
                  {*/
                     // await neck.neck.TranslateTo(/*(neck.XatFret(1)+neck.XatFret(3))/2.0*/neck.XatFret(0), neck.neck.TranslationY);
                     /* neck.frets[0].IsVisible = true;
                      neck.frets[0].TranslationX = neck.XatFret(4);
                      neck.frets[0].TranslationY = neck.neck.TranslationY;
                  }
                  else neck.frets[0].IsVisible = false;
                  

                  if (chord.Text == "D")*/
                    //  await neck.neck.TranslateTo(/*(neck.XatFret(1)+neck.XatFret(3))/2.0*/neck.XatFret(12), neck.neck.TranslationY);
               //   await neck.neck.TranslateTo(transRt, neck.neck.TranslationY);
              };
          
            return menu;
        }
    }
}
