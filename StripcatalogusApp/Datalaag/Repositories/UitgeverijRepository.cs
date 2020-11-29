using Businesslaag.Models;
using Businesslaag.Repositories;
using Datalaag.Mappers;
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
    public class UitgeverijRepository : CRUDRepository<UitgeverijDB>, IUitgeverijRepository
    {
        public UitgeverijRepository(string connectionString)
    : base(connectionString)
        {
        }
        #region Get
        public IEnumerable<Uitgeverij> GetAll()
        {
            // DBAs across the country are having strokes 
            //  over this next command!
            using (var command = new SqlCommand("SELECT * FROM Uitgeverij"))
            {
                return ConvertToBusinesslaag.ConvertToUitgevers((List<UitgeverijDB>)GetRecords(command));
            }
        }

        public Uitgeverij GetById(int id)
        {
            // PARAMETERIZED QUERIES!
            using (var command = new SqlCommand("SELECT * FROM Uitgeverij WHERE id = @id"))
            {
                command.Parameters.Add(new SqlParameter("id", id));
                return ConvertToBusinesslaag.ConvertToUitgeverij(GetRecord(command));
            }
        }

        #endregion

        public override UitgeverijDB PopulateRecord(SqlDataReader reader)
        {
            return new UitgeverijDB
            {
                ID = reader.GetInt32(0),
                Naam = reader.GetString(1)
            };
        }

        public void Add(Uitgeverij uitgeverij)
        {
            UitgeverijDB uitgeverijDB = ConvertToDatalayer.ConvertToUitgeverijDb(uitgeverij);
            var sqlQueryBuilder = new SqlQueryBuilder<UitgeverijDB>(uitgeverijDB);
            ExecuteCommand(sqlQueryBuilder.GetInsertCommand());
        }

        public void DeleteById(int id) 
        {
            UitgeverijDB uitgeverijdb = ConvertToDatalayer.ConvertToUitgeverijDb(GetById(id));
            var sqlQueryBuilder = new SqlQueryBuilder<UitgeverijDB>(uitgeverijdb);
            ExecuteCommand(sqlQueryBuilder.GetDeleteCommand());
        }

        public void Update(Uitgeverij Uitgeverij) 
        {
            {
                UitgeverijDB newUitgeverij = ConvertToDatalayer.ConvertToUitgeverijDb(Uitgeverij);
                var command = new SqlCommand("update Uitgeverij set id = @id, Name = @name WHERE id = @id");
                command.Parameters.Add(new SqlParameter("id", newUitgeverij.ID));
                command.Parameters.Add(new SqlParameter("name", newUitgeverij.Naam));
                ExecuteCommand(command);
            }
        }
    }
}