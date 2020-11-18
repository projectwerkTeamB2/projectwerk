using System;
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

        static public Uitgeverij ConvertToUitgeverij(UitgeverijDB uitgeverij)
        {
            Uitgeverij convertedUitgeverij = new Uitgeverij(uitgeverij.ID, uitgeverij.Naam);
            return convertedUitgeverij;
        }

        static public Reeks ConvertToReeks(ReeksDB reeks)
        {
            Reeks convertedReeks = new Reeks(reeks.ID, reeks.Naam);
            return convertedReeks;
        }
        static Strip convertToStrip(StripDB strip)
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

    }
}