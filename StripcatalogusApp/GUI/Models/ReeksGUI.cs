using Businesslaag;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GUI.Models
{
    public class ReeksGUI
    {
 
        public int ID { get; set; }
   
        public string Naam { get; set; }

        public ReeksGUI(int iD, string naam)
        {
            ID = iD;
            Naam = naam;
        }

        public ReeksGUI()
        {
        }
        public ReeksGUI(string Naam)
        {
            this.Naam = Naam;
        }
     
    }
}
