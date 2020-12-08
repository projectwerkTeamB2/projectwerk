using Businesslaag.Repositories;
using Businesslaag.Models;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using Datalaag.Models;
using Datalaag.Mappers;

namespace Datalaag.Repositories
{
    /// <summary>
    ///
    /// </summary>
    public class StripRepository : CRUDRepository<StripDB> , IStripRepository
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
                return ConvertToBusinesslaag.convertToStrips((List<StripDB>)GetRecords(command));
            }
        }
        public Strip GetLastStrip()
        {
            // DBAs across the country are having strokes 
            //  over this next command!
            using (var command = new SqlCommand("SELECT TOP 1 * FROM Strip ORDER BY ID DESC"))
            {
                return ConvertToBusinesslaag.convertToStrip(GetRecord(command));
            }
        }

        public Strip GetById(int id)
        {
            // PARAMETERIZED QUERIES!
            using (var command = new SqlCommand("SELECT * FROM Strip WHERE id = @id"))
            {
                command.Parameters.Add(new SqlParameter("id", id));
                return ConvertToBusinesslaag.convertToStrip(GetRecord(command));
            }
        }

        public List<Strip> GetCollectionStrips(int id)
        {
            try
            {

                var command = new SqlCommand("select* from Strip join Strip_has_Stripcollection_has_strip on Strip.id = Strip_has_Stripcollection_has_strip.Strip_id where Stripcollection_has_strip_id = @id");
                command.Parameters.Add(new SqlParameter("id", id));
                return ConvertToBusinesslaag.convertToStrips((List<StripDB>)GetRecords(command));
            }
            catch (Exception ex) { throw new Exception("insert decent error" + ex); }
        }


        #endregion
        public override StripDB PopulateRecord(SqlDataReader reader)
        {
            return new StripDB
            {
                ID = reader.GetInt32(0),
                StripTitel = reader.GetString(1),
                StripNr = reader.GetInt32(2),
                Reeks = ConvertToDatalayer.ConvertToReeksDb(new ReeksRepository(DbFunctions.GetprojectwerkconnectionString()).GetById(reader.GetInt32(3))),
                Uitgeverij = ConvertToDatalayer.ConvertToUitgeverijDb( new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()).GetById(reader.GetInt32(4))),
                Auteurs = ConvertToDatalayer.ConvertToAuteursDb(new AuteurRepository(DbFunctions.GetprojectwerkconnectionString()).GetStripAuteurs(reader.GetInt32(0)))

            };
        }

        #region Add
        public void Add(Strip strip)
        {
            StripDB stripDB = ConvertToDatalayer.convertToStripDb(strip);
            var sqlQueryBuilder = new SqlQueryBuilder<StripDB>(stripDB);
            ExecuteCommand(sqlQueryBuilder.GetInsertCommand());
            AddStripHasAuteur(stripDB);
        }

        private void AddStripHasAuteur(StripDB strip) 
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
        public void DeleteById(int id) 
        {
            DeleteStripIdFromStripHasAuteur(id);
          StripDB Stripdb = ConvertToDatalayer.convertToStripDb(GetById(id));
          var sqlQueryBuilder = new SqlQueryBuilder<StripDB>(Stripdb);
            ExecuteCommand(sqlQueryBuilder.GetDeleteCommand());
        }

        #endregion

        #region update

        public void Update(Strip strip)
        {
            StripDB newstrip = ConvertToDatalayer.convertToStripDb(strip);
            {
                var command = new SqlCommand("update Strip set id = @id, Titel = @title, Nummer = @nummer, Reeks_id = @reeks, Uitgeverij_id = @uitgeverij WHERE id = @id");
                command.Parameters.Add(new SqlParameter("id", newstrip.ID));
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

        private void updateAuteurStrip(StripDB newStrip) {
            SqlCommand deletecommand = new SqlCommand("delete from Strip_has_Auteur where Strip_id=@strip_id");
            deletecommand.Parameters.AddWithValue("strip_id", newStrip.ID);
            ExecuteCommand(deletecommand);
            AddStripHasAuteur(newStrip);
        }
    }
}