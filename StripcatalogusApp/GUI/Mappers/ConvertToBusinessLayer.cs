using Businesslaag.Models;
using GUI.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GUI.Mappers
{
    /// <summary>
    ///
    /// </summary>
    public class ConvertToBusinessLayer
    {

        public static List<Auteur> ListAuteurs(List<AuteurGUI> auteurs)
        {
            List<Auteur> convertedAuteurs = new List<Auteur>();
            foreach (var a in auteurs)
            {
                convertedAuteurs.Add(ConvertToBusinessLayer.auteur(a));
            }
            return convertedAuteurs;
        }
        public static Auteur auteur(AuteurGUI auteur) 
        {
            Auteur ConvertedAuteur = new Auteur(auteur.ID, auteur.Naam);
            return ConvertedAuteur;
        }
        //
        public static List<Strip> ListStrips(List<StripGUI> strips)
        {
            List<Strip> convertedStrips = new List<Strip>();
            foreach (var a in strips)
            {
                convertedStrips.Add(ConvertToBusinessLayer.strip(a));
            }
            return convertedStrips;
        }
        public static Strip strip(StripGUI strip)
        {
            List<Auteur> convertedAuteurs = ListAuteurs(strip.Auteurs);
            Strip ConvertedStrip = new Strip(strip.ID, strip.StripTitel, strip.StripNr, convertedAuteurs, new Reeks(strip.Reeks.ID, strip.Reeks.Naam) ,new Uitgeverij(strip.Uitgeverij.ID, strip.Uitgeverij.Naam));
            return ConvertedStrip;
        }

    }
}