using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Datalaag.Models
{
    [Table("Uitgeverij")]
    public class UitgeverijDB
    {
        [Key]
        [Column("id")]
       
        public int ID { get; set; }
        [Column("Name")]
      
        public string Naam { get; set; }

        public UitgeverijDB(int iD, string naam)
        {
            ID = iD;
            Naam = naam;
        }
        public UitgeverijDB( string naam)
        {

            Naam = naam;
        }
        public UitgeverijDB()
        {
        }

    }
}
