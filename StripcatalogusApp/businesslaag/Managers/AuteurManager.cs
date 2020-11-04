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
  
    public class AuteurManager
    {
        private GeneralManager _gm;
        #region [Constructor]
        /// <summary>
        /// Default constructor
        /// </summary>
        public AuteurManager(GeneralManager generalManager)
        {
            _gm = generalManager;
        }
        #endregion

        public void Add(Auteur auteur)
        {
            if (DoubleAuteurNotFound(auteur)) 
            _gm._auteurRepository.Add(auteur);

        }


        private Boolean DoubleAuteurNotFound(Auteur auteur)
        {
            if (_gm._auteurRepository.GetAll().Any(i => i.ID == auteur.ID && i.Naam == auteur.Naam))
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