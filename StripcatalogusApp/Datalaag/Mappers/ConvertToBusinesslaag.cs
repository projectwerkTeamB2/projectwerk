﻿using System;
using System.Collections.Generic;
using System.Text;
using Businesslaag.Models;
using Datalaag.Models;

namespace Datalaag.Mappers
{
    /// <summary>
    ///
    /// </summary>
    public class ConvertToBusinesslaag
    {
        static public Auteur ConvertToAuteur(AuteurDB auteur)
        {
            Auteur convertedAuteur = new Auteur(auteur.ID, auteur.Naam);
            return convertedAuteur;
        }

        static public List<Auteur> ConvertToAuteurs(List<AuteurDB> auteurs)
        {
            List<Auteur> convertedauteurs = new List<Auteur>();
            foreach (var a in auteurs)
            {
                Auteur Ca  = new Auteur(a.ID, a.Naam);
                convertedauteurs.Add(Ca);
            }
          
            return convertedauteurs;
        }

        static public Uitgeverij ConvertToUitgeverij(UitgeverijDB uitgeverij)
        {
            Uitgeverij convertedUitgeverij = new Uitgeverij(uitgeverij.ID, uitgeverij.Naam);
            return convertedUitgeverij;
        }


        static public List<Uitgeverij> ConvertToUitgevers(List<UitgeverijDB> uitgevers)
        {
            List<Uitgeverij> converteduitgevers = new List<Uitgeverij>();
            foreach (var a in uitgevers)
            {
                Uitgeverij Ca = new Uitgeverij(a.ID, a.Naam);
                converteduitgevers.Add(Ca);
            }

            return converteduitgevers;
        }



        static public Reeks ConvertToReeks(ReeksDB reeks)
        {
            Reeks convertedReeks = new Reeks(reeks.ID, reeks.Naam);
            return convertedReeks;
        }

        static public List<Reeks> ConvertToReeksen(List<ReeksDB> reeksen)
        {
            List<Reeks> converteduitgevers = new List<Reeks>();
            foreach (var a in reeksen)
            {
                Reeks Ca = new Reeks(a.ID, a.Naam);
                converteduitgevers.Add(Ca);
            }

            return converteduitgevers;
        }


        static public Strip convertToStrip(StripDB strip)
        {
            List<Auteur> convertedAuteurs = new List<Auteur>();
            foreach (var a in strip.Auteurs)
            {
                var conv = ConvertToAuteur(a);
                convertedAuteurs.Add(conv);

            }

            Strip convertedStrip = new Strip(strip.ID, strip.StripTitel, strip.StripNr, convertedAuteurs, ConvertToReeks(strip.Reeks), ConvertToUitgeverij(strip.Uitgeverij));
            return convertedStrip;
        }

        static public List<Strip> convertToStrips(List<StripDB> strips)
        {
            List<Strip> convertedstrips = new List<Strip>();
            foreach (var strip in strips)
            {
                List<Auteur> convertedAuteurs = new List<Auteur>();
                foreach (var a in strip.Auteurs)
                {
                    var conv = ConvertToAuteur(a);
                    convertedAuteurs.Add(conv);

                }

                Strip convertedStrip = new Strip(strip.ID, strip.StripTitel, strip.StripNr, convertedAuteurs, ConvertToReeks(strip.Reeks), ConvertToUitgeverij(strip.Uitgeverij));
                convertedstrips.Add(convertedStrip);
            }
                return convertedstrips;
       
            }

        static public StripCollection convertToStripCollection(StripCollectionDB StripCollection) 
        {
            List<Strip> convertedstrips = new List<Strip>();
            foreach (var strip in StripCollection.Strips)
            {
                var conv = convertToStrip(strip);
                convertedstrips.Add(conv);
            }
            StripCollection convertedStripCollection = new StripCollection(StripCollection.Id,StripCollection.Titel, StripCollection.Nummer, convertedstrips, ConvertToUitgeverij(StripCollection.Uitgeverij));
            return convertedStripCollection;
        }

        static public List<StripCollection> convertToCollections(List<StripCollectionDB> stripCollections)
        {
            List<StripCollection> convertedcollections = new List<StripCollection>();
            foreach (var collection in stripCollections)
            {
                List<Strip> convertedStrips = new List<Strip>();
                foreach (var s in collection.Strips)
                {
                    var conv = convertToStrip(s);
                    convertedStrips.Add(conv);

                }

                StripCollection csc = new StripCollection(collection.Id,collection.Titel, collection.Nummer, convertedStrips, ConvertToUitgeverij(collection.Uitgeverij));
                convertedcollections.Add(csc);
            }
            return convertedcollections;

        }

    }
}