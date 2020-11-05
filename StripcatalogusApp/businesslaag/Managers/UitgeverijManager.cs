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

        public List<Reeks> GetAll()
        {
            return (List<Reeks>)_gm._reeksRepository.GetAll();

        }

        public Uitgeverij GetById(int id)
        {
            return _gm._uitgeverijRepository.GetById(id);

        }

        public void Update(Uitgeverij uitgeverij)
        {
            if (GetById(uitgeverij.ID) != null)
            {
                _gm._uitgeverijRepository.Update(uitgeverij);
            }
            else

                throw new ArgumentException("trying to update a publisher that does not exist");

        }

        public void Delete(Uitgeverij uitgeverij)
        {
            if (GetById(uitgeverij.ID) != null)
            {
                _gm._reeksRepository.DeleteById(uitgeverij.ID);
            }
            else
            {
                throw new ArgumentException("trying to delete a publisher that does not exist");
            }

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