using System;
using System.Collections.Generic;
using System.Text;

namespace Businesslaag
{
    public class Uitgeverij
    {
        public string NaamUitgeverij { get; set; }

        public Uitgeverij(string naamUitgeverij)
        {
            this.NaamUitgeverij = naamUitgeverij;
        }
    }
}
