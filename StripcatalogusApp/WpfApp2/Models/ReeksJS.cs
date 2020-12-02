using Businesslaag;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JSON.Models
{
    public class ReeksJS
    {
        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("Naam")]
        public string Naam { get; set; }

        public ReeksJS(int iD, string naam)
        {
            ID = iD;
            if (naam == "")
                throw new ArgumentException("Naam mag niet leeg zijn");
            Naam = naam;
        }

        public ReeksJS()
        {
        }
        public ReeksJS(string Naam)
        {
            if (Naam == "")
                throw new ArgumentException("Naam mag niet leeg zijn");
            this.Naam = Naam;
        }
        public override bool Equals(object obj)
        {
            return obj is ReeksJS reeks &&
                   Naam == reeks.Naam;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Naam);
        }
    }
}
