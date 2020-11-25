using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GUI.Models
{
    public class AuteurGUI
    {
       
        public int ID { get; set; }
      
        public string Naam { get; set; }

        public bool Ischecked { get; set; }

        public AuteurGUI(int iD, string naam)
        {
            ID = iD;
            Naam = naam;
            this.Ischecked = false;
        }
     
    }
}
