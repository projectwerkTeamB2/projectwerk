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
    }
}
