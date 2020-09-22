using Businesslaag;
using System;
using System.Collections.Generic;

namespace businesslaag
{
   public class Strip
    {
      public string StripTitel { get; set; }
      public List<Auteur> Auteurs { get; set; } //er kunnen meerdere zijn
      public Reeks Reeks { get; set; }
      public int StripNr { get; set; }
      public Uitgeverij Uitgeverij { get; set; } // note: Een reeks kan van uitgeverijen veranderen na een tijd


        //Als er meerdere auteurs zijn
        public Strip(string stripTitel, List<Auteur> auteurs, Reeks reeks, int stripNr, Uitgeverij uitgeverij)
        {
            this.StripTitel = stripTitel;
            this.Auteurs = auteurs;
            this.Reeks = reeks;
            this.StripNr = stripNr;
            this.Uitgeverij = uitgeverij;
        }

        //Als er maar 1 auteur is
        public Strip(string stripTitel, Auteur auteur, Reeks reeks, int stripNr, Uitgeverij uitgeverij)
        {
            this.StripTitel = stripTitel;
            this.Auteurs.Add(auteur);
            this.Reeks = reeks;
            this.StripNr = stripNr;
            this.Uitgeverij = uitgeverij;
        }



        //vb.= Strip : De boze geest, Pascal, Merel, GeesteJacht, 1, De standaard
        public override string ToString()
        {
            List<string> auteurNamen = new List<string>();
            Auteurs.ForEach(a => auteurNamen.Add( a.NaamAuteur));

            string begin = $"Strip : {StripTitel}, ";
            auteurNamen.ForEach(s => begin = begin+ s + ", ");
            begin = begin + $"{Reeks.NaamReeks}, {StripNr.ToString()}, {Uitgeverij.NaamUitgeverij}";

            return begin;
        }
    }
}
