using System;
using System.Collections.Generic;
using System.Text;

namespace Businesslaag.Models {
    public class Stock {
        //Comment César
        //1 strip => 1 stock dus geen lijst denk ik
        public Strip Strip { get; set; }
        public int Hoeveelheid { get; set; }

        public Stock(Strip strip, int hoeveelheid) {
            Strip = strip;
            Hoeveelheid = hoeveelheid;
        }
    }
}
