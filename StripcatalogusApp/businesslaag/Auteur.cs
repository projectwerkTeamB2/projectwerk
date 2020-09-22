using System;
using System.Collections.Generic;
using System.Text;

namespace Businesslaag
{
    public class Auteur
    {
        public string NaamAuteur { get; set; }

        public Auteur(string naamAuteur)
        {
            this.NaamAuteur = naamAuteur;
        }
    }
}
