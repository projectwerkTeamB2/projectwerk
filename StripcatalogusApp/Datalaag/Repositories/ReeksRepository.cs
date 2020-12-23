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
    ///Alle functies om een reeks DB model in de database te krijgen. Implementeert de I reeks repository en de Crudrepostory
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
            catch (Exception ex) { throw new Exception("Error in: ReeksRepository- IEnumerable<Reeks> GetAll() :: kon niet alle reeksen ophalen: " + ex); }

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
            catch (Exception ex) { throw new Exception("Error in: ReeksRepository- Reeks GetById(int id):: kon niet reeks met deze id ophalen: " + ex); }

        }

        #endregion

        public override ReeksDB PopulateRecord(SqlDataReader reader)
        {
            // mapping model to database
            try
            {
                return new ReeksDB
            {
                ID = reader.GetInt32(0),
                Naam = reader.GetString(1)
            };
            }
            catch (Exception ex) { throw new Exception("Error in: ReeksRepository- ReeksDB PopulateRecord(SqlDataReader reader) : " + ex); }

        }
        public void Add(Reeks reeks)
        {
            // businesslaag model word eerst geconverteerd voor de sql builder het geconverteerde object toevoegt aan de databank.
            try
            {
                ReeksDB dbreeks = ConvertToDatalayer.ConvertToReeksDb(reeks);
                var sqlQueryBuilder = new SqlQueryBuilder<ReeksDB>(dbreeks);
                ExecuteCommand(sqlQueryBuilder.GetInsertCommand());
            }
            catch (Exception ex) { throw new Exception("Error in:   ReeksRepository- Add(Reeks reeks) :: kon reeks niet toevoegen: " + ex); }

        }

        public void DeleteById(int id)
        {
            //haalt de reeks op aan de hand van het gekregen id
            //convereert dfit naar een reeks DB object
            //verwijderd dit object uit de databank
                    try
                    {
                        ReeksDB dbreeks = ConvertToDatalayer.ConvertToReeksDb(GetById(id));
            var sqlQueryBuilder = new SqlQueryBuilder<ReeksDB>(dbreeks);
            ExecuteCommand(sqlQueryBuilder.GetDeleteCommand());
            }
            catch (Exception ex) { throw new Exception("Error in:  ReeksRepository- DeleteById(int id) :: kon reeks niet verwijderen: " + ex); }

        }

        public void Update(Reeks Reeks) 
        {
                        try
                        {
                            //krijgt een reeks businessmodel
                            //converteerd dit naar een DB model
                            // zet de id en naam van het giogehaalde object naar dat van het geconverteerde object
                ReeksDB newReeks = ConvertToDatalayer.ConvertToReeksDb(Reeks);
                var command = new SqlCommand("update Reeks set id = @id, Name = @name WHERE id = @id");
                command.Parameters.Add(new SqlParameter("id", newReeks.ID));
                command.Parameters.Add(new SqlParameter("name", newReeks.Naam));
                ExecuteCommand(command);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in:  ReeksRepository- Update(Reeks Reeks) :: kon Reeks niet updaten: " + ex);
            }
        }
    }
}