using DataLayer.Repositories;
using System.Collections.Generic;
using System.Data.SqlClient;
using Businesslaag.Models;
using Businesslaag.Repositories;
using System.Linq.Expressions;
using System;

namespace Datalaag.Repositories
{
    /// <summary>
    ///
    /// </summary>
    public class AuteurRepository : CRUDRepository<Auteur> , IAuteurRepository
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
                return GetRecords(command);
            }
        }

        public Auteur GetById(int id)
        {
            // PARAMETERIZED QUERIES!
            using (var command = new SqlCommand("SELECT * FROM Auteur WHERE id = @id"))
            {
                command.Parameters.Add(new SqlParameter("id", id));
                return GetRecord(command);
            }
        }

        public List<Auteur> GetStripAuteurs(int id)
        {
            var command = new SqlCommand("select * from Auteur join Strip_has_Auteur on auteur.id = Strip_has_Auteur.Auteur_id Where Strip_id = @id");
            command.Parameters.Add(new SqlParameter("id", id));
            return (List<Auteur>)GetRecords(command);
        }

        #endregion

        public override Auteur PopulateRecord(SqlDataReader reader)
        {
            return new Auteur
            {
                ID = reader.GetInt32(0),
                Naam = reader.GetString(1)
            };
        }

        public void Add(Auteur auteur)
        {

            var sqlQueryBuilder = new SqlQueryBuilder<Auteur>(auteur);
            ExecuteCommand(sqlQueryBuilder.GetInsertCommand());
        }

        public void DeleteById(int id)
        {
            Auteur auteur = GetById(id);
            var sqlQueryBuilder = new SqlQueryBuilder<Auteur>(auteur);
            ExecuteCommand(sqlQueryBuilder.GetDeleteCommand());
        }

        public void Update(Auteur newAuteur) 
            {
                var command = new SqlCommand("update Auteur set Id = @id, Name = @name WHERE Id = @id");
                command.Parameters.Add(new SqlParameter("id", newAuteur.ID));
                command.Parameters.Add(new SqlParameter("name", newAuteur.Naam));
                ExecuteCommand(command);
            }

       
    }

    }

