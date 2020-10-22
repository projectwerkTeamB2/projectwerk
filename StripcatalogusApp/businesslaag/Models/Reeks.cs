using Businesslaag;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Businesslaag.Models
{
    public class Reeks
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }
        [Column("Name")]
        public string Naam { get; set; }

        public Reeks(int iD, string naam)
        {
            ID = iD;
            Naam = naam;
        }

        public Reeks()
        {
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
