using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GUI.Models
{
    public class UitgeverijGUI
    {
   
        public int ID { get; set; }
      
        public string Naam { get; set; }

        public UitgeverijGUI(int iD, string naam)
        {
            ID = iD;
            Naam = naam;
        }
        public UitgeverijGUI( string naam)
        {

            Naam = naam;
        }
        public UitgeverijGUI()
        {
        }


    }
}
