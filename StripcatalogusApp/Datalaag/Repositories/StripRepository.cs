using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using businesslaag;
using Businesslaag;
using Businesslaag.Repositories;

namespace Datalaag.Repositories
{
    public class StripRepository : IStripRepository
    {
        private DbProviderFactory sqlFactory;
        private string connectionString;

        public StripRepository(DbProviderFactory sqlFactory, string connectionString)
        {
            this.sqlFactory = sqlFactory;
            this.connectionString = connectionString;
        }
        private DbConnection getConnection()
        {
            DbConnection connection = sqlFactory.CreateConnection();
            connection.ConnectionString = connectionString;
            return connection;
        }



        public void AddStrip(Strip strip)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Strip> FindAll_ByAuteur(Auteur auteur)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Strip> FindAll_ByReeks(Reeks reeks)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Strip> FindAll_strip()
        {
            //    DbConnection connection = getConnection();
            //    IList<Strip> lg = new List<Strip>();
            //    string query = "SELECT * FROM dbo.Strip";
            //    using (DbCommand command = connection.CreateCommand())
            //    {
            //        command.CommandText = query;
            //        connection.Open();
            //        try
            //        {
            //            IDataReader dataReader = command.ExecuteReader();
            //            while (dataReader.Read())
            //            {
            //                int id = (int)dataReader["id"];
            //                string titel = dataReader.GetString(1); //verschillende methodes om data op te vragen !
            //                int nr = (int)dataReader["Nummer"];
            //                int reeks_id = (int)dataReader["Reeks_id"];
            //                int uitgeverij_id = (int)dataReader["Uitgeverij_id"];

            //            }
            //            dataReader.Close();
            //        }
            //        catch (Exception ex)
            //        {
            //            Console.WriteLine(ex);
            //        }
            //        finally
            //        {
            //            connection.Close();
            //        }
            //    }
            //    return lg;
            throw new NotImplementedException();
        }

        public Strip FindStripById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveStripById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
