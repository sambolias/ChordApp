﻿using System;
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
        private Fretboard neck;
       
        public MainPage()
        {
            Title = "Chord View";
            
            InitializeComponent();

            menu = makeMenu();

            //this will be part of Fretboard probably
            chord = new Label
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
            };//

            neck = new Fretboard();

            Content = new AbsoluteLayout
            {
                Children =
                {
                    neck.neck,    
                    neck.frets[0],
                    neck.frets[1],
                    neck.frets[2],
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

            neck.updateDisplaySize(ScreenWidth, ScreenHeight);
      
            menu = makeMenu();
            chord.TranslationX = ScreenWidth / 2;
         
            transRt = -1170  / 2 - ScreenWidth/2;
            transLt = 280 / 2 + ScreenWidth/2;                     
           
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
                  {
                      await neck.neck.TranslateTo(transLt, neck.neck.TranslationY);
                      neck.frets[0].IsVisible = true;
                      neck.frets[0].TranslationX = transLt + 50;
                      neck.frets[0].TranslationY = neck.neck.TranslationY + 50;
                  }
                  else neck.frets[0].IsVisible = false;

                  if (chord.Text == "D")
                      await neck.neck.TranslateTo(transRt, neck.neck.TranslationY);
              };
          
            return menu;
        }
    }
}
