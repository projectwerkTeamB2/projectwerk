using Businesslaag.Models;
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
            StripRepository stripRepo = new StripRepository(System.Configuration.ConfigurationManager.
    ConnectionStrings["projectwerkconnectionString"].ConnectionString);
            AuteurRepository auteurRepo = new AuteurRepository(System.Configuration.ConfigurationManager.
ConnectionStrings["projectwerkconnectionString"].ConnectionString);
            UitgeverijRepository uitgeverijRepo = new UitgeverijRepository(System.Configuration.ConfigurationManager.
ConnectionStrings["projectwerkconnectionString"].ConnectionString);
            ReeksRepository reeksRepo = new ReeksRepository(System.Configuration.ConfigurationManager.
ConnectionStrings["projectwerkconnectionString"].ConnectionString);

            foreach (Strip str in strips)
            {
                foreach(Auteur aut in str.Auteurs)
                {
                    auteurRepo.addAuteur(aut);
                }
                uitgeverijRepo.addUitgeverij(str.Uitgeverij);
                reeksRepo.addReeks(str.Reeks);
                stripRepo.AddStrip(str);
            }
        }
    }
}
