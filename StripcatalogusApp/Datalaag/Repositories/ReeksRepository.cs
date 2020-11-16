using Businesslaag.Repositories;
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
    public class ReeksRepository : CRUDRepository<Reeks> , IReeksRepository
    {
        public ReeksRepository(string connectionString)
    : base(connectionString)
        {
        }
        #region Get
        public IEnumerable<Reeks> GetAll()
        {
            // DBAs across the country are having strokes 
            //  over this next command!
            using (var command = new SqlCommand("SELECT * FROM Reeks"))
            {
                return GetRecords(command);
            }
        }

        public Reeks GetById(int id)
        {
            // PARAMETERIZED QUERIES!
            using (var command = new SqlCommand("SELECT * FROM Reeks WHERE id = @id"))
            {
                command.Parameters.Add(new SqlParameter("id", id));
                return GetRecord(command);
            }
        }

        #endregion

        public override Reeks PopulateRecord(SqlDataReader reader)
        {
            return new Reeks
            {
                ID = reader.GetInt32(0),
                Naam = reader.GetString(1)
            };
        }
        public void Add(Reeks reeks)
        {

            var sqlQueryBuilder = new SqlQueryBuilder<Reeks>(reeks);
            ExecuteCommand(sqlQueryBuilder.GetInsertCommand());
        }

        public void DeleteById(int id)
        {
            Reeks reeks = GetById(id);
            var sqlQueryBuilder = new SqlQueryBuilder<Reeks>(reeks);
            ExecuteCommand(sqlQueryBuilder.GetDeleteCommand());
        }

        public void Update(Reeks newReeks) 
        {
            {
                var command = new SqlCommand("update Reeks set id = @id, Name = @name WHERE id = @id");
                command.Parameters.Add(new SqlParameter("id", newReeks.ID));
                command.Parameters.Add(new SqlParameter("name", newReeks.Naam));
                ExecuteCommand(command);
            }
        }
    }
}