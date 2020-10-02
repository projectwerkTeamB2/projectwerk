using businesslaag;
using Datalaag2.Providers;
using Datalaag2.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace Datalaag2
{
   public class Program
    {
        static void Main(string[] args)
        {

            JsonFileReader_ToObjects jfr = new JsonFileReader_ToObjects();
            List<Strip> stripsFromJson = jfr.leesJson_GeefAlleStripsTerug();
            //    StripRepository databeheer = new StripRepository(@"Data Source =.\SQLEXPRESS; Initial Catalog = Labo; Integrated Security = True");



            #region ljena's connectie code
            DbProviderFactories.RegisterFactory("sqlserver", SqlClientFactory.Instance);
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=StripCatDB;Integrated Security=True";
            DbProviderFactory sqlFactory = DbProviderFactories.GetFactory("sqlserver");




            StripRepository sp = new StripRepository(sqlFactory, connectionString);
            // sp.FindAll_strip();

         //   sp.allesWegSchijvenNaarDataBank(stripsFromJson);
            #endregion

        }
    }
}
