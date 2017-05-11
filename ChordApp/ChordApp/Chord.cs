using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordApp
{
    class Chord
    {
        public List<Fret> frets;
        public string chord;

        public Chord(string name, List<Fret> fretList )
        {
            frets = fretList;
            chord = name;
        }

        public int getLeftmostFret()
        {
            Fret ret=frets[0];
            foreach(var fret in frets)
            {
                if (fret < ret)
                    ret = fret;
            }

            return ret.fretNum;
        }

        public int getRightmostFret()
        {
            Fret ret = frets[0];
            foreach (var fret in frets)
            {
                if (fret > ret)
                    ret = fret;
            }

            return ret.fretNum;
        }


    }

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
