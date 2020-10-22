using Businesslaag;
using Businesslaag;
using Businesslaag.Models;
using Datalaag;
using Datalaag.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ForTesting
{
    public class Program
    {
        [STAThread]
        public static void Main()
        {
           #region databank opvullen code

            //Leest de Json bestand in en maakt er objecten van
       /*    JsonFileReader_ToObjects jfr = new JsonFileReader_ToObjects();
           List<Strip> stripsFromJson = jfr.leesJson_GeefAlleStripsTerug();
            
           //Maak connectie met databank
          DbProviderFactories.RegisterFactory("sqlserver", SqlClientFactory.Instance);
          // string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=StripCatDB;Integrated Security=True"; //verander StripCatDB naar jouw naam als je een connectie error krijgt
           DbProviderFactory sqlFactory = DbProviderFactories.GetFactory("sqlserver");

           


            StripRepository_OG sp = new StripRepository_OG(sqlFactory);*/
            //    List<Strip> test = sp.FindAll_ByReeks(new Reeks(7, "maakt niet uit")).ToList();
            //  Console.WriteLine(test[2].ID);
            //    sp.FindAll_strip();
            //    int LastStipID = sp.latestStripId();
            //   Auteur fr = sp.GetAuteur_fromName("Hermann");
            //   Reeks r = sp.GetReeks_fromName("Aldebaran");*/
            // sp.allesWegSchijvenNaarDataBank(stripsFromJson); //om JSON strips naar databank te sturen
            #endregion
            // sp.AddStrip()
            Uitgeverij uitgeverij = new Uitgeverij(666, "test");
            Reeks reeks = new Reeks(666, "robin fixes");
            Auteur auteur = new Auteur(666, "test");
            List<Auteur> auteurs = new List<Auteur>();
            auteurs.Add(auteur);
            Strip strip = new Strip(666, "robin fixed smiddags de dingen", auteurs, reeks, 12345, uitgeverij);
            Console.WriteLine("Apple");
            StripRepository stripRepository = new StripRepository(DbFunctions.GetprojectwerkconnectionString());
            Console.WriteLine("kiwi");
            stripRepository.AddStrip(strip);
            Console.WriteLine("blueberry");
        }
    }
}

