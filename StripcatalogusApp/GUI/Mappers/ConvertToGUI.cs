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
    public class ConvertToGUI
    {

        public static List<AuteurGUI> ListAuteurs(List<Auteur> auteurs)
        {
            List<AuteurGUI> convertedAuteurs = new List<AuteurGUI>();
            foreach (var a in auteurs)
            {
                convertedAuteurs.Add(ConvertToGUI.auteur(a));
            }
            return convertedAuteurs;
        }

        public static AuteurGUI auteur (Auteur auteur)
        {
            AuteurGUI ConvertedAuteur = new AuteurGUI(auteur.ID, auteur.Naam);
            return ConvertedAuteur;
        }

        public static ReeksGUI reeks (Reeks reeks) 
        {
            ReeksGUI ConvertedReeks = new ReeksGUI(reeks.ID, reeks.Naam);
            return ConvertedReeks;
        }

        public static UitgeverijGUI uitgeverij(Uitgeverij uitgeverij) 
        {
            UitgeverijGUI ConvertedUitgeverij = new UitgeverijGUI(uitgeverij.ID, uitgeverij.Naam);
            return ConvertedUitgeverij;
        }

        public static StripGUI Strip (Strip strip) 
        {
            List<AuteurGUI> convertedAuteurs = new List<AuteurGUI>();
            foreach (var a in strip.Auteurs)
            {
                var conv = ConvertToGUI.auteur(a);
                convertedAuteurs.Add(conv);

            }

            StripGUI ConvertedStrip = new StripGUI(strip.ID, strip.StripTitel, strip.StripNr, convertedAuteurs, ConvertToGUI.reeks(strip.Reeks), ConvertToGUI.uitgeverij(strip.Uitgeverij));
            return ConvertedStrip;
        }

        static public List<StripGUI> convertToStrips(List<Strip> strips)
        {
            List<StripGUI> convertedstrips = new List<StripGUI>();
            foreach (var strip in strips)
            {
                List<AuteurGUI> convertedAuteurs = new List<AuteurGUI>();
                foreach (var a in strip.Auteurs)
                {
                    var conv = ConvertToGUI.auteur(a);
                    convertedAuteurs.Add(conv);
                }

                StripGUI convertedStrip = new StripGUI(strip.ID, strip.StripTitel, strip.StripNr, convertedAuteurs, ConvertToGUI.reeks(strip.Reeks), ConvertToGUI.uitgeverij(strip.Uitgeverij));
                convertedstrips.Add(convertedStrip);
            }
            return convertedstrips;
        }
    }
}