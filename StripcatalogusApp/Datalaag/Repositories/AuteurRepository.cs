using DataLayer.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;
using Businesslaag.Models;
using Businesslaag.Repositories;
using Datalaag.Mappers;

using Datalaag.Models;
using System;

namespace Datalaag.Repositories
{
    /// <summary>
    ///
    /// </summary>
    public class AuteurRepository : CRUDRepository<AuteurDB> , IAuteurRepository
    {
        public AuteurRepository(string connectionString)
   : base(connectionString)
        {
        }
        #region Get
        public IEnumerable<Auteur> GetAll()
        {
            // DBAs across the country are having strokes 
            //  over this next command!
            try
            {
                using (var command = new SqlCommand("SELECT * FROM Auteur"))
                {
                    return ConvertToBusinesslaag.ConvertToAuteurs((List<AuteurDB>)GetRecords(command));

                }
            }
            catch (Exception ex) { throw new Exception("Error in: AuteurRepository-GetAll() :: kon niet alle auteurs ophalen: " + ex); }
        }

        public Auteur GetById(int id)
        {
            try
            {
                // PARAMETERIZED QUERIES!
                using (var command = new SqlCommand("SELECT * FROM Auteur WHERE id = @id"))
                {
                    command.Parameters.Add(new SqlParameter("id", id));
                    return ConvertToBusinesslaag.ConvertToAuteur(GetRecord(command));

                }
            }catch (Exception ex) { throw new Exception("Error in: AuteurRepository-GetById(int id) :: kon niet auteur met deze id ophalen: " + ex); }
        }

        public List<Auteur> GetStripAuteurs(int id)
        {
            try { 
            var command = new SqlCommand("select * from Auteur join Strip_has_Auteur on auteur.id = Strip_has_Auteur.Auteur_id Where Strip_id = @id");
            command.Parameters.Add(new SqlParameter("id", id));
            return ConvertToBusinesslaag.ConvertToAuteurs((List<AuteurDB>)GetRecords(command));
            }
            catch (Exception ex) { throw new Exception("Error in: GetStripAuteurs(int id) :: kon niet lijst met auteurs ophalen: " + ex); }
        }

        #endregion

        public override AuteurDB PopulateRecord(SqlDataReader reader)
        {
            try
            {
                return new AuteurDB
                {
                    ID = reader.GetInt32(0),
                    Naam = reader.GetString(1)
                };
            }catch (Exception ex) { throw new Exception("Error in: PopulateRecord(SqlDataReader reader) : " + ex); }
        }

        public void Add(Auteur auteur)
        {
            try
            {
                AuteurDB dbauteur =  ConvertToDatalayer.ConvertToAuteurDb(auteur);
            var sqlQueryBuilder = new SqlQueryBuilder<AuteurDB>(dbauteur);
            ExecuteCommand(sqlQueryBuilder.GetInsertCommand());
            }
            catch (Exception ex) { throw new Exception("Error in:  Add(Auteur auteur) :: kon auteur niet toevoegen: " + ex); }
        }

        public void DeleteById(int id)
            {
                try
                {
                    AuteurDB auteur = ConvertToDatalayer.ConvertToAuteurDb(GetById(id));
            var sqlQueryBuilder = new SqlQueryBuilder<AuteurDB>(auteur);
            ExecuteCommand(sqlQueryBuilder.GetDeleteCommand());
            }catch (Exception ex) { throw new Exception("Error in:  DeleteById(int id) :: kon auteur niet verwijderen: " + ex); }
        }

        public void Update(Auteur Auteur)
        {
            try
            {
                AuteurDB newAuteur = ConvertToDatalayer.ConvertToAuteurDb(Auteur);
                var command = new SqlCommand("update Auteur set Id = @id, Name = @name WHERE Id = @id");
                command.Parameters.Add(new SqlParameter("id", newAuteur.ID));
                command.Parameters.Add(new SqlParameter("name", newAuteur.Naam));
                ExecuteCommand(command);
            }
            catch (Exception ex)
            {
                throw new Exception("Error in: Update(Auteur Auteur) :: kon auteur niet updaten: " + ex);
            }
        }


}

    }

