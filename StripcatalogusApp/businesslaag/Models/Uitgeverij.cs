using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Businesslaag.Models
{
    /// <summary>
    /// business klasse voor uitgeverij
    /// </summary>
    public class Uitgeverij
    {
     
        public int ID { get; set; }
       
        public string Naam { get; set; }

        public Uitgeverij(int id, string naam)
        {
            ID = id;
            //checkt businessregek dat de naam niet leeg mag zijn en geeft anders een error
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
