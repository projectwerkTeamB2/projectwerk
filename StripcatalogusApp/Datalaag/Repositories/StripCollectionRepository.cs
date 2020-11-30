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
            return new StripCollectionDB
            {
                Id = reader.GetInt32(0),
                Titel = reader.GetString(1),
                Nummer = reader.GetInt32(2),
                Uitgeverij = ConvertToDatalayer.ConvertToUitgeverijDb(new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()).GetById(reader.GetInt32(3))),

            };
        }

        #region Get

        public IEnumerable<StripCollection> GetAll()
        {
            using (var command = new SqlCommand("SELECT * FROM Strip"))
            {
                return ConvertToBusinesslaag.convertToCollections((List<StripCollectionDB>)GetRecords(command));
            }
        }


        public StripCollection GetById(int id)
        {
            // PARAMETERIZED QUERIES!
            using (var command = new SqlCommand("SELECT * FROM StripCollection WHERE id = @id"))
            {
                command.Parameters.Add(new SqlParameter("id", id));
                return ConvertToBusinesslaag.convertToStripCollection(GetRecord(command));
            }
        }

        #endregion


        #region add
        public void Add(StripCollection stripCollection)
        {
            StripCollectionDB stripCollectionDB = ConvertToDatalayer.ConvertToStripCollectionDB(stripCollection);
            var sqlQueryBuilder = new SqlQueryBuilder<StripCollectionDB>(stripCollectionDB);
            ExecuteCommand(sqlQueryBuilder.GetInsertCommand());
            AddStripHasCollectionHasStrip(stripCollectionDB);
        }

        private void AddStripHasCollectionHasStrip(StripCollectionDB collection)
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

        #endregion


        #region delete

        private void DeleteStripCollectionIdFromStripHasStripCollection(int id)
        {
            {
                var command = new SqlCommand("delete FROM Strip_has_Stripcollection_has_strip WHERE Strip_id = @id");
                command.Parameters.Add(new SqlParameter("id", id));
                ExecuteCommand(command);
            }
        }
        public void DeleteById(int id)
        {
            DeleteStripCollectionIdFromStripHasStripCollection(id);
            StripCollectionDB stripCollection = ConvertToDatalayer.ConvertToStripCollectionDB(GetById(id));
            var sqlQueryBuilder = new SqlQueryBuilder<StripCollectionDB>(stripCollection);
            ExecuteCommand(sqlQueryBuilder.GetDeleteCommand());
        }
    

    #endregion

    #region update

    public void Update(StripCollection collection)
    {
            StripCollectionDB newcollection = ConvertToDatalayer.ConvertToStripCollectionDB(collection);
        {
            var command = new SqlCommand("update Stripcollection set id = @id, Titel = @title, Nummer = @nummer, Uitgeverij_id = @uitgeverij WHERE id = @id");
            command.Parameters.Add(new SqlParameter("id", newcollection.Id));
            command.Parameters.Add(new SqlParameter("title", newcollection.Titel));
            command.Parameters.Add(new SqlParameter("nr", newcollection.Nummer));
            command.Parameters.Add(new SqlParameter("uitgeverij_id", newcollection.Uitgeverij.ID));

            ExecuteCommand(command);

                updateStripHasCollection(newcollection);
        }
    }

    private void updateStripHasCollection(StripCollectionDB newCollection)
    {
        SqlCommand deletecommand = new SqlCommand("delete from Strip_has_Stripcollection_has_strip where Stripcollection_has_strip_id=@Stripcollection_has_strip_id");
        deletecommand.Parameters.AddWithValue("Stripcollection_has_strip_id", newCollection.Id);
        ExecuteCommand(deletecommand);
        AddStripHasCollectionHasStrip(newCollection);
    }
}

    #endregion
}
 