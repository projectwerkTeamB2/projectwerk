using System;
using System.Collections.Generic;
using System.Text;

namespace JSON.Models
{
    /// <summary>
    ///
    /// </summary>
    public class StripCollectionJS
    {
        public int Id { get; set; }

        public string Titel { get; set; }

        public int Nummer { get; set; }

        public UitgeverijJS? Uitgeverij {get; set; }

        public List<StripJS> Strips { get; set; }

        #region [Constructor]

        /// <summary>
        /// Default constructor
        /// </summary>
        public StripCollectionJS(int Id, String titel, int nummer, List<StripJS> strips, UitgeverijJS? uitgeverij)
        {
            this.Id = Id;
            this.Titel = titel;
            this.Nummer = nummer;
            this.Strips = strips;
            this.Uitgeverij = uitgeverij;

        }

       
       
        public StripCollectionJS()
        {

        }
        #endregion

        public void addStrips(List<StripJS> strips)
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

        private Boolean nietBestaandeStripCheck(StripJS strip)
        { //true
            if (this.Strips.Contains(strip))
            {
                return false; //hij bestaat al
            }
            else return true; // hij bestaat niet
        }
     

    }
}