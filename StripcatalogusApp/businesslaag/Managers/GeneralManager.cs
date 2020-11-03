using System;
using System.Collections.Generic;
using System.Text;
using Datalaag.Models;
using Datalaag;
using Datalaag.Repositories;
using System.Linq;

namespace Businesslaag.Managers
{
    /// <summary>
    ///
    /// </summary>
    public class GeneralManager
    {
        #region Properties
        private ReeksRepository _reeksRepository = new ReeksRepository(DbFunctions.GetprojectwerkconnectionString());
        private AuteurRepository _auteurRepository =  new AuteurRepository(DbFunctions.GetprojectwerkconnectionString());
        private StripRepository _stripRepository = new StripRepository(DbFunctions.GetprojectwerkconnectionString());
        private UitgeverijRepository _uitgeverijRepository = new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString());

        public ReeksRepository ReeksRepository { get; }
        public AuteurRepository AuteurRepository { get; }
        public StripRepository StripRepository { get; }
        public UitgeverijRepository uitgeverijRepository { get; }

        #endregion
        public GeneralManager() 
        {
              ReeksRepository = _reeksRepository;
              AuteurRepository = _auteurRepository;
              StripRepository = _stripRepository;
              uitgeverijRepository = _uitgeverijRepository;
        }

        #region Add
        public void Addstrip(Strip strip) 
    {
            if (DoubleStripNotFound(strip))
                StripRepository.AddStrip(strip);
          
    }
        public void AddAuteur(Auteur auteur)
        {
            if (DoubleAuteurNotFound(auteur))
                AuteurRepository.addAuteur(auteur);

        }

        public void AddReeks(Reeks reeks) 
        {
            if (DoubleReeksNotFound(reeks))
                ReeksRepository.addReeks(reeks);
        }

        public void AddUitgeverij(Uitgeverij uitgeverij)
        {
            if (DoubleUitgeverijNotFound(uitgeverij))
                uitgeverijRepository.addUitgeverij(uitgeverij);
        }

        #endregion

        #region helpers

        private Boolean DoubleStripNotFound(Strip strip) 
        {
            if(StripRepository.GetAll().Any(i => i.ID == strip.ID && i.StripNr == strip.StripNr && i.StripTitel == strip.StripTitel))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private Boolean DoubleAuteurNotFound(Auteur auteur)
        {
            if (AuteurRepository.GetAll().Any(i => i.ID == auteur.ID && i.Naam == auteur.Naam))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        private Boolean DoubleReeksNotFound(Reeks reeks)
        {
            if (ReeksRepository.GetAll().Any(i => i.ID == reeks.ID && i.Naam == reeks.Naam))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private Boolean DoubleUitgeverijNotFound(Uitgeverij uitgeverij)
        {
            if (uitgeverijRepository.GetAll().Any(i => i.ID == uitgeverij.ID && i.Naam == uitgeverij.Naam))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        #endregion

    }
}