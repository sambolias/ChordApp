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
        public List<Chord> alternates = new List<Chord>();
        private int next = 0;         

        public Chord(string name, List<Fret> fretList )
        {
            frets = fretList;
            chord = name;
        }

        public void addAlternate(Chord chord)
        {
            if (!hasAlternates())
                alternates.Add(this);

            alternates.Add(chord);            
        }

        public int getCurrentAlternate()
        {
            return next;
        }

        public int getNextAlternate()
        {
            next++;
            if (next >= alternates.Count)
                next = 0;

            return next;
        }

        public void resetAlternate()
        {
            next = 0;
        }

        public bool hasAlternates()
        {
            if (alternates.Count > 0)
                return true;
            else
                return false;
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
}
