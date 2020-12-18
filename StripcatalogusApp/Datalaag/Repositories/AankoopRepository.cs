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
    public class AankoopRepository : CRUDRepository<AankoopDB>, IAankoopRepository {
        public AankoopRepository(string connectionString) : base(connectionString) { }

      
        public void Add(Aankoop aankoop) {
            try {
                AankoopDB dbAankoop = ConvertToDatalayer.ConvertToAankoopDb(aankoop);
                var sql = new SqlQueryBuilder<AankoopDB>(dbAankoop);
                ExecuteCommand(sql.GetInsertCommand());
            } catch (Exception ex) {
                throw new Exception("Error in: Add (Aankoop aankoop) :: kon aankoop niet toevoegen: " + ex);
            }
        }

        public void DeleteById(int id) {
            try {
                AankoopDB aankoopDB = ConvertToDatalayer.ConvertToAankoopDb(GetById(id));
                var sql = new SqlQueryBuilder<AankoopDB>(aankoopDB);
                ExecuteCommand(sql.GetDeleteCommand());
            } catch(Exception ex) {
                throw new Exception("Error in: DeleteById(int id) :: kon aankoop niet verwijderen: " + ex);
            }
        }

        public IEnumerable<Aankoop> GetAll() {
            try {
                using(var command = new SqlCommand("SELECT * from Aankoop")) {
                    return ConvertToBusinesslaag.ConvertToAankoopList((List<AankoopDB>)GetRecords(command));
                }
            } catch(Exception ex) {
                throw new Exception("Error in: AankoopRepository-GetAll() :: kon niet alle aankopen ophalen: " + ex);
            }
        }

        public Aankoop GetById(int id) {
            try {
                using(var command = new SqlCommand("SELECT * FROM Aankoop where id = @id")) {
                    command.Parameters.Add(new SqlParameter("id", id));
                    return ConvertToBusinesslaag.ConvertToAankoop(GetRecord(command));
                }
            } catch(Exception ex) {
                throw new Exception("Error in AankoopRepo-GetById(int id) :: kon aankoop met geslecteerde id niet opvragen: " + ex);
            }
        }

        public void Update(Aankoop aankoop) {
            try {
                AankoopDB aankoopDB = ConvertToDatalayer.ConvertToAankoopDb(aankoop);
                var command = new SqlCommand("update Aankoop set id = @id,  datumGeplaatst =@datumGeplaatst, datumOntvangen =@datumOntvangen, hoeveelheid=@hoeveelheid WHERE Id = @id");
                command.Parameters.Add(new SqlParameter("id", aankoopDB.ID));
                command.Parameters.Add(new SqlParameter("datumGeplaatst", aankoopDB.DatumGeplaatst));
                command.Parameters.Add(new SqlParameter("datumOntvangen", aankoopDB.DatumOntvangen));
                command.Parameters.Add(new SqlParameter("hoeveelheid", aankoopDB.Hoeveelheid));
                ExecuteCommand(command);
            }
            catch (Exception ex) {
                throw new Exception("Error in: Update(Auteur Auteur) :: kon aankoop niet updaten: " + ex);
            }
        }

        public override AankoopDB PopulateRecord(SqlDataReader reader) {
            try {
                return new AankoopDB
                {
                    ID = reader.GetInt32(0),
                    DatumGeplaatst = reader.GetDateTime(1),
                    DatumOntvangen = reader.GetDateTime(2),
                    Hoeveelheid = reader.GetInt32(3)
                };
            } catch(Exception ex) {
                throw new Exception("Error in: PopulateRecord(SqlDataReade reader): " + ex);
            }
        }
    }
}
