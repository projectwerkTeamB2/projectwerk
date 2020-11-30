using System;
using System.Collections.Generic;
using System.Text;
using Datalaag.Models;

namespace Datalaag.Models
{
    /// <summary>
    ///
    /// </summary>
    public class StripCollectionDB
    {
        public int Id { get; set; }

        public string Titel { get; set; }

        public int Nummer { get; set; }

        public UitgeverijDB? Uitgeverij {get; set; }

        public List<StripDB> Strips = new List<StripDB>();

        #region [Constructor]

        /// <summary>
        /// Default constructor
        /// </summary>
        public StripCollectionDB(int Id, String titel, int nummer, List<StripDB> strips, UitgeverijDB? uitgeverij)
        {
            this.Id = Id;
            this.Titel = titel;
            this.Nummer = nummer;
            this.Strips = strips;
            this.Uitgeverij = uitgeverij;

        }
       
        public StripCollectionDB()
        {

        }
        #endregion

        public void addStrips(List<StripDB> strips)
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

        private Boolean nietBestaandeStripCheck(StripDB strip)
        { 
            if (this.Strips.Contains(strip))
            {
                return false; //hij bestaat al
            }
            else return true; // hij bestaat niet
        }
     

    }
}