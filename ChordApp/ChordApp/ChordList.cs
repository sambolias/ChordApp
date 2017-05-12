using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChordApp
{
    class ChordList
    {
        public Dictionary<string, Chord> chordList = new Dictionary<string, Chord>();

        public ChordList()
        {
            List<Fret> fretList;
            
            fretList = new List<Fret>
            {
                new Fret(6,1),
                new Fret(5,3),
                new Fret(4,3),
            };
            chordList.Add("Power G", new Chord("Power G", fretList));

            fretList = new List<Fret>
            {
                new Fret(6,3),
                new Fret(5,5),
                new Fret(4,5),
            };
            chordList.Add("Power A", new Chord("Power A", fretList));

            fretList = new List<Fret>
            {
                new Fret(5,2),
                new Fret(4,2),
                new Fret(3,1),
            };
            chordList.Add("E", new Chord("E", fretList));

            fretList = new List<Fret>
            {
                new Fret(5,5),
                new Fret(4,5),
                new Fret(3,7),
                new Fret(2,8),
            };
            chordList.Add("L", new Chord("L", fretList));

            fretList = new List<Fret>
            {
                new Fret(4,2),
                new Fret(3,2),
                new Fret(2,1),
                new Fret(1,4),
            };
            chordList.Add("Made up Chord", new Chord("Made up Chord", fretList));






        }

    }
}
