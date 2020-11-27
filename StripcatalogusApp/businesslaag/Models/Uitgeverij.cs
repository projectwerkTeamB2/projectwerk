using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Businesslaag.Models
{
    public class Uitgeverij
    {
        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("Naam")]
        public string Naam { get; set; }

        public Uitgeverij(int iD, string naam)
        {
            ID = iD;
            if (naam == "")
                throw new ArgumentException("Naam mag niet leeg zijn");
            Naam = naam;
        }
        public Uitgeverij( string naam)
        {
            if (naam == "")
                throw new ArgumentException("Naam mag niet leeg zijn");
            Naam = naam;
        }
        public Uitgeverij()
        {
        }

        public override bool Equals(object obj)
        {
            return obj is Uitgeverij uitgeverij &&
                   Naam == uitgeverij.Naam;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Naam);
        }
    }
}
