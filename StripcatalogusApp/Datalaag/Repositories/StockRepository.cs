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

        public Stock GetAll()
        {
            try
            {
                Dictionary<Strip,int> stocklist = new Dictionary<Strip,int>();
                using var command = new SqlCommand("select id, Titel, Nummer,Reeks_id, isEenLosseStrip, Uitgeverij_id from Stock sto join Strip st on sto.Strip_id = st.id");
                List<Strip> liststrips = ConvertToBusinesslaag.convertToStrips((List<StripDB>)GetRecords(command));
                using var command2 = new SqlCommand("select Hoeveelheid from Stock");
                List<int> listhoeveelheid = (List<int>)GetRecords(command2);
                for (int i = 0; i < liststrips.Count; i++)
                {
                    stocklist.Add(liststrips[i], listhoeveelheid[i]);
                }

                return new Stock(stocklist);
            }
            catch (Exception ex) { throw new Exception("Error in: StockRepository-  GetAll() :: kon niet stock ophalen: " + ex); }

        }

        public Dictionary<Strip,int> GetAllDictionary()
        {
            try
            {
                Dictionary<Strip, int> stocklist = new Dictionary<Strip, int>();
                using var command = new SqlCommand("select id, Titel, Nummer,Reeks_id, isEenLosseStrip, Uitgeverij_id from Stock sto join Strip st on sto.Strip_id = st.id");
                List<Strip> liststrips = ConvertToBusinesslaag.convertToStrips((List<StripDB>)GetRecords(command));
                using var command2 = new SqlCommand("select Hoeveelheid from Stock");
                List<int> listhoeveelheid = (List<int>)GetRecords(command2);
                for (int i = 0; i < liststrips.Count; i++)
                {
                    stocklist.Add(liststrips[i], listhoeveelheid[i]);
                }

                return stocklist;
            }
            catch (Exception ex) { throw new Exception("Error in: StockRepository-  GetAllInDictionaryVorm() :: kon niet stock ophalen: " + ex); }



        }

        public Dictionary<Strip, int> GetById(int id)
        {
            try
            {

                using var command = new SqlCommand("select Hoeveelheid from Stock WHERE id=@id");
                using var command2 = new SqlCommand("select id, Titel, Nummer,Reeks_id, isEenLosseStrip, Uitgeverij_id from Stock sto join Strip st on sto.Strip_id = st.id WHERE id=@id");
                command.Parameters.Add(new SqlParameter("id", id));
                command2.Parameters.Add(new SqlParameter("id", id));
                Strip strip = ConvertToBusinesslaag.convertToStrip((StripDB)GetRecord(command2));
                int hoeveelheid = ConvertToBusinesslaag.ConvertToStock(GetRecord(command)).StripHoeveelHeden[strip];
                Dictionary<Strip, int> dict = new Dictionary<Strip, int>();
                dict.Add(strip, hoeveelheid);
                return dict; 

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

        public void AddDictionary(Dictionary<Strip, int> dict)
        {
            try
            {
               // StockDB dbstock = ConvertToDatalayer.ConvertToStockDB(stock);
                var sqlQueryBuilder = new SqlQueryBuilder<Dictionary<Strip,int>>(dict);
                ExecuteCommand(sqlQueryBuilder.GetInsertCommand());
            }
            catch (Exception ex) { throw new Exception("Error in:   StockDb- Add() :: kon Stock niet toevoegen: " + ex); }

        }

        public void DeleteById(int id)
        {
            try
            {
                Dictionary<Strip,int> stockDict = GetById(id);
                var sqlQueryBuilder = new SqlQueryBuilder<Dictionary<Strip, int>>(stockDict);
                ExecuteCommand(sqlQueryBuilder.GetDeleteCommand());
            }
            catch (Exception ex) { throw new Exception("Error in:  StockRepository- DeleteById(int id) :: kon stock niet verwijderen: " + ex); }

        }



        public void Update(Stock stock)
        {
            /*    try
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
                }*/
            throw new NotImplementedException();
        }

        public void Update(int id)
        {

            Dictionary<Strip, int> stockDict = GetById(id);
            var sqlQueryBuilder = new SqlQueryBuilder<Dictionary<Strip, int>>(stockDict);
            ExecuteCommand(sqlQueryBuilder.GetUpdateCommand());
        }

        IEnumerable<Stock> IRepository<Stock>.GetAll()
        {
            throw new NotImplementedException();
        }

        Stock IRepository<Stock>.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
