using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Datalaag.Models
{
   [Table("Strip")]
   public class Strip
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }
        [Column("Titel")]
        public string StripTitel { get; set; }
        [Column("Nummer")]
        public int StripNr { get; set; }
        public List<Auteur> Auteurs { get; set; } //er kunnen meerdere zijn
        [Column("Reeks_id")]
      public Reeks Reeks { get; set; }
       
        [Column("Uitgeverij_id")]
      public Uitgeverij Uitgeverij { get; set; } // note: Een reeks kan van uitgeverijen veranderen na een tijd


        //Er kunnen meerdere auteurs zijn
        public Strip(int id, string stripTitel, int stripNr, List<Auteur> auteurs, Reeks reeks, Uitgeverij uitgeverij)
        {
            this.ID = id;
            this.StripTitel = stripTitel;
            this.Auteurs = auteurs;
            this.Reeks = reeks;
            this.StripNr = stripNr;
            this.Uitgeverij = uitgeverij;
        }
        public Strip() { }

       


        //
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
