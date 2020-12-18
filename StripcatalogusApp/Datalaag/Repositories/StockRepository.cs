using Businesslaag.Models;
using Businesslaag.Repositories;
using Datalaag.Mappers;
using Datalaag.Models;
using DataLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Datalaag.Repositories {
    public class StockRepository: CRUDRepository<StockDB>, IStockRepository {
        public StockRepository(string connectionString) : base(connectionString) { }

        public List<Stock> GetAll()
        {
            try
            {
                List<Stock> stocklist = new List<Stock>();
                using var command = new SqlCommand("SELECT * FROM Stock");
                return stocklist.Add(ConvertToBusinesslaag.ConvertToStock((StockDB)GetRecords(command)));
            }
            catch (Exception ex) { throw new Exception("Error in: StockRepository-  GetAll() :: kon niet stock ophalen: " + ex); }

        }

        public Stock GetById(int id)
        {
            try
            {
                // PARAMETERIZED QUERIES!
                using (var command = new SqlCommand("SELECT * FROM Reeks WHERE id = @id"))
                {
                    command.Parameters.Add(new SqlParameter("id", id));
                    return ConvertToBusinesslaag.ConvertToStock(GetRecord(command));
                }
            }
            catch (Exception ex) { throw new Exception("Error in: Stockrepo- Stock GetById(int id):: kon niet stock met deze id ophalen: " + ex); }

        }

        public void Add(Stock stock)
        {
            try
            {
                StockDB dbstock = ConvertToDatalayer.ConvertToStockDB(stock);
                var sqlQueryBuilder = new SqlQueryBuilder<StockDB>(dbstock);
                ExecuteCommand(sqlQueryBuilder.GetInsertCommand());
            }
            catch (Exception ex) { throw new Exception("Error in:   StockDb- Add() :: kon Stock niet toevoegen: " + ex); }

        }

        public void DeleteById(int id)
        {
            try
            {
                StockDB dbstock = ConvertToDatalayer.ConvertToStockDB(GetById(id));
                var sqlQueryBuilder = new SqlQueryBuilder<StockDB>(dbstock);
                ExecuteCommand(sqlQueryBuilder.GetDeleteCommand());
            }
            catch (Exception ex) { throw new Exception("Error in:  StockRepository- DeleteById(int id) :: kon stock niet verwijderen: " + ex); }

        }

        public void Update(Stock stock)
        {
            try
            {

                StockDB newReeks = ConvertToDatalayer.ConvertToStockDB(stock);
                var command = new SqlCommand("update Reeks set id = @id, Name = @name WHERE id = @id");
                command.Parameters.Add(new SqlParameter("id", newReeks.StripHoeveelHeden.Keys));
                command.Parameters.Add(new SqlParameter("hoeveelheid", newReeks.StripHoeveelHeden.Values));
                ExecuteCommand(command);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in:  Stockrepo- Update(Stock stock) :: kon Stock niet updaten: " + ex);
            }
        }
    }
}
