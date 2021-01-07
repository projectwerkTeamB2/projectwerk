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
    public class VerkoopRepository : CRUDRepository<VerkoopDB>, IVerkoopRepository {
        public VerkoopRepository(string connectionString):base(connectionString) { }

        public void Add(Verkoop verkoop) {
            try {
                VerkoopDB dbVerkoop = ConvertToDatalayer.ConvertToVerkoopDb(verkoop);
                var sql = new SqlQueryBuilder<VerkoopDB>(dbVerkoop);
                ExecuteCommand(sql.GetInsertCommand());
            } catch (Exception ex) {
                throw new Exception("Error in: Add(Verkoop verkoop) :: kon verkoop niet toevoegen: " + ex);
            }
        }

        public void DeleteById(int id) {
           try {
                VerkoopDB verkoopDB = ConvertToDatalayer.ConvertToVerkoopDb(GetById(id));
                var sql = new SqlQueryBuilder<VerkoopDB>(verkoopDB);
                ExecuteCommand(sql.GetDeleteCommand());
            } catch (Exception ex) {
                throw new Exception("Error in: DeleteById(int id) :: kon verkoop niet verwijderen: " + ex);
            }
        }

        public IEnumerable<Verkoop> GetAll() {
            try {
                using(var command = new SqlCommand("SELECT * FROM Verkoop")) {
                    return ConvertToBusinesslaag.ConvertToVerkoopList((List<VerkoopDB>)GetRecords(command));
                }
            } catch(Exception ex) {
                throw new Exception("Error in: VerkoopRepo-GetAll() :: kon niet alle verkopen ophalen: " + ex);
            }
        }

        public Verkoop GetById(int id) {
            try {
                using(var command = new SqlCommand("SELECT * FROM Verkoop where id = @id")) {
                    command.Parameters.Add(new SqlParameter("id", id));
                    return ConvertToBusinesslaag.ConvertToVerkoop(GetRecord(command));
                }
            } catch (Exception ex) {
                throw new Exception("Error in VerkoopRepo-GetById(int id) :: kon gezochte verkoop niet opvragen: " + ex);
            }
        }

        public override VerkoopDB PopulateRecord(SqlDataReader reader) {
            try {
                return new VerkoopDB
                {
                    ID = reader.GetInt32(0),
                    DatumBestelling = reader.GetDateTime(1),
                    Hoeveelheid = reader.GetInt32(2)
                };
            } catch(Exception ex) {
                throw new Exception("Error in: PopulateRecord(SqlDataReader reader): " + ex);
            }
        }

        public void Update(Verkoop verkoop) {
            try {
                VerkoopDB verkoopDB = ConvertToDatalayer.ConvertToVerkoopDb(verkoop);
                var command = new SqlCommand("UPDATE Verkoop set id=@id, datumBestelling=@datumBestelling, hoeveelheid=@hoeveelheid");
                command.Parameters.Add(new SqlParameter("id", verkoopDB.ID));
                command.Parameters.Add(new SqlParameter("datumBestelling", verkoopDB.DatumBestelling));
                command.Parameters.Add(new SqlParameter("hoeveelheid", verkoopDB.Hoeveelheid));
                ExecuteCommand(command);
            } catch (Exception ex) {
                throw new Exception("Error in: Update(Verkoop verkoop) :: kon verkoop niet updaten: " + ex);
            }
        }
    }
}
