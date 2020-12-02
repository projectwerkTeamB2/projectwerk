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
            try
            {
                // DBAs across the country are having strokes 
                //  over this next command!
                using var command = new SqlCommand("SELECT * FROM Reeks");
            return ConvertToBusinesslaag.ConvertToReeksen((List<ReeksDB>)GetRecords(command));
            }
            catch (Exception ex) { throw new Exception("Error in: IEnumerable<Reeks> GetAll() :: kon niet alle reeksen ophalen: " + ex); }

        }

        public Reeks GetById(int id)
        {
                try
                {
                    // PARAMETERIZED QUERIES!
                    using (var command = new SqlCommand("SELECT * FROM Reeks WHERE id = @id"))
            {
                command.Parameters.Add(new SqlParameter("id", id));
                return ConvertToBusinesslaag.ConvertToReeks(GetRecord(command));
                }
            }
            catch (Exception ex) { throw new Exception("Error in: Reeks GetById(int id):: kon niet reeks met deze id ophalen: " + ex); }

        }

        #endregion

        public override ReeksDB PopulateRecord(SqlDataReader reader)
        {
            try
            {
                return new ReeksDB
            {
                ID = reader.GetInt32(0),
                Naam = reader.GetString(1)
            };
            }
            catch (Exception ex) { throw new Exception("Error in: ReeksDB PopulateRecord(SqlDataReader reader) : " + ex); }

        }
        public void Add(Reeks reeks)
        {
            try
            {
                ReeksDB dbreeks = ConvertToDatalayer.ConvertToReeksDb(reeks);
                var sqlQueryBuilder = new SqlQueryBuilder<ReeksDB>(dbreeks);
                ExecuteCommand(sqlQueryBuilder.GetInsertCommand());
            }
            catch (Exception ex) { throw new Exception("Error in:   Add(Reeks reeks) :: kon reeks niet toevoegen: " + ex); }

        }

        public void DeleteById(int id)
        {
                    try
                    {
                        ReeksDB dbreeks = ConvertToDatalayer.ConvertToReeksDb(GetById(id));
            var sqlQueryBuilder = new SqlQueryBuilder<ReeksDB>(dbreeks);
            ExecuteCommand(sqlQueryBuilder.GetDeleteCommand());
            }
            catch (Exception ex) { throw new Exception("Error in:  DeleteById(int id) :: kon reeks niet verwijderen: " + ex); }

        }

        public void Update(Reeks Reeks) 
        {
                        try
                        {
                            
                ReeksDB newReeks = ConvertToDatalayer.ConvertToReeksDb(Reeks);
                var command = new SqlCommand("update Reeks set id = @id, Name = @name WHERE id = @id");
                command.Parameters.Add(new SqlParameter("id", newReeks.ID));
                command.Parameters.Add(new SqlParameter("name", newReeks.Naam));
                ExecuteCommand(command);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in:  Update(Reeks Reeks) :: kon Reeks niet updaten: " + ex);
            }
        }
    }
}