using Businesslaag.Models;
using Businesslaag.Managers;
using System.Collections.Generic;
using Datalaag;
using Datalaag.Repositories;
using System.Windows.Controls;
using Datalaag.Mappers;
using JSON.Mappers;
using JSON.Models;

namespace WpfApp2
{
 public class SchrijfwegnaarDB
    {
        public SchrijfwegnaarDB()
        {

        }

        ConvertToBusinesslaagJS converttobusinesslaagjs = new ConvertToBusinesslaagJS();
        public void stripWegSchijvenNaarDataBank(StripJS str)
        {
             Strip strip =  (converttobusinesslaagjs.convertToStrip(str));
            GeneralManager generalManager = new GeneralManager(new StripRepository(DbFunctions.GetprojectwerkconnectionString()), new AuteurRepository(DbFunctions.GetprojectwerkconnectionString()), new ReeksRepository(DbFunctions.GetprojectwerkconnectionString()), new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()), new StripCollectionRepository(DbFunctions.GetprojectwerkconnectionString()));


                foreach (Auteur aut in strip.Auteurs)
                {
                    generalManager.AuteurManager.Add(aut);
                }
                generalManager.UitgeverijManager.Add(strip.Uitgeverij);
                generalManager.ReeksManager.Add(strip.Reeks);
                generalManager.StripManager.Add(strip);
                
        }
    }
}
