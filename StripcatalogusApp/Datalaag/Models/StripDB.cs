using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Datalaag.Models
{
   [Table("Strip")]
   public class StripDB
    {
        [Key]
        [Column("id")]
       
        public int ID { get; set; }
       
        [Column("Titel")]
        public string StripTitel { get; set; }
        [Column("Nummer")]
       
        public int StripNr { get; set; }
       
        public List<AuteurDB> Auteurs { get; set; } //er kunnen meerdere zijn
        [Column("Reeks_id")]
       
        public ReeksDB Reeks { get; set; }
      
        [Column("Uitgeverij_id")]
      
        public UitgeverijDB Uitgeverij { get; set; } // note: Een reeks kan van uitgeverijen veranderen na een tijd


        //Er kunnen meerdere auteurs zijn
        public StripDB(int id,string stripTitel, int stripNr, List<AuteurDB> auteurs, ReeksDB reeks, UitgeverijDB uitgeverij)
        {
            this.ID = id;
            this.StripTitel = stripTitel;
            this.Auteurs = auteurs;
            this.Reeks = reeks;
            this.StripNr = stripNr;
            this.Uitgeverij = uitgeverij;
        }
        public StripDB() { }

       
    }
}
