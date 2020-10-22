using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Businesslaag.Models
{
    public class Auteur
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }
        [Column("Name")]
        public string Naam { get; set; }

        public Auteur(int iD, string naam)
        {
            ID = iD;
            Naam = naam;
        }
        public Auteur() 
        { }

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
