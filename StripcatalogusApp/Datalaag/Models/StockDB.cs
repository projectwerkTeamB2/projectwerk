using Businesslaag.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datalaag.Models {
    public class StockDB {
        //César
        //1 strip is 1 stock dus geen list van strips denk ik?
        public  Strip Strip { get; set; }
        public int Hoeveelheid { get; set; }

        public StockDB(Strip strip, int hoeveelheid) {
            Strip = strip;
            Hoeveelheid = hoeveelheid;
        }
    }
}
