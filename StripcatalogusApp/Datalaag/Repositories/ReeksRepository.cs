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
    public class ReeksRepository : CRUDRepository<ReeksDB> , IReeksRepository
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
                return ConvertToBusinesslaag.ConvertToReeksen((List<ReeksDB>)GetRecords(command));
            }
        }

        public Reeks GetById(int id)
        {
            // PARAMETERIZED QUERIES!
            using (var command = new SqlCommand("SELECT * FROM Reeks WHERE id = @id"))
            {
                command.Parameters.Add(new SqlParameter("id", id));
                return ConvertToBusinesslaag.ConvertToReeks(GetRecord(command));
            }
        }

        #endregion

        public override ReeksDB PopulateRecord(SqlDataReader reader)
        {
            return new ReeksDB
            {
                ID = reader.GetInt32(0),
                Naam = reader.GetString(1)
            };
        }
        public void Add(Reeks reeks)
        {
            ReeksDB dbreeks = ConvertToDatalayer.ConvertToReeksDb(reeks);
            var sqlQueryBuilder = new SqlQueryBuilder<ReeksDB>(dbreeks);
            ExecuteCommand(sqlQueryBuilder.GetInsertCommand());
        }

        public void DeleteById(int id)
        {
            ReeksDB dbreeks = ConvertToDatalayer.ConvertToReeksDb(GetById(id));
            var sqlQueryBuilder = new SqlQueryBuilder<ReeksDB>(dbreeks);
            ExecuteCommand(sqlQueryBuilder.GetDeleteCommand());
        }

        public void Update(Reeks Reeks) 
        {
            {
                ReeksDB newReeks = ConvertToDatalayer.ConvertToReeksDb(Reeks);
                var command = new SqlCommand("update Reeks set id = @id, Name = @name WHERE id = @id");
                command.Parameters.Add(new SqlParameter("id", newReeks.ID));
                command.Parameters.Add(new SqlParameter("name", newReeks.Naam));
                ExecuteCommand(command);
            }
        }
    }
}