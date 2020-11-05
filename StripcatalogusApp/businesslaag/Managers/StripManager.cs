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
    /// 
    
    public class StripManager
    {
        private GeneralManager _gm;
        #region [Constructor]
        /// <summary>
        /// Default constructor
        /// </summary>
        public StripManager(GeneralManager generalManager)
        {
            _gm = generalManager;

        }
        #endregion


        public void Add(Strip strip)
        {
            if (DoubleStripNotFound(strip))
              _gm._stripRepository.Add(strip);

        }
        public List<Strip> GetAll()
        {
            return (List<Strip>)_gm._stripRepository.GetAll();

        }

        private Boolean DoubleStripNotFound(Strip strip)
        {
            if (_gm._stripRepository.GetAll().Any(i=> i.StripNr == strip.StripNr && i.StripTitel == strip.StripTitel))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public Strip GetById(int id)
        {
            return _gm._stripRepository.GetById(id);

        }
    }
}