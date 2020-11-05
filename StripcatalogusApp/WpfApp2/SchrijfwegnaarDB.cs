using Businesslaag.Models;
using Businesslaag.Managers;
using System.Collections.Generic;
using Datalaag;
using Datalaag.Repositories;

namespace WpfApp2
{
 public   class SchrijfwegnaarDB
    {
        public SchrijfwegnaarDB()
        {

        }

        //TODO FIX performance shit
        public void allesWegSchijvenNaarDataBank(List<Strip> strips)
        {
            GeneralManager generalManager = new GeneralManager(new StripRepository(DbFunctions.GetprojectwerkconnectionString()), new AuteurRepository(DbFunctions.GetprojectwerkconnectionString()), new ReeksRepository(DbFunctions.GetprojectwerkconnectionString()), new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()));

            foreach (Strip str in strips)
            {
                foreach (Auteur aut in str.Auteurs)
                {
                    generalManager.AuteurManager.Add(aut);
                }
                generalManager.UitgeverijManager.Add(str.Uitgeverij);
                generalManager.ReeksManager.Add(str.Reeks);
                generalManager.StripManager.Add(str); 
            }
        }
    }
}
