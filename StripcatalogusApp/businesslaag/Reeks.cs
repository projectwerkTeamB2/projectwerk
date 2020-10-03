using businesslaag;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businesslaag
{
    public class Reeks
    {
        public string Naam { get; set; }

        public Reeks(string naamReeks)
        {
            Naam = naamReeks;
        }

        public override bool Equals(object obj)
        {
            return obj is Reeks reeks &&
                   Naam == reeks.Naam;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Naam);
        }


        //Lijst met strips bij reeks?
        //public List<Strip> Strips { get; set; }

        //public Reeks(string naamReeks, List<Strip> strips)
        //{
        //    this.NaamReeks = naamReeks;
        //    this.Strips = strips;
        //}

        //public void voegStripBij(Strip ToeTeVoegenStrip) {
        //    this.Strips.Add(ToeTeVoegenStrip);
        //}


    }
}
