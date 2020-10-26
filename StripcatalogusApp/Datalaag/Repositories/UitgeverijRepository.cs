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
    public class UitgeverijRepository : CRUDRepository<Uitgeverij>
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
            using (var command = new SqlCommand("SELECT * FROM Auteur"))
            {
                return GetRecords(command);
            }
        }

        public Uitgeverij GetById(int id)
        {
            // PARAMETERIZED QUERIES!
            using (var command = new SqlCommand("SELECT * FROM Uitgeverij WHERE id = @id"))
            {
                command.Parameters.Add(new SqlParameter("id", id));
                return GetRecord(command);
            }
        }

        #endregion

        public override Uitgeverij PopulateRecord(SqlDataReader reader)
        {
            return new Uitgeverij
            {
                ID = reader.GetInt32(0),
                Naam = reader.GetString(1)
            };
        }

        public void addUitgeverij(Uitgeverij uitgeverij)
        {

            var sqlQueryBuilder = new SqlQueryBuilder<Uitgeverij>(uitgeverij);
            ExecuteCommand(sqlQueryBuilder.GetInsertCommand());
        }

    }
}