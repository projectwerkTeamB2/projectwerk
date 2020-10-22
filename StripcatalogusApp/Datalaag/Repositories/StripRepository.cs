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
                ID = reader.GetInt32(0),
                StripTitel = reader.GetString(1),
                StripNr = reader.GetInt32(2),
                Reeks = new ReeksRepository(DbFunctions.GetprojectwerkconnectionString()).GetById(reader.GetInt32(3)),
                Uitgeverij = new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()).GetById(reader.GetInt32(4)),
                Auteurs = new AuteurRepository(DbFunctions.GetprojectwerkconnectionString()).GetStripAuteurs(reader.GetInt32(0))

            };
        }
        public void AddStrip(Strip strip)
        {
           
            var sqlQueryBuilder = new SqlQueryBuilder<Strip>(strip);
            ExecuteCommand(sqlQueryBuilder.GetInsertCommand());
            UpdateStripHasAuteur(strip);

        }

        private void UpdateStripHasAuteur(Strip strip) 
        {
            
            for (int i = 0; i < strip.Auteurs.Count; i++)
            {
                SqlCommand command = new SqlCommand("Insert INTO Strip_has_Auteur values(@strip_id, @auteur_id)");
                command.Parameters.AddWithValue("strip_id", strip.ID);
                command.Parameters.AddWithValue("auteur_id", strip.Auteurs[i].ID);

                ExecuteCommand(command);
               
            }
          
            
               
            
        }
    }
}