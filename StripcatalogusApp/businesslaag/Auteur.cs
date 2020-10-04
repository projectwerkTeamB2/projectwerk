using System;
using System.Collections.Generic;
using System.Text;

namespace Businesslaag
{
    public class Auteur
    {
        public string Naam { get; set; }

        public Auteur(string naamAuteur)
        {
            this.Naam = naamAuteur;
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
