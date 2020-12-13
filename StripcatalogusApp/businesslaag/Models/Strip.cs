using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Businesslaag.Models
{
    /// <summary>
    /// Businesslaag model voor strip 
    /// </summary>
 
   public class Strip
    {
       

        public int ID { get; set; }
      
        public string StripTitel { get; set; }
        
        public int StripNr { get; set; }
      
        public List<Auteur> Auteurs { get; set; } //er kunnen meerdere zijn
      
        public Reeks Reeks { get; set; }
      
        public Uitgeverij Uitgeverij { get; set; } // note: Een reeks kan van uitgeverijen veranderen na een tijd


        public Strip(int id,string stripTitel, int stripNr, List<Auteur> auteurs, Reeks reeks, Uitgeverij uitgeverij)
        {
            this.ID = id;
            /// businessRule title mag niet null zijn 
            if (stripTitel == "")
                throw new ArgumentException("Striptitel mag niet leeg zijn");
            this.StripTitel = stripTitel;
           
            this.Auteurs = auteurs;
            this.Reeks = reeks;
            this.StripNr = stripNr;
            this.Uitgeverij = uitgeverij;
        }
        public Strip() { }



        //voeg een enkele auteur toe
        public void addAuteur(Auteur auteur) {
            if (nietBestaandeAuteurCheck(auteur)) { //kijken of hij al bestaat
                this.Auteurs.Add(auteur);
            }
            else
                throw new ArgumentException("Auteur " + auteur.Naam + " bestaat al");
        }
        // voeg een lisjt van auteurs toe.
        public void addAuteurs(List<Auteur> auteurs)
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
        // checkt of de auteur nog niet bestaat should give true
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
