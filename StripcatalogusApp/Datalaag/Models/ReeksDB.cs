using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Datalaag.Models
{
    [Table("Reeks")]
    public class ReeksDB
    {
        [Key]
        [Column("id")]
       
        public int ID { get; set; }
        [Column("Name")]
       
        public string Naam { get; set; }

        public ReeksDB(int iD, string naam)
        {
            ID = iD;
            Naam = naam;
        }

        public ReeksDB()
        {
        }
        public ReeksDB(string Naam)
        {
            this.Naam = Naam;
        }
        
    }
}
