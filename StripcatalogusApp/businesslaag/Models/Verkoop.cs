using System;
using System.Collections.Generic;
using System.Text;

namespace Businesslaag.Models {
    public class Verkoop {
        public int ID { get; set; }
        public DateTime DatumBestelling { get; set; }
        public int hoeveelheid { get; set; }

        public Verkoop(int id, DateTime datumBestelling, int hoeveelheid) {
            ID = id;
            DatumBestelling = datumBestelling;
            this.hoeveelheid = hoeveelheid;
        }



    }
}
