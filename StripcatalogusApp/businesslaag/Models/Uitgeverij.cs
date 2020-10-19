using System;
using System.Collections.Generic;
using System.Text;

namespace Businesslaag.Models
{
    public class Uitgeverij
    {
        public int ID { get; set; }
        public string Naam { get; set; }

        public Uitgeverij(int iD, string naam)
        {
            ID = iD;
            Naam = naam;
        }

        public Uitgeverij()
        {
        }

        public override bool Equals(object obj)
        {
            return obj is Uitgeverij uitgeverij &&
                   Naam == uitgeverij.Naam;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Naam);
        }
    }
}
