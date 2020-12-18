using System;
using System.Collections.Generic;
using System.Text;

namespace Businesslaag.Models {
    public class Aankoop {
        public int ID { get; set; }
        public DateTime DatumGeplaatst { get; set; }
        public DateTime DatumOntvangen { get; set; }
        public int Hoeveelheid { get; set; }

        public Aankoop(int id, DateTime datumGeplaatst, DateTime datumOntvangen, int hoeveelheid) {
            ID = id;
            DatumGeplaatst = datumGeplaatst;
            DatumOntvangen = datumOntvangen;
            Hoeveelheid = hoeveelheid;
        }
    }
}
