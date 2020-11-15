using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Businesslaag.Models
{
   [Table("Strip")]
   public class Strip
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
        public List<Auteur> Auteurs { get; set; } //er kunnen meerdere zijn
        [Column("Reeks_id")]
        [JsonProperty("Reeks",Order = 4)]
        public Reeks Reeks { get; set; }
      
        [Column("Uitgeverij_id")]
        [JsonProperty("Uitgeverij", Order = 5)]
        public Uitgeverij Uitgeverij { get; set; } // note: Een reeks kan van uitgeverijen veranderen na een tijd


        //Er kunnen meerdere auteurs zijn
        public Strip(int id,string stripTitel, int stripNr, List<Auteur> auteurs, Reeks reeks, Uitgeverij uitgeverij)
        {
            this.ID = id;
            this.StripTitel = stripTitel;
            this.Auteurs = auteurs;
            this.Reeks = reeks;
            this.StripNr = stripNr;
            this.Uitgeverij = uitgeverij;
        }
        public Strip() { }

        //toevoegingen
        public void addAuteur(Auteur auteur) {
            if (nietBestaandeAuteurCheck(auteur)) { //kijken of hij al bestaat
                this.Auteurs.Add(auteur);
            }
           
        }
        public void addAuteurs(List<Auteur> auteurs)
        {
            foreach (var aut in auteurs)
            {
                if (nietBestaandeAuteurCheck(aut))
                {
                    //kijken of hij al bestaat
                    this.Auteurs.Add(aut);
                }
            }
           
        }
        private Boolean nietBestaandeAuteurCheck(Auteur auteur) { //true
            if (this.Auteurs.Contains(auteur))
            {
                return false; //hij bestaat al
            }
            else return true; // hij bestaat niet
        }
      


        //vb.= Strip : De boze geest, Pascal, Merel, GeesteJacht, 1, De standaard
        public override string ToString()
        {
            List<string> auteurNamen = new List<string>();
            Auteurs.ForEach(a => auteurNamen.Add( a.Naam));

            string begin = $"Strip :  {ID}, {StripTitel}, ";
            auteurNamen.ForEach(s => begin = begin+ s + ", ");
            begin = begin + $"{Reeks.Naam}, {StripNr.ToString()}, {Uitgeverij.Naam}";

            return begin;
        }

        public override bool Equals(object obj)
        {
            return obj is Strip strip &&
                   StripTitel == strip.StripTitel &&
                   EqualityComparer<List<Auteur>>.Default.Equals(Auteurs, strip.Auteurs) &&
                   EqualityComparer<Reeks>.Default.Equals(Reeks, strip.Reeks) &&
                   StripNr == strip.StripNr &&
                   EqualityComparer<Uitgeverij>.Default.Equals(Uitgeverij, strip.Uitgeverij);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(StripTitel, Auteurs, Reeks, StripNr, Uitgeverij);
        }
    }
}
