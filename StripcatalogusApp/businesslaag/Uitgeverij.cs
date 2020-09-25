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
    }
}
