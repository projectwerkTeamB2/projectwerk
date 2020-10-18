using System;
using System.Collections.Generic;
using System.Text;

namespace Businesslaag
{
    public class Auteur
    {
        public int ID { get; set; }

        public string Naam { get; set; }

        public Auteur(int iD, string naam)
        {
            ID = iD;
            Naam = naam;
        }

        public override bool Equals(object obj)
        {
            return obj is Auteur auteur &&
                   Naam == auteur.Naam;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Naam);
        }
    }
}
