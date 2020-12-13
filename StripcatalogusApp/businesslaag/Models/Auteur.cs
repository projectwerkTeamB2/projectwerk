using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Businesslaag.Models
{
    /// <summary>
    /// Auteur model voor de businesslaag
    /// </summary>
    public class Auteur
    {
        
        public int ID { get; set; }
       
        public string Naam { get; set; }

        public Auteur(int id, string naam)
        {
            ID = id;
            /// businessRule auteur mag niet leeg zijn
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
