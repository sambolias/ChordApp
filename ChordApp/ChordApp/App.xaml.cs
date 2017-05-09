﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace ChordApp
{
    
    public partial class App : Application
    {
        public static int ScaleWid = 0, ScaleHt = 0;
        public App()
        {
            InitializeComponent();

            MainPage = new ChordApp.MainPage();
            
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
