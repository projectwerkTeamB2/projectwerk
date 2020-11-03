using Datalaag.Models;
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
        public Strip GetLastStrip()
        {
            // DBAs across the country are having strokes 
            //  over this next command!
            using (var command = new SqlCommand("SELECT TOP 1 * FROM Strip ORDER BY ID DESC"))
            {
                return GetRecord(command);
            }
        }

        public Strip GetById(int id)
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

        #region Add
        public void AddStrip(Strip strip)
        {
           
            var sqlQueryBuilder = new SqlQueryBuilder<Strip>(strip);
            ExecuteCommand(sqlQueryBuilder.GetInsertCommand());
            AddStripHasAuteur(strip);

        }

        private void AddStripHasAuteur(Strip strip) 
        {
            
            for (int i = 0; i < strip.Auteurs.Count; i++)
            {
                SqlCommand command = new SqlCommand("Insert INTO Strip_has_Auteur values(@strip_id, @auteur_id)");
                command.Parameters.AddWithValue("strip_id", strip.ID);
                command.Parameters.AddWithValue("auteur_id", strip.Auteurs[i].ID);

                ExecuteCommand(command);
               
            }
          
            
               
            
        }

        #endregion

        #region Delete
        private void DeleteStripIdFromStripHasAuteur(int id) 
        {
            {
                var command = new SqlCommand("delete FROM Strip_has_Auteur WHERE Strip_id = @id");
                command.Parameters.Add(new SqlParameter("id", id));
                ExecuteCommand(command);
            }
        }
        public void DeleteStripById(int id) 
        {
            DeleteStripIdFromStripHasAuteur(id);
          Strip Strip = GetById(id);
          var sqlQueryBuilder = new SqlQueryBuilder<Strip>(Strip);
            ExecuteCommand(sqlQueryBuilder.GetDeleteCommand());
        }

        #endregion

        #region update

        public void updateStrip(int id, Strip newstrip)
        {
            {
                var command = new SqlCommand("update Strip set id = @id, Titel = @title, Nummer = @nummer, Reeks_id = @reeks, Uitgeverij_id = @uitgeverij WHERE id = @id");
                command.Parameters.Add(new SqlParameter("id", id));
                command.Parameters.Add(new SqlParameter("title", newstrip.StripTitel));
                command.Parameters.Add(new SqlParameter("nummer", newstrip.StripNr));
                command.Parameters.Add(new SqlParameter("reeks", newstrip.Reeks.ID));
                command.Parameters.Add(new SqlParameter("uitgeverij", newstrip.Uitgeverij.ID));
               
                ExecuteCommand(command);

                //Auteurs updaten
                updateAuteurStrip(newstrip);
            }
        }

        #endregion

        private void updateAuteurStrip(Strip newStrip) {
            for(int i = 0; i <= newStrip.Auteurs.Count; i++) {
                SqlCommand command = new SqlCommand("update Strip_has_Auteur SET Strip_Id=@strip_id, Auteur_Id=@auteur_id WHERE Strip_id=@strip_id");
                command.Parameters.AddWithValue("strip_id", newStrip.ID);
                command.Parameters.AddWithValue("auteur_id", newStrip.Auteurs[i].ID);

                ExecuteCommand(command);
            }
        }

    }
}