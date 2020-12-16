using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GUI.Models
{
 
   public class StripGUI
    {
        public int ID { get; set; }
        public string StripTitel { get; set; }
        public int StripNr { get; set; }
        public bool IsEenLosseStrip { get; set; }

        public List<AuteurGUI> Auteurs { get; set; } //er kunnen meerdere zijn
        
        public ReeksGUI Reeks { get; set; }
      
        public UitgeverijGUI Uitgeverij { get; set; } // note: Een reeks kan van uitgeverijen veranderen na een tijd
        public bool Ischecked { get; set; }

        //Er kunnen meerdere auteurs zijn
        public StripGUI(int id,string stripTitel, int stripNr, List<AuteurGUI> auteurs, ReeksGUI reeks, UitgeverijGUI uitgeverij, bool isEenLosseStrip = true)
        {
            this.ID = id;
            this.StripTitel = stripTitel;
            this.Auteurs = auteurs;
            this.Reeks = reeks;
            this.StripNr = stripNr;
            this.Uitgeverij = uitgeverij;
            this.Ischecked = false;
            this.IsEenLosseStrip = isEenLosseStrip;
        }
        public StripGUI() { }
    }
}
