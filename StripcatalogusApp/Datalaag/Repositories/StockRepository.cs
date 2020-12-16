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

        public override StockDB PopulateRecord(SqlDataReader reader) {
            return base.PopulateRecord(reader);
            //Try catch zoals in andere managers
            //Weet niet hoe of wat met die strip
            /*try {
                return new StockDB
                {
                    Strip = ConvertToDatalayer.convertToStripDb(DbFunctions.GetprojectwerkconnectionString().GetById(reader.GetInt32(0));
                    Hoeveelheid = reader.GetInt32(1);
                }
            }*/
        }

        public void Add(Stock stock) {
            try {
                StockDB dbStock = ConvertToDatalayer.ConvertToStockDB(stock);
                var SqlBuilder = new SqlQueryBuilder<StockDB>(dbStock);
                ExecuteCommand(SqlBuilder.GetInsertCommand());
            } catch(Exception ex) {
                throw new Exception("Error in : Add(Stock stock) :: kon stock niet toevoegen: " + ex);
            }
        }

        public void Update(Stock entity) {
            throw new NotImplementedException();
        }

        //I DONT KNOW: Delete by id? geen stock id => gebruiken id van strip
        public void DeleteById(int id) {
            throw new NotImplementedException();
        }

        public Stock GetById(int id) {
            throw new NotImplementedException();
        }

        public IEnumerable<Stock> GetAll() {
            throw new NotImplementedException();
        }

        
    }
}
