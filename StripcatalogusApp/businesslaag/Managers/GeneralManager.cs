using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Businesslaag.Models;
using Businesslaag.Repositories;

namespace Businesslaag.Managers
{
   /// <summary>
   /// Algemene classe met referentie naar eigen managers  iedere manager is verantwoordelijk voor zijn eigen repository
   /// </summary>
    public class GeneralManager
    {
        #region Properties
       
        public ReeksManager ReeksManager { get; }
       public AuteurManager AuteurManager { get; }
       public UitgeverijManager UitgeverijManager { get; }
       public StripManager StripManager { get; }

        public StripCollectionManager stripCollectionManager { get; }
          
        //Inventory
        public StockManager stockManager { get; }
        public AankoopManager aankoopManager { get; }
        public VerkoopManager verkoopManager { get; }
        

        #endregion
        public GeneralManager(IStripRepository stripRepository, IAuteurRepository auteurRepository, IReeksRepository reeksRepository , IUitgeverijRepository uitgeverijRepository , IStripCollectionRepository stripCollectionRepository) 
        {


            ReeksManager = new ReeksManager(this, reeksRepository);
            AuteurManager = new AuteurManager(this, auteurRepository);
            UitgeverijManager = new UitgeverijManager(this, uitgeverijRepository);
            StripManager = new StripManager(this, stripRepository);
            stripCollectionManager = new StripCollectionManager(this, stripCollectionRepository);

        }


    }
}