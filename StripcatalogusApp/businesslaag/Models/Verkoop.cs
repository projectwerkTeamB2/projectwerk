using System;
using System.Collections.Generic;
using System.Text;

namespace Businesslaag.Models {
    public class Verkoop {
        public int Id { get; set; }
        public DateTime DatumBestelling { get; set; }
        public int hoeveelheid { get; set; }

        public Verkoop(int id, DateTime datumBestelling, int hoeveelheid) {
            Id = id;
            DatumBestelling = datumBestelling;
            this.hoeveelheid = hoeveelheid;
        }
    }
}
