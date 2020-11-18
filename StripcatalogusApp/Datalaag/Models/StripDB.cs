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
        [JsonProperty("ID",Order = 1)]
        public int ID { get; set; }
        [JsonProperty("Titel",Order = 2)]
        [Column("Titel")]
        public string StripTitel { get; set; }
        [Column("Nummer")]
        [JsonProperty("Nr",Order = 3, NullValueHandling = NullValueHandling.Ignore)]
        public int StripNr { get; set; }
        [JsonProperty("Auteurs", Order = 6)]
        public List<AuteurDB> Auteurs { get; set; } //er kunnen meerdere zijn
        [Column("Reeks_id")]
        [JsonProperty("Reeks",Order = 4)]
        public ReeksDB Reeks { get; set; }
      
        [Column("Uitgeverij_id")]
        [JsonProperty("Uitgeverij", Order = 5)]
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
