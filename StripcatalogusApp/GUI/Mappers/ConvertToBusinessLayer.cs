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
        

    }
}