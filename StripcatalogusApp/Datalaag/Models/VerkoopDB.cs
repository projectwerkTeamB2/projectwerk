using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Datalaag.Models {
    public class VerkoopDB {
        [Key]
        [Column("Id")]
        public int ID { get; set; }

        [Column("datumBestelling")]
        public DateTime DatumBestelling { get; set; }

       [Column("Hoeveelheid")]
       public int Hoeveelheid { get; set; }

        public VerkoopDB() { }
        public VerkoopDB(int id, DateTime datumBestelling, int hoeveelheid) {
            ID = id;
            DatumBestelling = datumBestelling;
            Hoeveelheid = hoeveelheid; 
        }
    }
}
