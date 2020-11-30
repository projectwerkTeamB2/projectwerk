using Businesslaag.Models;
using Businesslaag.Managers;
using System.Collections.Generic;
using Datalaag;
using Datalaag.Repositories;
using System.Windows.Controls;

namespace WpfApp2
{
 public   class SchrijfwegnaarDB
    {
        public SchrijfwegnaarDB()
        {

        }

       
        public void stripWegSchijvenNaarDataBank(Strip str)
        {
            GeneralManager generalManager = new GeneralManager(new StripRepository(DbFunctions.GetprojectwerkconnectionString()), new AuteurRepository(DbFunctions.GetprojectwerkconnectionString()), new ReeksRepository(DbFunctions.GetprojectwerkconnectionString()), new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString()), new StripCollectionRepository(DbFunctions.GetprojectwerkconnectionString()));

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
