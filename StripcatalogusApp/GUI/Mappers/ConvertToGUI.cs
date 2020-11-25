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

    }
}