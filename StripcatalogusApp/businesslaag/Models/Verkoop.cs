using System;
using System.Collections.Generic;
using System.Text;

namespace Businesslaag.Models {
    public class Verkoop {
        public int ID { get; set; }
        public DateTime DatumBestelling { get; set; }
        public int Hoeveelheid { get; set; }

        public Dictionary<int, int> verkoopStripId_Hoeveelheid;
        public Verkoop(int id, DateTime datumBestelling, int hoeveelheid) {
            ID = id;
            DatumBestelling = datumBestelling;
           
        }



    }
}
