using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Businesslaag.Models;

namespace Businesslaag.Managers
{
    /// <summary>
    ///
    /// </summary>
    ///
    public class ReeksManager
    {
        private GeneralManager _gm;
        #region [Constructor]
        /// <summary>
        /// Default constructor
        /// </summary>
       

        public ReeksManager(GeneralManager generalManager)
        {
            _gm = generalManager;
        }


        public void Add(Reeks reeks)
        {
            if (DoubleReeksNotFound(reeks))
               _gm._reeksRepository.Add(reeks);
        }

        private Boolean DoubleReeksNotFound(Reeks reeks)
        {
            if (_gm._reeksRepository.GetAll().Any(i => i.ID == reeks.ID && i.Naam == reeks.Naam))
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