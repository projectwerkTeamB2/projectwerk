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
        private ReeksRepository _reeksRepository = new ReeksRepository(DbFunctions.GetprojectwerkconnectionString());
        private AuteurRepository _auteurRepository =  new AuteurRepository(DbFunctions.GetprojectwerkconnectionString());
        private StripRepository _stripRepository = new StripRepository(DbFunctions.GetprojectwerkconnectionString());
        private UitgeverijRepository _uitgeverijRepository = new UitgeverijRepository(DbFunctions.GetprojectwerkconnectionString());

        public ReeksRepository ReeksRepository { get; }
        public AuteurRepository AuteurRepository { get; }
        public StripRepository StripRepository { get; }
        public UitgeverijRepository uitgeverijRepository { get; }

        public GeneralManager() 
        {
              ReeksRepository = _reeksRepository;
              AuteurRepository = _auteurRepository;
              StripRepository = _stripRepository;
              uitgeverijRepository = _uitgeverijRepository;
        }

    public void Addstrip(Strip strip) 
    {
            if (DoubleStripNotFound(strip))
                StripRepository.AddStrip(strip);
          
    }

    private Boolean DoubleStripNotFound(Strip strip) 
        {
            if(StripRepository.GetAll().Any(i => i.ID == strip.ID && i.StripNr == strip.StripNr && i.StripTitel == strip.StripTitel))
            {
                throw new ArgumentException("Strip bestaat al in de database");
            }
            else
            {
                return true;
            }
        }



    }
}