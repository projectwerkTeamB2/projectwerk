using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Businesslaag.Models
{
    [Table("Uitgeverij")]
    public class Uitgeverij
    {
        [Key]
        [Column("id")]
        public int ID { get; set; }
        [Column("Name")]
        public string Naam { get; set; }

        public Uitgeverij(int iD, string naam)
        {
            ID = iD;
            Naam = naam;
        }
        public Uitgeverij( string naam)
        {

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
