﻿using System;
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
        static DbFunctions dbf = new DbFunctions();
        string connectString = dbf.conString;

        private string connectionString;

        #region
        private DbProviderFactory sqlFactory;

        public StripRepository(DbProviderFactory sqlFactory)
        {
            this.sqlFactory = sqlFactory;
            this.connectionString = connectString;
        }
        private DbConnection getConnection()
        {
            DbConnection connection = sqlFactory.CreateConnection();
            connection.ConnectionString = connectionString;
            return connection;
        }
        #endregion  connetion code

        public void allesWegSchijvenNaarDataBank(List<Strip> strips)
        {
            #region maak dictionary's
            Dictionary<int, Auteur> dictAuteurs = new Dictionary<int, Auteur>();
            Dictionary<int, Uitgeverij> dictUitgeverij = new Dictionary<int, Uitgeverij>();
            Dictionary<int, Reeks> dictReeks = new Dictionary<int, Reeks>();

            foreach (Strip s in strips)
            {
                foreach (Auteur a in s.Auteurs)
                {
                    if (!(dictAuteurs.ContainsKey(a.ID)))
                    {
                        dictAuteurs.Add(a.ID, a);
                    }
                }
                if (!(dictUitgeverij.ContainsKey(s.Uitgeverij.ID)))
                {
                    dictUitgeverij.Add(s.Uitgeverij.ID, s.Uitgeverij);
                }

                if (!(dictReeks.ContainsKey(s.Reeks.ID)))
                {
                    dictReeks.Add(s.Reeks.ID, s.Reeks);

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

                    foreach (Strip s in strips)
                    {
                        command.Parameters["@id"].Value = s.ID;
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


                    foreach (Strip s in strips)
                    {
                        foreach (Auteur a in s.Auteurs)
                        {
                            foreach (KeyValuePair<int, Auteur> dA in dictAuteurs)
                            {
                                if (a.ID == dA.Key)
                                {

                                    command.Parameters["@Strip_id"].Value = s.ID;
                                    command.Parameters["@Auteur_id"].Value = dA.Key;
                                    command.ExecuteNonQuery();
                                }
                            }
                        }
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
            DbConnection connection = getConnection();
            
     
            string query = "INSERT into Strip  values(@id,@title, @nummer, @reeks_id, @uitgeverij_id)";

            using (DbCommand command = connection.CreateCommand())
            {
                #region sqlparameters
                command.CommandText = query;
                SqlParameter prID = new SqlParameter();
                prID.ParameterName = "@id";
                prID.DbType = DbType.Int32;
                prID.Value = strip.ID;
                command.Parameters.Add(prID);

                SqlParameter prTitle = new SqlParameter();
                prTitle.ParameterName = "@title";
                prTitle.DbType = DbType.Int32;
                prTitle.Value = strip.StripTitel;
                command.Parameters.Add(prTitle);

                SqlParameter prNummer = new SqlParameter();
                prNummer.ParameterName = "@Nummer";
                prNummer.DbType = DbType.Int32;
                prNummer.Value = strip.StripTitel;
                command.Parameters.Add(prNummer);

                SqlParameter prReeks_Id = new SqlParameter();
                prReeks_Id.ParameterName = "@reeks_id";
                prReeks_Id.DbType = DbType.Int32;
                prReeks_Id.Value = strip.Reeks.ID;
                command.Parameters.Add(prReeks_Id);

                SqlParameter prUitgeverij_id = new SqlParameter();
                prUitgeverij_id.ParameterName = "@uitgeverij_id";
                prUitgeverij_id.DbType = DbType.Int32;
                prUitgeverij_id.Value = strip.Uitgeverij.ID;
                command.Parameters.Add(prReeks_Id);

                #endregion
                connection.Open();
                try
                {
                    command.ExecuteNonQuery();
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
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
            DbConnection connection = getConnection();
            IList<Strip> listStrip = new List<Strip>();
            string query = "select * from dbo.strip join dbo.strip_has_auteur on strip.id = strip_has_auteur.strip_id join dbo.reeks on reeks.id = strip.reeks_id join dbo.auteur on strip_has_auteur.auteur_id = auteur.id join dbo.uitgeverij on strip.uitgeverij_id = uitgeverij.id";
            using (DbCommand command = connection.CreateCommand()) {
                command.CommandText = query;
                connection.Open();
                try {
                    
                    IDataReader datareader = command.ExecuteReader();
                    Strip strip = new Strip();
                    while (datareader.Read()) {
                        List<Auteur> auteurList = new List<Auteur>();
                        Reeks reeksStrip = new Reeks((int)datareader["Reeks_Id"], (string)datareader[8]);
                        Uitgeverij uitgeverijStrip = new Uitgeverij((int)datareader["Strip_Id"], (string)datareader[12]);
                        
                        //Controle meerdere Auteurs
                        //Op ID controleren
                        string vorigeStripTitel = "";
                        if(vorigeStripTitel == (string)datareader["Titel"]) {
                            listStrip[listStrip.Count-1].Auteurs.Add(new Auteur((int)datareader["Auteur_Id"], (string)datareader[10]));
                        } else if(vorigeStripTitel != (string)datareader["Titel"]) {
                            auteurList.Add(new Auteur((int)datareader["Auteur_Id"], (string)datareader[10]));
                            strip = new Strip((int)datareader["id"], (string)datareader["Titel"], auteurList, reeksStrip, (int)datareader["nummer"], uitgeverijStrip);
                            vorigeStripTitel = strip.StripTitel;
                        }
                        listStrip.Add(strip);
                    }
                    datareader.Close();
                }
                catch (Exception ex) {
                    Console.WriteLine(ex);
                }
                finally {
                    connection.Close();
                }
            }
            return listStrip;
            throw new NotImplementedException();
        }

        public Strip FindStripById(int id)
        {
            //DbConnection conn = getConnection();
            //Strip strip;
            //string query = "SELECT * FROM dbo.Strip join dbo.Strip_has_Auteur on Strip.id = Strip_Has_Auteur.Strip_id join dbo.Reeks on Reeks.id = Strip.Reeks_id join dbo.Auteur on Strip_has_Auteur.Auteur_Id = Auteur.Id join dbo.Uitgeverij on Strip.Uitgeverij_id = Uitgeverij.id where Strip.id = @id";

            //using(DbCommand command = conn.CreateCommand()) {
            //    command.CommandText = query;
            //    SqlParameter prID = new SqlParameter();
            //    prID.ParameterName = "@id";
            //    prID.DbType = DbType.Int32;
            //    prID.Value = id;
            //    command.Parameters.Add(prID);
            //    conn.Open();
            //    try {
            //        IDataReader dataReader = command.ExecuteReader();
            //        dataReader.Read();
            //        //Enkel voor 1 auteur
            //        Auteur stripAuteur = new Auteur((string)dataReader[10]);
            //        Reeks reeksStrip = new Reeks((string)dataReader[8]);
            //        Uitgeverij uitgeverijStrip = new Uitgeverij((string)dataReader[12]);
            //       strip = new Strip((string)dataReader["Titel"], stripAuteur, reeksStrip, (int)dataReader["Nummer"], uit);
            //        dataReader.Close();
            //        return strip;
            //    } catch(Exception ex) {
            //        Console.WriteLine(ex);
            //        return null;
            //    }
            //    finally {
            //        conn.Close();
            //    }
            //}
            throw new NotImplementedException();
        }

        public void RemoveStripById(int id)
        {
            throw new NotImplementedException();
        }

        #region GUI
        public int latestStripId() {
            //werkt
            //telt op hoeveel strips er zijn
            //zo kan de nieuwe id gemaakt worden

            DbConnection connection = getConnection();
            
            string query = "SELECT COUNT(*) from dbo.Strip;";
            int x = 0;
            
                using (DbCommand command = connection.CreateCommand())
                            {
                command.CommandText = query;
                connection.Open();

                x = (int)command.ExecuteScalar();
                connection.Close();
            }
            
        
                return x;
        }
        public Auteur GetAuteur_fromName(string naam)
        {
            //nodig om te zien of die auteur al bestaat

            DbConnection connection = getConnection();
            string query = "SELECT * FROM AuteurWHERE Name='@naam'; ";
            

            using (DbCommand command = connection.CreateCommand())
            {
                command.CommandText = query;

                DbParameter paramId = sqlFactory.CreateParameter();
                paramId.ParameterName = "@naam";
                paramId.DbType = DbType.String;
                paramId.Value = naam;
                command.Parameters.Add(paramId);

                connection.Open();
                try
                {
                    //als auteur is gevonden
                    IDataReader datareader = command.ExecuteReader();
                    datareader.Read();
                    Auteur auteur = new Auteur((int)datareader["Id"], (string)datareader["Name"]);

                    datareader.Close();
                    return auteur;
                }
                catch (Exception ex)
                {
                    //als er geen is gevonden
                    return null;
                }
                finally
                {
                    connection.Close();
                }
            
        }


        }


        #endregion
    }
}
