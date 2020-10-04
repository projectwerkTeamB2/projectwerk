using System;
using System.Collections.Generic;
using System.Text;

namespace Businesslaag
{
    public class Uitgeverij
    {
        public string Naam { get; set; }

        public Uitgeverij(string naamUitgeverij)
        {
            this.Naam = naamUitgeverij;
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
