using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Datalaag.Models
{
    [Table("Auteur")]
    public class AuteurDB
    {
        [Key]
        [Column("id")]
      
        public int ID { get; set; }
        [Column("Name")]
       
        public string Naam { get; set; }

        public AuteurDB(int iD, string naam)
        {
            ID = iD;
            Naam = naam;
        }
        public AuteurDB() 
        { }
        public AuteurDB(string naam)
        {
            this.Naam = naam;
        }

    }
}
