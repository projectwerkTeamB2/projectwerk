﻿using businesslaag;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businesslaag
{
    public class Reeks
    {
        public string NaamReeks { get; set; }

        public Reeks(string naamReeks)
        {
            NaamReeks = naamReeks;
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