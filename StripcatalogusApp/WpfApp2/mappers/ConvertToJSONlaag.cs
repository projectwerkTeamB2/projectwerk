using System;
using System.Collections.Generic;
using System.Text;
using Datalaag.Models;
using Businesslaag.Models;
using JSON.Models;

namespace JSON.Mappers
{
    /// <summary>
    ///
    /// </summary>
    public class ConvertToJSONlaag
    {

         public AuteurJS ConvertToAuteurJS(Auteur auteur) 
        {
            AuteurJS convertedAuteur = new AuteurJS(auteur.ID, auteur.Naam);
            return convertedAuteur;
        }

         public List<AuteurJS> ConvertToAuteursJS(List<Auteur> auteurs) 
        {
            List<AuteurJS> convertedauteurs = new List<AuteurJS>();
            foreach (var a in auteurs)
            {
                AuteurJS ca = new AuteurJS(a.ID, a.Naam);
                convertedauteurs.Add(ca);
            }
            return convertedauteurs;
        }

         public UitgeverijJS ConvertToUitgeverijJS(Uitgeverij uitgeverij)
        {
            UitgeverijJS convertedUitgeverij = new UitgeverijJS(uitgeverij.ID, uitgeverij.Naam);
                return convertedUitgeverij;
        }

         public ReeksJS ConvertToReeksJS(Reeks reeks)
        {
            ReeksJS convertedReeks = new ReeksJS(reeks.ID, reeks.Naam);
            return convertedReeks;
        }
          
         public StripJS convertToStripJS(Strip strip) 
        {
            List<AuteurJS> convertedAuteurs = new List<AuteurJS>();
          foreach (var a in strip.Auteurs)
            {
              var conv = ConvertToAuteurJS(a);
                convertedAuteurs.Add(conv);

            }

            StripJS convertedStrip = new StripJS(strip.ID, strip.StripTitel, strip.StripNr,convertedAuteurs, ConvertToReeksJS(strip.Reeks), ConvertToUitgeverijJS(strip.Uitgeverij), strip.IsEenLosseStrip);
            return convertedStrip;
        }

        public List<StripJS> convertToStripsJS(List<Strip> strips)
        {
            List<StripJS> stripsListJS = new List<StripJS>();
           foreach(Strip s in strips)
            {
                stripsListJS.Add(convertToStripJS(s));
            }

          
            return stripsListJS;
        }



        public StripCollectionJS ConvertToStripCollectionJS(StripCollection stripCollection) 
        {
            List<StripJS> convertedstrips = new List<StripJS>();
            foreach (var strip in stripCollection.Strips)
            {
                var conv = convertToStripJS(strip);
                convertedstrips.Add(conv);
            }
            StripCollectionJS convertedCollection = new StripCollectionJS(stripCollection.Id, stripCollection.Titel, stripCollection.Nummer, convertedstrips, ConvertToUitgeverijJS(stripCollection.Uitgeverij));
            return convertedCollection;
        }

        public List<StripCollectionJS> ConvertToStripCollectionJSList(List<StripCollection> stripCollection)
        {
            List<StripCollectionJS> convertedCollectionList = new List<StripCollectionJS>();
            foreach (StripCollection stpc in stripCollection)
            {
                List<StripJS> convertedstrips = new List<StripJS>();
                foreach (var strip in stpc.Strips)
                {
                    var conv = convertToStripJS(strip);
                    convertedstrips.Add(conv);
                }
                StripCollectionJS convertedCollection = new StripCollectionJS(stpc.Id, stpc.Titel, stpc.Nummer, convertedstrips, ConvertToUitgeverijJS(stpc.Uitgeverij));
                convertedCollectionList.Add( convertedCollection);
            }
            return convertedCollectionList;
        }


    }
}