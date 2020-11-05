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


        public List<Reeks> GetAll()
        {
            return (List<Reeks>)_gm._reeksRepository.GetAll();

        }

        public Reeks GetById(int id)
        {
            return _gm._reeksRepository.GetById(id);

        }

        public void Update(Reeks reeks)
        {
            if (GetById(reeks.ID) != null)
            {
                _gm._reeksRepository.Update(reeks);
            }
            else
                
            throw new ArgumentException("trying to update a series that does not exist");

        }

        public void Delete(Reeks reeks)
        {
            if(GetById(reeks.ID) != null)
            {
                _gm._reeksRepository.DeleteById(reeks.ID);
            }
            else
            {
                throw new ArgumentException("trying to delete a series that does not exist");
            }
           
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