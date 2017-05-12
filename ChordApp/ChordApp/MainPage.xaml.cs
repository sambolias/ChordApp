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
        private Label chord;
        private Label altChord;
        private Fretboard neck;
        private ChordList chordList;
        private Button altButton;
        private string lastChord="";
       
        public MainPage()
        {
            Title = "Chord View";
            
            InitializeComponent();

            initContent();

            Content = new AbsoluteLayout
            {
                Children =
                {
                    neck.neck,    
                    neck.frets[0],
                    neck.frets[1],
                    neck.frets[2],
                    neck.frets[3],
                    menu,
                    altButton,
                    altChord,
                    chord,                  
                }
            };                               
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
           
            neck.updateDisplaySize(width, height);
      
            menu = makeMenu();
            chord.TranslationX = width / 1.5;
            altChord.TranslationX = width / 1.5;
            altChord.TranslationY = height / 15.0;
            altButton.TranslationX = width / 4.0;
            altButton.TranslationY = height / 20.0;
           
        }       

        private void initContent()
        {
            chordList = new ChordList();
            menu = makeMenu();
            chord = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            };
            altChord = new Label
            {
                IsVisible = false,
            };
            neck = new Fretboard();
            altButton = makeAltButton();
        }

        private Button makeAltButton()
        {
            var ret = new Button
            {
                Text = "View Alternate Chord",
                IsVisible = false,
            };
            ret.Clicked += (object s, EventArgs a) =>
            {
                var chord = chordList.showAlternate(this.chord.Text);
                neck.loadChord(chord);
                altChord.Text = chord.chord;
                if (altChord.Text != this.chord.Text)
                    altChord.IsVisible = true;
                else
                    altChord.IsVisible = false;
            };

            return ret;
        }

        private Picker makeMenu()
        {
        //  figure out menu width
        //    double menuWidth = ScreenWidth*.5;

            Picker menu = new Picker
            {
                Title = "Chords",           
                Margin =new Thickness(10),                
            };

          
            foreach (var chord in chordList.chordList)
            {
                menu.Items.Add(chord.Key);
            }

            menu.SelectedIndexChanged += (object sender, EventArgs args) =>
              {                  
                  chord.Text = menu.SelectedItem.ToString();
                 
                  neck.loadChord(chordList.chordList[chord.Text]);

                  //reset alternate button
                  altChord.IsVisible = false;
                  if (lastChord != "")
                      chordList.chordList[lastChord].resetAlternate();

                  lastChord = chord.Text;                
                  if (chordList.chordList[chord.Text].hasAlternates())
                      altButton.IsVisible = true;
                  else
                      altButton.IsVisible = false;       
                  //
              };
          
            return menu;
        }
    }
}
