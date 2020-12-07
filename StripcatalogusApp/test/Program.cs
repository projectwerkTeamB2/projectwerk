using Businesslaag.Models;
using Datalaag;
using Datalaag.Repositories;
using System;
using System.Collections.Generic;
using Businesslaag.Managers;
using JSON;
using WpfApp2;
using JSON.Models;

namespace test
{
 public   class Program
    {
    

        public static void Main(string[] args)
        {
       
            GeneralManager generalManager = new GeneralManager(new StripRepository(DbFunctions.GetprojectwerkconnectionString()), new AuteurRepository(DbFunctions.GetprojectwerkconnectionString()), new ReeksRepository(DbFunctions.GetprojectwerkconnectionString()), new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()), new StripCollectionRepository(DbFunctions.GetprojectwerkconnectionString()));
            // snel wegschrijven van strips zonder gui
            //JsonFileReader_ToObjects jfr = new JsonFileReader_ToObjects();
            //List<StripJS> stripsFromJsonToDB = jfr.leesJson_GeefAlleStripsJSTerug("../dump.json");
            //SchrijfwegnaarDB schrijfwegnaarDB = new SchrijfwegnaarDB();
            //schrijfwegnaarDB.stripWegSchijvenNaarDataBank(stripsFromJsonToDB);
            //    Console.WriteLine("Het is gelukt!");

            Auteur mytestauteur = new Auteur(999, "mytest");
            Reeks mytestreeks = new Reeks(999, "schaap");
            Uitgeverij myTestuitgeverij = new Uitgeverij(999, "myUitgeverij");
            List<Auteur> auteurs = new List<Auteur>();
            auteurs.Add(mytestauteur);

            // generalManager.AuteurManager.Add(mytestauteur);
            //  generalManager.ReeksManager.Add(mytestreeks);
            //generalManager.UitgeverijManager.Add(myTestuitgeverij);

            Strip myTestStrip = new Strip(3687, "fruitcake", 999, auteurs, mytestreeks, myTestuitgeverij);
            Strip myTestStrip2 = new Strip(3686, "my test duh", 888, auteurs, mytestreeks, myTestuitgeverij);
     /*       generalManager.StripManager.Add(myTestStrip2);
             generalManager.StripManager.Add(myTestStrip);*/
            List<Strip> strips = new List<Strip>();
            strips.Add(generalManager.StripManager.GetById(148));
            strips.Add(generalManager.StripManager.GetById(149));
          //   StripCollection collection = new StripCollection(12, "passievrucht", 666, strips, myTestuitgeverij);
            var collection = generalManager.stripCollectionManager.GetAll();

             //    generalManager.stripCollectionManager.Add(collection);
           foreach (var c in collection)
            {
                Console.WriteLine(c.Titel + " "  + c.Strips.Count);
            }

        }
    }
}
