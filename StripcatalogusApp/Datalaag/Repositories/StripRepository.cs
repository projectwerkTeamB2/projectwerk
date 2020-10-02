using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using businesslaag;
using Businesslaag;
using Businesslaag.Repositories;

namespace Datalaag.Repositories
{
    public class StripRepository : IStripRepository
    {
    
       private string connectionString;
        #region
           private DbProviderFactory sqlFactory;
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
        #endregion ljena connetion code


        public void allesWegSchijvenNaarDataBank(List<Strip> strips)
        {

            Dictionary<int, Auteur> dictAuteurs = new Dictionary<int, Auteur>();
            Dictionary<int, Uitgeverij> dictUitgeverij = new Dictionary<int, Uitgeverij>();
            Dictionary<int, Reeks> dictReeks = new Dictionary<int, Reeks>();
            int tellerAut = 1;
            int tellerUit = 1;
            int tellerRks = 1;
            foreach (Strip s in strips)
            {
                foreach (Auteur a in s.Auteurs)
                {
                    if (!dictAuteurs.ContainsValue(a))
                    {
                        dictAuteurs.Add(tellerAut,a);
                    }
                }
                if (!dictUitgeverij.ContainsValue(s.Uitgeverij))
                {
                    dictUitgeverij.Add(tellerUit, s.Uitgeverij);
                }
                if (!dictReeks.ContainsValue(s.Reeks))
                {
                    dictReeks.Add(tellerRks, s.Reeks);
                }

            }

                DbConnection connection = getConnection();

            string query0 = "INSERT INTO dbo.Strip (id,Titel,Nummer,Reeks_id,Uitgeverij_id)"
                 + "VALUES(@id,@Titel,@Nummer,@Reeks_id,@Uitgeverij_id)";

            string query2 = "INSERT INTO dbo.Strip (Titel,Nummer,Reeks_id,Uitgeverij_id)"
                 + "VALUES(@Titel,@Nummer,@Reeks_id,@Uitgeverij_id)";
            using (DbCommand command = connection.CreateCommand())
            {
                connection.Open();
                try
                {
                    command.CommandText = query2;


              //      DbParameter id1 = sqlFactory.CreateParameter();
               //     id1.ParameterName = "@id";
              //      id1.DbType = DbType.Int32;
               //     command.Parameters.Add(id1);

                    DbParameter Titel1 = sqlFactory.CreateParameter();
                    Titel1.ParameterName = "@Titel";
                    Titel1.DbType = DbType.String;
                    command.Parameters.Add(Titel1);

                    DbParameter Nummer1 = sqlFactory.CreateParameter();
                    Nummer1.ParameterName = "@Nummer";
                    Nummer1.DbType = DbType.Int32;
                    command.Parameters.Add(Nummer1);

                    DbParameter Reeks_id1 = sqlFactory.CreateParameter();
                    Reeks_id1.ParameterName = "@Reeks_id";
                    Reeks_id1.DbType = DbType.Int32;
                    command.Parameters.Add(Reeks_id1);

                    DbParameter Uitgeverij_id1 = sqlFactory.CreateParameter();
                    Uitgeverij_id1.ParameterName = "@Uitgeverij_id";
                    Uitgeverij_id1.DbType = DbType.Int32;
                    command.Parameters.Add(Uitgeverij_id1);

                   // int teller = 1;
                    foreach (Strip s in strips)
                    {

                  //      command.Parameters["@id"].Value = teller;
                        command.Parameters["@Titel"].Value = s.StripTitel;
                        command.Parameters["@Nummer"].Value = s.StripNr;
                        command.Parameters["@Reeks_id"].Value = s.Reeks;
                        command.Parameters["@Uitgeverij_id"].Value = 
                        command.ExecuteNonQuery();
                     //   teller++;
                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    connection.Close();
                }

            }
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
