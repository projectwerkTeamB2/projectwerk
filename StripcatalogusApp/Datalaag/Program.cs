using businesslaag;
using Businesslaag;
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
            #region databank opvullen code

            //Leest de Json bestand in en maakt er objecten van
           JsonFileReader_ToObjects jfr = new JsonFileReader_ToObjects();
           List<Strip> stripsFromJson = jfr.leesJson_GeefAlleStripsTerug();
            
           //Maak connectie met databank
          DbProviderFactories.RegisterFactory("sqlserver", SqlClientFactory.Instance);
          // string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=StripCatDB;Integrated Security=True"; //verander StripCatDB naar jouw naam als je een connectie error krijgt
           DbProviderFactory sqlFactory = DbProviderFactories.GetFactory("sqlserver");

           


            StripRepository sp = new StripRepository(sqlFactory);
            // sp.FindAll_strip();
            int LastStipID = sp.latestStripId();
            Auteur fr = sp.GetAuteur_fromName("FRANK");
           // sp.allesWegSchijvenNaarDataBank(stripsFromJson); //om JSON strips naar databank te sturen
            #endregion
           

        }
    }
}

