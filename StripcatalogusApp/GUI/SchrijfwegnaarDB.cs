using Businesslaag.Models;
using Businesslaag.Managers;
using Datalaag.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace JSON
{
    class SchrijfwegnaarDB
    {
        public void allesWegSchijvenNaarDataBank(List<Strip> strips)
        {
            GeneralManager generalManager = new GeneralManager();


            foreach (Strip str in strips)
            {
                foreach (Auteur aut in str.Auteurs)
                {
                    generalManager.AuteurRepository.addAuteur(aut);
                }
                generalManager.uitgeverijRepository.addUitgeverij(str.Uitgeverij);
                generalManager.ReeksRepository.addReeks(str.Reeks);
                generalManager.StripRepository.AddStrip(str); //checkt niet op dubbels
                generalManager.Addstrip(str); //checkt op dubbels
            }
        }


        /*  foreach (Strip str in strips)
          {
              stripmanager.AddStrip(str.StripTitel, str.Auteurs, str.Reeks, str.StripNr, str.Uitgeverij);
          }*/
    }
}
