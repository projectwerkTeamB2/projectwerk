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

            StripDB convertedStrip = new StripDB(strip.ID, strip.StripTitel, strip.StripNr,convertedAuteurs, ConvertToReeksDb(strip.Reeks), ConvertToUitgeverijDb(strip.Uitgeverij));
            return convertedStrip;
        }

    }
}