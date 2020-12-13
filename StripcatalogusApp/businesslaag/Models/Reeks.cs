using Businesslaag;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Businesslaag.Models
{
    /// <summary>
    /// businesslaag model voor Reeks
    /// </summary>
    public class Reeks
    {
     
        public int ID { get; set; }
     
        public string Naam { get; set; }

        public Reeks(int id, string naam)
        {
            ID = id;
            // BusinessRule Naam van een reeks mag niet leeg zijn
            if (naam == "")
                throw new ArgumentException("Naam mag niet leeg zijn");
            Naam = naam;
        }

        public Reeks()
        {
        }
        public Reeks(string Naam)
        {
            if (Naam == "")
                throw new ArgumentException("Naam mag niet leeg zijn");
            this.Naam = Naam;
        }
        public override bool Equals(object obj)
        {
            return obj is Reeks reeks &&
                   Naam == reeks.Naam;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Naam);
        }
    }
}
