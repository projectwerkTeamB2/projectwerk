using Businesslaag.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businesslaag.Managers
{
    /// <summary>
    ///
    /// </summary>
    public class StripCollectionManager
    {

        private GeneralManager _gm;
        internal IStripCollectionRepository  _StripCollectionRepository;
        #region [Constructor]
        /// <summary>
        /// Default constructor
        /// </summary>
        public StripCollectionManager(GeneralManager generalManager, IStripCollectionRepository stripCollectionRepository )
        {
            this._gm = generalManager;
            this._StripCollectionRepository = stripCollectionRepository;

        }

        #endregion

    }
}