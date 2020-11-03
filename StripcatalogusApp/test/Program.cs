using Datalaag.Models;
using Datalaag;
using Datalaag.Repositories;
using System;
using System.Collections.Generic;

namespace test
{
 public   class Program
    {
   public static void Main(string[] args)
        {

           
            ReeksRepository reeksRepository = new ReeksRepository(DbFunctions.GetprojectwerkconnectionString());
         
            Reeks test = new Reeks(666, "test");
      
            UitgeverijRepository uitgeverijRepository = new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString());

            Uitgeverij uitgeverij1 = uitgeverijRepository.GetById(1);
            Auteur auteur = new Auteur(666, "test");
            List<Auteur> auteurs = new List<Auteur>();
            auteurs.Add(auteur);
            AuteurRepository auteurRepository = new AuteurRepository(DbFunctions.GetprojectwerkconnectionString());
        
            Strip strip = new Strip(2669, "jeff fixed", 12345, auteurs, test, uitgeverij1);

           
            StripRepository stripRepository = new StripRepository(DbFunctions.GetprojectwerkconnectionString());



            //   Reeks astrix = reeksRepository.GetById(1);
            //  reeksRepository.addReeks(test);
            //    Uitgeverij testUitgeverij = new Uitgeverij(666, "test");
            //uitgeverijRepository.addUitgeverij(testUitgeverij);
            //  auteurRepository.addAuteur(auteur);

             stripRepository.AddStrip(strip);
            stripRepository.updateStrip(2669, strip);
            Console.WriteLine("strip updated");


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
