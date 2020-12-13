using System;
using System.Collections.Generic;
using System.Text;

namespace Businesslaag.Models
{
    /// <summary>
    /// StripCollectie klasse voor de datalaag, dit werd toegevoed na de opdracht werd uitgebreid
    /// </summary>
    public class StripCollection
    {
        public int Id { get; set; }

        public string Titel { get; set; }

        public int Nummer { get; set; }

        public Uitgeverij? Uitgeverij {get; set; } // uitgeverij is nullable

        public List<Strip> Strips { get; set; } // deze strip kan meerdere strips bevatten.

        #region [Constructor]

        /// <summary>
        /// Default constructor
        /// </summary>
        public StripCollection(int Id, String titel, int nummer, List<Strip> strips, Uitgeverij uitgeverij = null)
        {
            this.Id = Id;
            this.Titel = titel;
            this.Nummer = nummer;
            this.Strips = strips;
            this.Uitgeverij = uitgeverij;

        }

       
       
        public StripCollection()
        {

        }
        #endregion


        // voeg meerdere strips toe
        public void addStrips(List<Strip> strips)
        {
            foreach (var strip in strips)
            {
                if (nietBestaandeStripCheck(strip))
                {
                    this.Strips.Add(strip);
                }
                else
                {
                    throw new ArgumentException("Strip " + strip.StripTitel + "bestaat al");
                }
            }

        }


        // proberen we een strip toe te voegen die niet bestaat ?
        private Boolean nietBestaandeStripCheck(Strip strip)
        { //true
            if (this.Strips.Contains(strip))
            {
                return false; //hij bestaat al
            }
            else return true; // hij bestaat niet
        }
     

    }
}