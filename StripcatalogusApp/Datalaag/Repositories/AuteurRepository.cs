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
    public class AuteurRepository : CRUDRepository<Auteur>
    {
        public AuteurRepository(string connectionString)
   : base(connectionString)
        {
        }
        #region Get
        public IEnumerable<Auteur> GetAll()
        {
            // DBAs across the country are having strokes 
            //  over this next command!
            using (var command = new SqlCommand("SELECT * FROM Auteur"))
            {
                return GetRecords(command);
            }
        }

        public Auteur GetById(string id)
        {
            // PARAMETERIZED QUERIES!
            using (var command = new SqlCommand("SELECT * FROM auteur WHERE id = @id"))
            {
                command.Parameters.Add(new SqlParameter("id", id));
                return GetRecord(command);
            }
        }

        #endregion

        public override Auteur PopulateRecord(SqlDataReader reader)
        {
            return new Auteur
            {
                ID = reader.GetInt32(0),
                Naam = reader.GetString(1)
            };
        }

        public List<Auteur> GetStripAuteurs( int id) 
        {
            var command = new SqlCommand("select * from Auteur join Strip_has_Auteur on auteur.id = Strip_has_Auteur.Auteur_id Where Strip_id = @id");
            command.Parameters.Add(new SqlParameter("id", id));
            return (List<Auteur>)GetRecords(command);




        }

    }
}
