using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using Businesslaag.Repositories;
using System.Text;
using Businesslaag.Models;
using Datalaag.Models;
using Datalaag.Mappers;
using System.Data.SqlClient;

namespace Datalaag.Repositories
{
    /// <summary>
    ///
    /// </summary>
    public class StripCollectionRepository : CRUDRepository<StripCollectionDB>, IStripCollectionRepository
    {
        public StripCollectionRepository(string connectionString)
  : base(connectionString)
        {
        }

        public override StripCollectionDB PopulateRecord(SqlDataReader reader)
        {
            try { 
                    return new StripCollectionDB
                {
                    Id = reader.GetInt32(0),
                    Titel = reader.GetString(1),
                    Nummer = reader.GetInt32(2),
                    Uitgeverij = ConvertToDatalayer.ConvertToUitgeverijDb(new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()).GetById(reader.GetInt32(3))),
                    Strips = ConvertToDatalayer.convertToStripsDb(new StripRepository(DbFunctions.GetprojectwerkconnectionString()).GetCollectionStrips(reader.GetInt32(0)))

                    };
            }
            catch (Exception ex) { throw new Exception("Error in: StripCollectionRepository- StripCollectionDB PopulateRecord(SqlDataReader reader) : " + ex); }

        }

        #region Get

        public IEnumerable<StripCollection> GetAll()
        {
            try
            {
                using (var command = new SqlCommand("select * from Stripcollection"))
                {
                    return ConvertToBusinesslaag.convertToCollections((List<StripCollectionDB>)GetRecords(command));
                } 
            }
            catch (Exception ex) { throw new Exception("Error in:  StripCollectionRepository-IEnumerable<StripCollection> GetAll() :: kon niet alle stripcollections opvragen " + ex); }

        }

        public StripCollection GetById(int id)
        {
                    try
                    {
                        // PARAMETERIZED QUERIES!
                        using (var command = new SqlCommand("SELECT * FROM StripCollection WHERE id = @id"))
            {
                command.Parameters.Add(new SqlParameter("id", id));
                return ConvertToBusinesslaag.convertToStripCollection(GetRecord(command));
                }
            }
            catch (Exception ex) { throw new Exception("Error in: StripCollectionRepository-StripCollection GetById(int id) :: kon niet StripCollection met deze id ophalen: " + ex); }

        }

    
        #endregion


        #region add
        public void Add(StripCollection stripCollection)
        {
            try
            {
                StripCollectionDB stripCollectionDB = ConvertToDatalayer.ConvertToStripCollectionDB(stripCollection);
                var sqlQueryBuilder = new SqlQueryBuilder<StripCollectionDB>(stripCollectionDB);
                ExecuteCommand(sqlQueryBuilder.GetInsertCommand());
                AddStripHasCollectionHasStrip(stripCollectionDB);
            }
            catch (Exception ex) { throw new Exception("Error in: StripCollectionRepository-StripCollection  Add(StripCollection stripCollection) :: kon  StripCollection niet toevoegen: " + ex); }


        }

        private void AddStripHasCollectionHasStrip(StripCollectionDB collection)
        {
                            try
                            {

                                for (int i = 0; i < collection.Strips.Count; i++)
            {
                SqlCommand command = new SqlCommand("Insert INTO Strip_has_Stripcollection_has_strip values(@strip_id, @reeks_id, @collection_id)");
                command.Parameters.AddWithValue("strip_id", collection.Strips[i].ID);
                command.Parameters.AddWithValue("reeks_id", collection.Strips[i].Reeks.ID);
                command.Parameters.AddWithValue("collection_id", collection.Id);
                ExecuteCommand(command);

                }
            }
            catch (Exception ex) { throw new Exception("Error in: StripCollectionRepository-AddStripHasCollectionHasStrip(StripCollectionDB collection): " + ex); }


        }

        #endregion


        #region delete

        private void DeleteStripCollectionIdFromStripHasStripCollection(int id)
        {
                                try
                                {
                                    {
                var command = new SqlCommand("delete FROM Strip_has_Stripcollection_has_strip WHERE Strip_id = @id");
                command.Parameters.Add(new SqlParameter("id", id));
                ExecuteCommand(command);
                }
            }
            catch (Exception ex) { throw new Exception("Error in: StripCollectionRepository-DeleteStripCollectionIdFromStripHasStripCollection(int id) :: kon StripCollection niet deleten: " + ex); }

        }
        public void DeleteById(int id)
        {
            try { 
            DeleteStripCollectionIdFromStripHasStripCollection(id);
            StripCollectionDB stripCollection = ConvertToDatalayer.ConvertToStripCollectionDB(GetById(id));
            var sqlQueryBuilder = new SqlQueryBuilder<StripCollectionDB>(stripCollection);
            ExecuteCommand(sqlQueryBuilder.GetDeleteCommand());
            }
            catch (Exception ex) { throw new Exception("Error in: StripCollectionRepository-DeleteById(int id) :: kon StripCollection niet deleten: " + ex); }

        }


        #endregion

        #region update

        public void Update(StripCollection collection)
    {
                                    try
                                    {
                                        StripCollectionDB newcollection = ConvertToDatalayer.ConvertToStripCollectionDB(collection);
        {
            var command = new SqlCommand("update Stripcollection set id = @id, title = @title, nr = @nummer, Uitgeverij_id = @uitgeverij WHERE id = @id");
            command.Parameters.Add(new SqlParameter("id", newcollection.Id));
            command.Parameters.Add(new SqlParameter("title", newcollection.Titel));
            command.Parameters.Add(new SqlParameter("nummer", newcollection.Nummer));
            command.Parameters.Add(new SqlParameter("uitgeverij", newcollection.Uitgeverij.ID));

            ExecuteCommand(command);

                updateStripHasCollection(newcollection);
                }
            }
            catch (Exception ex) { throw new Exception("Error in: StripCollectionRepository-Update(StripCollection collection) :: kon StripCollection niet updaten: " + ex); }

        }

        private void updateStripHasCollection(StripCollectionDB newCollection)
        {
            try
            {
                SqlCommand deletecommand = new SqlCommand("delete from Strip_has_Stripcollection_has_strip where Stripcollection_has_strip_id=@Stripcollection_has_strip_id");
                deletecommand.Parameters.AddWithValue("Stripcollection_has_strip_id", newCollection.Id);
                ExecuteCommand(deletecommand);
                AddStripHasCollectionHasStrip(newCollection);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in: StripCollectionRepository-updateStripHasCollection(StripCollectionDB newCollection) :: kon StripCollection niet updaten: " + ex);
            }
        }

}

    #endregion
}
 