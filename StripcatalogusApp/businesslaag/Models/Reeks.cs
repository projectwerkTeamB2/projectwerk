using Businesslaag;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Businesslaag.Models
{
    [Table("Reeks")]
    public class Reeks
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }
        [Column("Name")]
        public string Naam { get; set; }

        public Reeks(int iD, string naam)
        {
            ID = iD;
            Naam = naam;
        }

        public Reeks()
        {
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
