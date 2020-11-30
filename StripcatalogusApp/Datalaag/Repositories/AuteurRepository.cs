using DataLayer.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;
using Businesslaag.Models;
using Businesslaag.Repositories;
using Datalaag.Mappers;

using Datalaag.Models;

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
            using (var command = new SqlCommand("SELECT * FROM Auteur"))
            {
                return ConvertToBusinesslaag.ConvertToAuteurs((List<AuteurDB>)GetRecords(command));

            }
        }

        public Auteur GetById(int id)
        {
            // PARAMETERIZED QUERIES!
            using (var command = new SqlCommand("SELECT * FROM Auteur WHERE id = @id"))
            {
                command.Parameters.Add(new SqlParameter("id", id));
                return ConvertToBusinesslaag.ConvertToAuteur(GetRecord(command));
                
            }
        }

        public List<Auteur> GetStripAuteurs(int id)
        {
            var command = new SqlCommand("select * from Auteur join Strip_has_Auteur on auteur.id = Strip_has_Auteur.Auteur_id Where Strip_id = @id");
            command.Parameters.Add(new SqlParameter("id", id));
            return ConvertToBusinesslaag.ConvertToAuteurs((List<AuteurDB>)GetRecords(command));
        }

        #endregion

        public override AuteurDB PopulateRecord(SqlDataReader reader)
        {
            return new AuteurDB
            {
                ID = reader.GetInt32(0),
                Naam = reader.GetString(1)
            };
        }

        public void Add(Auteur auteur)
        {
          AuteurDB dbauteur =  ConvertToDatalayer.ConvertToAuteurDb(auteur);
            var sqlQueryBuilder = new SqlQueryBuilder<AuteurDB>(dbauteur);
            ExecuteCommand(sqlQueryBuilder.GetInsertCommand());
        }

        public void DeleteById(int id)
        {
            AuteurDB auteur = ConvertToDatalayer.ConvertToAuteurDb(GetById(id));
            var sqlQueryBuilder = new SqlQueryBuilder<AuteurDB>(auteur);
            ExecuteCommand(sqlQueryBuilder.GetDeleteCommand());
        }

        public void Update(Auteur Auteur) 
            {
            AuteurDB newAuteur = ConvertToDatalayer.ConvertToAuteurDb(Auteur);
                var command = new SqlCommand("update Auteur set Id = @id, Name = @name WHERE Id = @id");
                command.Parameters.Add(new SqlParameter("id", newAuteur.ID));
                command.Parameters.Add(new SqlParameter("name", newAuteur.Naam));
                ExecuteCommand(command);
            }

       
    }

    }

