using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Datalaag.Models {
    public class AankoopDB {
        [Key]
        [Column("Id")]
        public int Id { get; set; }

        [Column("datumGeplaats")]
        public DateTime DatumGeplaatst { get; set; }

        [Column("datumOntvangen")]
        public DateTime DatumOntvangen { get; set; }

        [Column("hoeveelheid")]
        public int Hoeveelheid { get; set; }

        public AankoopDB() { }

        public AankoopDB(int id, DateTime datumGeplaatst, DateTime datumOntvangen, int hoeveelheid) {
            Id = id;
            DatumGeplaatst = datumGeplaatst;
            DatumOntvangen = datumOntvangen;
            Hoeveelheid = hoeveelheid;
        }
    }
}
