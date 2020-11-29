using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Businesslaag.Models
{
    public class Auteur
    {
        [JsonProperty("ID")]
        public int ID { get; set; }
        [JsonProperty("Naam")]
        public string Naam { get; set; }

        public Auteur(int iD, string naam)
        {
            ID = iD;
            if (naam == "")
                throw new ArgumentException("Naam mag niet leeg zijn");
            Naam = naam;
        }
        public Auteur() 
        { }
        public Auteur(string naam)
        {
            if (naam == "")
                throw new ArgumentException("Naam mag niet leeg zijn");
            this.Naam = naam;
        }

        public override bool Equals(object obj)
        {
            return obj is Auteur auteur &&
                   Naam == auteur.Naam;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Naam);
        }
    }
}
