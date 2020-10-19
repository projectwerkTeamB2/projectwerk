using Businesslaag.Models;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Datalaag.Repositories
{
    /// <summary>
    ///
    /// </summary>
    public class StripRepository : CRUDRepository<Strip>
    {
        public StripRepository(string connectionString)
         : base(connectionString)
        {
        }
        #region Get
        public IEnumerable<Strip> GetAll()
        {
            // DBAs across the country are having strokes 
            //  over this next command!
            using (var command = new SqlCommand("SELECT * FROM Strip"))
            {
                return GetRecords(command);
            }
        }

        public Strip GetById(string id)
        {
            // PARAMETERIZED QUERIES!
            using (var command = new SqlCommand("SELECT * FROM Strip WHERE id = @id"))
            {
                command.Parameters.Add(new SqlParameter("id", id));
                return GetRecord(command);
            }
        }

        #endregion
        public override Strip PopulateRecord(SqlDataReader reader)
        {
            return new Strip
            {
                ID = reader.GetInt32(1),
                StripTitel = reader.GetString(2)
             //  public List<Auteur> Auteurs { get; set; } //er kunnen meerdere zijn
             //    public Reeks Reeks { get; set; }
                 public int StripNr { get; set; }
               //  public Uitgeverij Uitgeverij { get; set; }
    };
     
}
}