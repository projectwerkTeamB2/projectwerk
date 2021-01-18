using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JSON.Models
{
 
   public class StripJS
    {
        [JsonProperty("ID", Order = 1)]
        public int ID { get; set; }
        [JsonProperty("Titel", Order = 2)]
        public string StripTitel { get; set; }
        [JsonProperty("Nr", Order = 3, NullValueHandling = NullValueHandling.Ignore)]
        public int StripNr { get; set; }

        public int IsEenLosseStrip { get; set; }

        [JsonProperty("Auteurs", Order = 6)]
        public List<AuteurJS> Auteurs { get; set; } //er kunnen meerdere zijn
        [JsonProperty("Reeks", Order = 4)]
        public ReeksJS Reeks { get; set; }
        [JsonProperty("Uitgeverij", Order = 5)]
        public UitgeverijJS Uitgeverij { get; set; } // note: Een reeks kan van uitgeverijen veranderen na een tijd


        //Er kunnen meerdere auteurs zijn
        public StripJS(int id,string stripTitel, int stripNr, List<AuteurJS> auteurs, ReeksJS reeks, UitgeverijJS uitgeverij, int isEenLosseStrip = 1)
        {
            this.ID = id;
            if (stripTitel == "")
                throw new ArgumentException("Striptitel mag niet leeg zijn");
            this.StripTitel = stripTitel;
           
            this.Auteurs = auteurs;
            this.Reeks = reeks;
            this.StripNr = stripNr;
            this.Uitgeverij = uitgeverij;
            this.IsEenLosseStrip = isEenLosseStrip;
        }
        public StripJS() { }

        //toevoegingen
        public void addAuteur(AuteurJS auteur) {
            if (nietBestaandeAuteurCheck(auteur)) { //kijken of hij al bestaat
                this.Auteurs.Add(auteur);
            }
            else
                throw new ArgumentException("Auteur " + auteur.Naam + " bestaat al");
        }
        public void addAuteurs(List<AuteurJS> auteurs)
        {
            foreach (var aut in auteurs)
            {
                if (nietBestaandeAuteurCheck(aut))
                {
                    //kijken of hij al bestaat
                    this.Auteurs.Add(aut);
                } else {
                    throw new ArgumentException("Auteur " + aut.Naam + "bestaat al");
                }
            }
           
        }
        private Boolean nietBestaandeAuteurCheck(AuteurJS auteur) { //true
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
            return obj is StripJS strip &&
                   StripTitel == strip.StripTitel &&
                   EqualityComparer<List<AuteurJS>>.Default.Equals(Auteurs, strip.Auteurs) &&
                   EqualityComparer<ReeksJS>.Default.Equals(Reeks, strip.Reeks) &&
                   StripNr == strip.StripNr &&
                   EqualityComparer<UitgeverijJS>.Default.Equals(Uitgeverij, strip.Uitgeverij);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(StripTitel, Auteurs, Reeks, StripNr, Uitgeverij);
        }
    }
}
