using System;
using System.Collections.Generic;
using System.Text;
using Datalaag.Models;
using Businesslaag.Models;

namespace Datalaag.Mappers
{
    /// <summary>
    ///
    /// </summary>
    public class ConvertToDatalayer
    {

        static public AuteurDB ConvertToAuteurDb(Auteur auteur) 
        {
            AuteurDB convertedAuteur = new AuteurDB(auteur.ID, auteur.Naam);
            return convertedAuteur;
        }

        static public List<AuteurDB> ConvertToAuteursDb(List<Auteur> auteurs) 
        {
            List<AuteurDB> convertedauteurs = new List<AuteurDB>();
            foreach (var a in auteurs)
            {
                AuteurDB ca = new AuteurDB(a.ID, a.Naam);
                convertedauteurs.Add(ca);
            }
            return convertedauteurs;
        }

         static public VerkoopDB ConvertToVerkoopDb(Verkoop verkoop) {
            VerkoopDB v = new VerkoopDB(verkoop.ID, verkoop.DatumBestelling, verkoop.Hoeveelheid);
            return v;
        }

        static public List<VerkoopDB> ConvertToAankoopListDb(List<Verkoop> verkooplist)
        {
            List<VerkoopDB> convertToVerkoop = new List<VerkoopDB>();
            foreach (var a in verkooplist)
            {
                VerkoopDB ca = new VerkoopDB(a.ID, a.DatumBestelling, a.Hoeveelheid);
                convertToVerkoop.Add(ca);
            }
            return convertToVerkoop;
        }

        static public AankoopDB ConvertToAankoopDb(Aankoop aankoop) {
            AankoopDB a = new AankoopDB(aankoop.ID, aankoop.DatumGeplaatst, aankoop.DatumOntvangen, aankoop.Hoeveelheid);
            return a;
        }

        static public List<AankoopDB> ConvertToVerkoopListDb(List<Aankoop> aankooplist)
        {
            List<AankoopDB> convertToAankoop = new List<AankoopDB>();
            foreach (var a in convertToAankoop)
            {
                AankoopDB ca = new AankoopDB(a.ID, a.DatumGeplaatst, a.DatumOntvangen, a.Hoeveelheid);
                convertToAankoop.Add(ca);
            }
            return convertToAankoop;
        }

        static public UitgeverijDB ConvertToUitgeverijDb(Uitgeverij uitgeverij)
        {
            UitgeverijDB convertedUitgeverij = new UitgeverijDB(uitgeverij.ID, uitgeverij.Naam);
                return convertedUitgeverij;
        }

        static public ReeksDB ConvertToReeksDb(Reeks reeks)
        {
            ReeksDB convertedReeks = new ReeksDB(reeks.ID, reeks.Naam);
            return convertedReeks;
        }
          
        static public StripDB convertToStripDb(Strip strip) 
        {
            List<AuteurDB> convertedAuteurs = new List<AuteurDB>();
          foreach (var a in strip.Auteurs)
            {
              var conv = ConvertToAuteurDb(a);
                convertedAuteurs.Add(conv);

            }

            StripDB convertedStrip = new StripDB(strip.ID, strip.StripTitel, strip.StripNr,convertedAuteurs, ConvertToReeksDb(strip.Reeks), ConvertToUitgeverijDb(strip.Uitgeverij), strip.IsEenLosseStrip);
            return convertedStrip;
        }

        static public List<StripDB> convertToStripsDb(List<Strip> strips) 
        {

            List<StripDB> convertedStrips = new List<StripDB>();
            foreach (var s in strips)
            {
                List<AuteurDB> convertedAuteurs = new List<AuteurDB>();
                foreach (var sa in s.Auteurs)
                {
                    var conv = ConvertToAuteurDb(sa);
                    convertedAuteurs.Add(conv);
                }

                var convertedStrip = new StripDB(s.ID, s.StripTitel, s.StripNr, convertedAuteurs, ConvertToReeksDb(s.Reeks), ConvertToUitgeverijDb(s.Uitgeverij), s.IsEenLosseStrip);
                convertedStrips.Add(convertedStrip);
            }
            return convertedStrips;
        }
    


        static public StripCollectionDB ConvertToStripCollectionDB(StripCollection stripCollection) 
        {
            List<StripDB> convertedstrips = new List<StripDB>();
            foreach (var strip in stripCollection.Strips)
            {
                var conv = convertToStripDb(strip);
                convertedstrips.Add(conv);
            }
            StripCollectionDB convertedCollection = new StripCollectionDB(stripCollection.Id, stripCollection.Titel, stripCollection.Nummer, convertedstrips, ConvertToUitgeverijDb(stripCollection.Uitgeverij));
            return convertedCollection;
        }


        //Converts voor inventory
        public static StockDB ConvertToStockDB(Stock stock) {
            StockDB convertedStock = new StockDB(stock.StripHoeveelHeden);
            return convertedStock;
        }

    }
}