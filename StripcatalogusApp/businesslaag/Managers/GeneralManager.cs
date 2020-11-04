using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Businesslaag.Models;
using Businesslaag.Repositories;

namespace Businesslaag.Managers
{
    /// <summary>
    ///
    /// </summary>
    public class GeneralManager
    {
        #region Properties
        internal IReeksRepository _reeksRepository;
        internal IAuteurRepository _auteurRepository;
        internal IStripRepository _stripRepository;
        internal IUitgeverijRepository _uitgeverijRepository;

       

        public ReeksManager ReeksManager { get; }
       public AuteurManager AuteurManager { get; }
       public UitgeverijManager UitgeverijManager { get; }
       public StripManager StripManager { get; }
          

        #endregion
        public GeneralManager(IStripRepository stripRepository, IAuteurRepository auteurRepository, IReeksRepository reeksRepository , IUitgeverijRepository uitgeverijRepository ) 
        {


            _reeksRepository = reeksRepository;
            _auteurRepository = auteurRepository;
            _stripRepository = stripRepository;
            _uitgeverijRepository = uitgeverijRepository;

            ReeksManager = new ReeksManager(this);
            AuteurManager = new AuteurManager(this);
            UitgeverijManager = new UitgeverijManager(this);
            StripManager = new StripManager(this);
            

        }


    }
}