using Businesslaag.Models;
using Datalaag;
using Datalaag.Repositories;
using System;
using System.Collections.Generic;
using Businesslaag.Managers;

namespace test
{
 public   class Program
    {
   public static void Main(string[] args)
        {

            GeneralManager generalManager = new GeneralManager(new StripRepository(DbFunctions.GetprojectwerkconnectionString()), new AuteurRepository(DbFunctions.GetprojectwerkconnectionString()), new ReeksRepository(DbFunctions.GetprojectwerkconnectionString()), new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()));
           
         
            Reeks test = new Reeks(666, "test");
      
            Auteur auteur = new Auteur(666, "test");
            List<Auteur> auteurs = new List<Auteur>();
            auteurs.Add(auteur);

            Uitgeverij testUitgeverij = new Uitgeverij(666, "test");
            Strip strip = new Strip(2278, "jeff fixed", 12345, auteurs, test, testUitgeverij);




            //   Reeks astrix = reeksRepository.GetById(1);
            //  reeksRepository.addReeks(test);
              
            //uitgeverijRepository.addUitgeverij(testUitgeverij);
            //  auteurRepository.addAuteur(auteur);

            generalManager.StripManager.Add(strip);
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
