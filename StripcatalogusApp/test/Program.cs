﻿using Businesslaag.Models;
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
            Reeks astrix = reeksRepository.GetById(1);
            Reeks test = new Reeks(666, "test");
            reeksRepository.addReeks(test);
            UitgeverijRepository uitgeverijRepository = new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString());
        //    Uitgeverij testUitgeverij = new Uitgeverij(666, "test");
            //uitgeverijRepository.addUitgeverij(testUitgeverij);
            Uitgeverij uitgeverij1 = uitgeverijRepository.GetById(1);
            Auteur auteur = new Auteur(666, "test");
            List<Auteur> auteurs = new List<Auteur>();
            auteurs.Add(auteur);
           // AuteurRepository auteurRepository = new AuteurRepository(DbFunctions.GetprojectwerkconnectionString());
          //  auteurRepository.addAuteur(auteur);
            Strip strip = new Strip(666, "robin fixed smiddags de dingen", auteurs, astrix, 12345, uitgeverij1);
            StripRepository stripRepository = new StripRepository(DbFunctions.GetprojectwerkconnectionString());
            foreach (var item in stripRepository.GetAll())
            {
                foreach(var a in item.Auteurs)
                Console.WriteLine(item.ID + " " + item.Reeks.Naam + " " + item.StripNr + " " + item.StripTitel + " " + a.Naam + " " + item.Uitgeverij.Naam);
            }
            //stripRepository.AddStrip(strip);


        }
    }
}
