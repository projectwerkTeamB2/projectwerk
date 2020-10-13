using Businesslaag;
using System;
using System.Collections.Generic;

namespace businesslaag
{
   public class Strip
    {
        public int ID { get; set; }
        public string StripTitel { get; set; }
      public List<Auteur> Auteurs { get; set; } //er kunnen meerdere zijn
      public Reeks Reeks { get; set; }
      public int StripNr { get; set; }
      public Uitgeverij Uitgeverij { get; set; } // note: Een reeks kan van uitgeverijen veranderen na een tijd


        //Als er meerdere auteurs zijn
        public Strip(int id,string stripTitel, List<Auteur> auteurs, Reeks reeks, int stripNr, Uitgeverij uitgeverij)
        {
            this.ID = id;
            this.StripTitel = stripTitel;
            this.Auteurs = auteurs;
            this.Reeks = reeks;
            this.StripNr = stripNr;
            this.Uitgeverij = uitgeverij;
        }

        //Als er maar 1 auteur is
        public Strip(int id, string stripTitel, Reeks reeks, int stripNr, Uitgeverij uitgeverij)
        {
            this.ID = id;
            List<Auteur> auteursHelp = new List<Auteur>
            {
             
            };
            this.StripTitel = stripTitel;
            
            this.Auteurs= auteursHelp;
            this.Reeks = reeks;
            this.StripNr = stripNr;
            this.Uitgeverij = uitgeverij;
        }

        public void voegAuteurToeAanList(Auteur auteur) {
            Auteurs.Add(auteur);
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
