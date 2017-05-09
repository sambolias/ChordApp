namespace ChordApp.UWP
{
    class DisplaySize : IDisplaySize
    {
        public int getDisplayPixelWidth()
        {
            return (int)MainPage.ScreenWidth;
        }

        public int getDisplayPixelHeight()
        {
            return (int)MainPage.ScreenHeight;
        }

        public double getPixelDensity()
        {
            return 1;
        }
    }
}
