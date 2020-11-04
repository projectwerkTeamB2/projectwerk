using Businesslaag.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Businesslaag.Managers
{
    /// <summary>
    ///
    /// </summary>
    public class UitgeverijManager
    {
        #region [Constructor]
        /// <summary>
        /// Default constructor
        /// </summary>

        private GeneralManager _gm;
        public UitgeverijManager(GeneralManager generalManager)
        {
            _gm = generalManager;
        }
        #endregion


        public void Add(Uitgeverij uitgeverij)
        {
            if (DoubleUitgeverijNotFound(uitgeverij))
                _gm._uitgeverijRepository.Add(uitgeverij);
        }

        private Boolean DoubleUitgeverijNotFound(Uitgeverij uitgeverij)
        {
            if (_gm._uitgeverijRepository.GetAll().Any(i => i.ID == uitgeverij.ID && i.Naam == uitgeverij.Naam))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}