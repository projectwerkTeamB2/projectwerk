using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Datalaag.Models {
    public class VerkoopDB {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("datumBestelling")]
        public DateTime DatumBestelling { get; set; }

       [Column("Hoeveelheid")]
       public int Hoeveelheid { get; set; }

        public VerkoopDB() { }
        public VerkoopDB(int id, DateTime datumBestelling, int hoeveelheid) {
            Id = id;
            DatumBestelling = datumBestelling;
            Hoeveelheid = hoeveelheid; 
        }
    }
}
