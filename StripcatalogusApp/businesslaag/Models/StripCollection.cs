using System;
using System.Collections.Generic;
using System.Text;

namespace Businesslaag.Models
{
    /// <summary>
    ///
    /// </summary>
    public class StripCollection
    {
        public int Id { get; set; }

        public string Titel { get; set; }

        public int Nummer { get; set; }

        public Uitgeverij? Uitgeverij {get; set; }

        public List<Strip> Strips = new List<Strip>();

        #region [Constructor]

        /// <summary>
        /// Default constructor
        /// </summary>
        public StripCollection(int Id, String titel, int nummer, List<Strip> strips, Uitgeverij? uitgeverij)
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