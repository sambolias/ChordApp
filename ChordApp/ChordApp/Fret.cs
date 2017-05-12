namespace ChordApp
{
    struct Fret
    {
        public int stringNum { get; set; }
        public int fretNum { get; set; }

        public Fret(int stringnum, int fretnum)
        {
            stringNum = stringnum;
            fretNum = fretnum;
        }

        public static bool operator <(Fret lhs, Fret rhs)
        {
            return lhs.fretNum < rhs.fretNum;
        }
        public static bool operator >(Fret lhs, Fret rhs)
        {
            return lhs.fretNum > rhs.fretNum;
        }

    }
}
