using businesslaag;
using Datalaag.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace Datalaag
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {


            JsonFileReader_ToObjects jfr = new JsonFileReader_ToObjects();
            List<Strip> stripsFromJson = jfr.leesJson_GeefAlleStripsTerug();

            #region om te testen
            DbProviderFactories.RegisterFactory("sqlserver", SqlClientFactory.Instance);
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=StripCatDB;Integrated Security=True";
            DbProviderFactory sqlFactory = DbProviderFactories.GetFactory("sqlserver");

            StripRepository sp = new StripRepository(sqlFactory, connectionString);
            sp.FindAll_strip();
            #endregion

        }
    }
}

