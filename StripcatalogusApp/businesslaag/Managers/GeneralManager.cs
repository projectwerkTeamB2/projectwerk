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
       
        public ReeksManager ReeksManager { get; }
       public AuteurManager AuteurManager { get; }
       public UitgeverijManager UitgeverijManager { get; }
       public StripManager StripManager { get; }
          

        #endregion
        public GeneralManager(IStripRepository stripRepository, IAuteurRepository auteurRepository, IReeksRepository reeksRepository , IUitgeverijRepository uitgeverijRepository ) 
        {


            ReeksManager = new ReeksManager(this, reeksRepository);
            AuteurManager = new AuteurManager(this, auteurRepository);
            UitgeverijManager = new UitgeverijManager(this, uitgeverijRepository);
            StripManager = new StripManager(this, stripRepository);
            

        }


    }
}