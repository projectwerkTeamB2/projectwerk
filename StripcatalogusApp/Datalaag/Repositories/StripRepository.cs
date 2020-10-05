using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using businesslaag;
using Businesslaag;
using Businesslaag.Repositories;

namespace Datalaag.Repositories
{
    public class StripRepository : IStripRepository
    {

        //TODO CHECK THIS

        SqlConnection connection = DbFunctions.MyConnection(); // gets connection from app config name should be projectwerkconnection
    
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
            #region maak dictionary's
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
                    if (!(dictAuteurs.Any(dA => dA.Value.Naam.Equals(a.Naam))))
                    {
                        dictAuteurs.Add(tellerAut, a);
                        tellerAut++;
                    }
                }
                if (!(dictUitgeverij.Any(dU => dU.Value.Naam.Equals(s.Uitgeverij.Naam))))
                {
                    dictUitgeverij.Add(tellerUit, s.Uitgeverij);
                    tellerUit++;
                }
                if (!(dictReeks.Any(dR => dR.Value.Naam.Equals(s.Reeks.Naam))))
                {
                    dictReeks.Add(tellerRks, s.Reeks);
                    tellerRks++;
                }
                
            }
            #endregion
            DbConnection connection = getConnection();
            #region vul reeks op
            string query0 = "INSERT INTO dbo.Reeks (id,Name)"
                 + "VALUES(@id,@Name)";
            using (DbCommand command = connection.CreateCommand())
            {
                connection.Open();
                try
                {
                    command.CommandText = query0;

                    DbParameter id = sqlFactory.CreateParameter();
                    id.ParameterName = "@id";
                    id.DbType = DbType.Int32;
                    command.Parameters.Add(id);

                    DbParameter Name = sqlFactory.CreateParameter();
                    Name.ParameterName = "@Name";
                    Name.DbType = DbType.String;
                    command.Parameters.Add(Name);


                    foreach (KeyValuePair<int, Reeks> dR in dictReeks)
                    {
                        command.Parameters["@id"].Value = dR.Key;
                        command.Parameters["@Name"].Value = dR.Value.Naam;
                        command.ExecuteNonQuery();
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
            #endregion
            #region vul Uitgeverij op
            string query1 = "INSERT INTO dbo.Uitgeverij (id,Name)"
                + "VALUES(@id,@Name)";
            using (DbCommand command = connection.CreateCommand())
            {
                connection.Open();
                try
                {
                    command.CommandText = query1;

                    DbParameter Name = sqlFactory.CreateParameter();
                    Name.ParameterName = "@Name";
                    Name.DbType = DbType.String;
                    command.Parameters.Add(Name);

                    DbParameter id = sqlFactory.CreateParameter();
                    id.ParameterName = "@id";
                    id.DbType = DbType.Int32;
                    command.Parameters.Add(id);


                    foreach (KeyValuePair<int, Uitgeverij> dU in dictUitgeverij)
                    {
                        command.Parameters["@id"].Value = dU.Key;
                        command.Parameters["@Name"].Value = dU.Value.Naam;
                        command.ExecuteNonQuery();
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
            #endregion
            #region vul Auteur op
            string query3 = "INSERT INTO dbo.Auteur (id,Name)"
                + "VALUES(@id,@Name)";
            using (DbCommand command = connection.CreateCommand())
            {
                connection.Open();
                try
                {
                    command.CommandText = query3;

                    DbParameter Name = sqlFactory.CreateParameter();
                    Name.ParameterName = "@Name";
                    Name.DbType = DbType.String;
                    command.Parameters.Add(Name);
                    DbParameter id = sqlFactory.CreateParameter();
                    id.ParameterName = "@id";
                    id.DbType = DbType.Int32;
                    command.Parameters.Add(id);


                    foreach (KeyValuePair<int, Auteur> dA in dictAuteurs)
                    {
                        command.Parameters["@id"].Value = dA.Key;
                        command.Parameters["@Name"].Value = dA.Value.Naam;
                        command.ExecuteNonQuery();
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
            #endregion
            #region vul Strip op
            string query2 = "INSERT INTO dbo.Strip (id,Titel,Nummer,Reeks_id,Uitgeverij_id)"
                 + "VALUES(@id,@Titel,@Nummer,@Reeks_id,@Uitgeverij_id)";
            using (DbCommand command = connection.CreateCommand())
            {
                connection.Open();
                try
                {
                    command.CommandText = query2;



                    DbParameter id = sqlFactory.CreateParameter();
                    id.ParameterName = "@id";
                    id.DbType = DbType.Int32;
                    command.Parameters.Add(id);

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

                    int teller = 1;
                    foreach (Strip s in strips)
                    {
                        command.Parameters["@id"].Value = teller;
                        command.Parameters["@Titel"].Value = s.StripTitel;
                        command.Parameters["@Nummer"].Value = s.StripNr;

                        foreach (KeyValuePair<int, Uitgeverij> dU in dictUitgeverij)
                        {
                            if (dU.Value.Naam == s.Uitgeverij.Naam)
                            {
                                command.Parameters["@Uitgeverij_id"].Value = dU.Key;
                            }

                        }
                        foreach (KeyValuePair<int, Reeks> dR in dictReeks)
                        {
                            if (dR.Value.Naam == s.Reeks.Naam)
                            {
                                command.Parameters["@Reeks_id"].Value = dR.Key;
                            }
                        }
                        command.ExecuteNonQuery();
                        teller++;

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
            #endregion
            #region vul Strip_has_Auteur
            string query4 = "INSERT INTO dbo.Strip_has_Auteur (Strip_id,Auteur_id)"
                + "VALUES(@Strip_id,@Auteur_id)";
            using (DbCommand command = connection.CreateCommand())
            {
                connection.Open();
                try
                {
                    command.CommandText = query4;

                    DbParameter strip_id = sqlFactory.CreateParameter();
                    strip_id.ParameterName = "@Strip_id";
                    strip_id.DbType = DbType.Int32;
                    command.Parameters.Add(strip_id);

                    DbParameter Auteur_id = sqlFactory.CreateParameter();
                    Auteur_id.ParameterName = "@Auteur_id";
                    Auteur_id.DbType = DbType.Int32;
                    command.Parameters.Add(Auteur_id);

                    int teller = 1;
                    foreach (Strip s in strips)
                    {
                        foreach (Auteur a in s.Auteurs)
                        {
                            foreach (KeyValuePair<int, Auteur> dA in dictAuteurs)
                            {
                                if (dA.Value.Naam.Contains(a.Naam))
                                {

                                    command.Parameters["@Strip_id"].Value = teller;
                                    command.Parameters["@Auteur_id"].Value = dA.Key;
                                    command.ExecuteNonQuery();
                                }
                            }
                        }
                        teller++;
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
            #endregion
           
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
            /*SqlConnection conn = getConnection();
            Strip strip;
            string query = "SELECT * FROM dbo.strip WHERE id = @id";
            using(SqlCommand command = conn.CreateCommand()) {
                command.CommandText = query;
                SqlParameter prID = new SqlParameter();
                prID.ParameterName = "@id";
                prID.DbType = DbType.Int32;
                prID.Value = id;
                command.Parameters.Add(prID);
                conn.Open();
                try {
                    SqlDataReader dataReader = command.ExecuteReader();
                    dataReader.Read();
                    //!!!!!!!!Strip opvragen
                    strip = new Strip((string)dataReader["Titel"], ???);
                    dataReader.Close();
                    return strip;
                } catch(Exception ex) {
                    Console.WriteLine(ex);
                    return null;
                }
                finally {
                    conn.Close();
                }
            }*/
            throw new NotImplementedException();
        }

        public void RemoveStripById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
