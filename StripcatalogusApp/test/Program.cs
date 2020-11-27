using Businesslaag.Models;
using Datalaag;
using Datalaag.Repositories;
using System;
using System.Collections.Generic;
using Businesslaag.Managers;
using JSON;
using WpfApp2;

namespace test
{
 public   class Program
    {
    

        public static void Main(string[] args)
        {
            // SchrijfwegnaarJSON f = new SchrijfwegnaarJSON();
            // f.allesWegSchrijvenNaarJSONFile(@"C:\Users\lieke\OneDrive\scool\projectwerk","SchrijfwegNaarJSONTest");
            JsonFileReader_ToObjects f = new JsonFileReader_ToObjects();
            f.leesFoutiveJson_GeefAlleStripsTerug(@"C:\Users\lieke\OneDrive\scool\projectwerk\dump.json-FoutieveJSON.json");
         /*    GeneralManager generalManager = new GeneralManager(new StripRepository(DbFunctions.GetprojectwerkconnectionString()), new AuteurRepository(DbFunctions.GetprojectwerkconnectionString()), new ReeksRepository(DbFunctions.GetprojectwerkconnectionString()), new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()));
            Auteur mytestauteur = new Auteur(999, "mytest");
            Reeks mytestreeks = new Reeks(999, "schaap");
            Uitgeverij myTestuitgeverij = new Uitgeverij(999, "myUitgeverij");
            List<Auteur> auteurs = new List<Auteur>();
            auteurs.Add(mytestauteur);
            Strip myTestStrip = new Strip(3687, "my test duh", 999, auteurs, mytestreeks, myTestuitgeverij);
            //  generalManager.StripManager.Add(myTestStrip);
          var gotten =  generalManager.AuteurManager.GetById(999);
            Console.WriteLine(gotten.ID.ToString() + gotten.Naam);*/
            
           /* JsonFileReader_ToObjects f = new JsonFileReader_ToObjects();
            List < Strip > str = new List<Strip>();
            str = f.leesJson_GeefAlleStripsTerug(@"C:\Users\lieke\OneDrive\scool\projectwerk\dump.json");
            SchrijfwegnaarJSON schrijfwegnaarJSON = new SchrijfwegnaarJSON();
            SchrijfwegnaarDB schrijfwegnaarDB = new SchrijfwegnaarDB();
            foreach(Strip s in str)
            {
                schrijfwegnaarDB.stripWegSchijvenNaarDataBank(s);
            }
           

            schrijfwegnaarJSON.allesWegSchrijvenNaarJSONFile(@"C:\Users\lieke\OneDrive\scool\projectwerk", "SchrijfwegNaarJSONTest2");*/

           /* Reeks test = new Reeks(666, "test");
      
            Auteur auteur = new Auteur(666, "test");
            List<Auteur> auteurs = new List<Auteur>();
            auteurs.Add(auteur);

            Uitgeverij testUitgeverij = new Uitgeverij(666, "test");
            Strip strip = new Strip(2278, "jeff fixed", 12345, auteurs, test, testUitgeverij);*/




            //   Reeks astrix = reeksRepository.GetById(1);
            //  reeksRepository.addReeks(test);

            //uitgeverijRepository.addUitgeverij(testUitgeverij);
            //  auteurRepository.addAuteur(auteur);

            //      generalManager.StripManager.Add(strip);
            // stripRepository.updateStrip(2669, strip);
            //  Console.WriteLine("strip updated");


            /*  stripRepository.DeleteStripById(2);
              foreach (var item in stripRepository.GetAll())
              {
                  foreach (var a in item.Auteurs)
                      Console.WriteLine(item.ID + " " + item.Reeks.Naam + " " + item.StripNr + " " + item.StripTitel + " " + a.Naam + " " + item.Uitgeverij.Naam);
              }*/
            // auteurRepository.deleteAuteurById(666);
            //  reeksRepository.DeleteReeksById(666);
            //uitgeverijRepository.DeleteUitgeverijById(666);
            //foreach (var a in uitgeverijRepository.GetAll())
            //{
            //    Console.WriteLine(a.ID + " " + a.Naam);
            //}

        }
    }
}
