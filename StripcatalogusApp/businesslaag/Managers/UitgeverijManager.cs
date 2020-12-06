using Businesslaag.Models;
using Businesslaag.Repositories;
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

        internal IUitgeverijRepository _uitgeverijRepository;
        public UitgeverijManager(GeneralManager generalManager, IUitgeverijRepository uitgeverijRepository)
        {
            _gm = generalManager;
            _uitgeverijRepository = uitgeverijRepository;
        }
        #endregion


        public void Add(Uitgeverij uitgeverij)
        {
            if (DoubleUitgeverijNotFound(uitgeverij)) { 
                this._uitgeverijRepository.Add(uitgeverij);

        }//else throw new ArgumentException("Uitgeverij bestaat al");
    }

        public List<Uitgeverij> GetAll()
        {
            return (List<Uitgeverij>)this._uitgeverijRepository.GetAll();

        }

        public Uitgeverij GetById(int id)
        {
            return this._uitgeverijRepository.GetById(id);

        }

        public void Update(Uitgeverij uitgeverij)
        {
            if (GetById(uitgeverij.ID) != null)
            {
                this._uitgeverijRepository.Update(uitgeverij);
            }
            else

                throw new ArgumentException("trying to update a publisher that does not exist");

        }

        public void Delete(Uitgeverij uitgeverij)
        {
            if (GetById(uitgeverij.ID) != null)
            {
                this._uitgeverijRepository.DeleteById(uitgeverij.ID);
            }
            else
            {
                throw new ArgumentException("trying to delete a publisher that does not exist");
            }

        }


        private Boolean DoubleUitgeverijNotFound(Uitgeverij uitgeverij)
        {
            //if (this._uitgeverijRepository.GetAll().Any(i => i.ID == uitgeverij.ID && i.Naam == uitgeverij.Naam))
                if (this._uitgeverijRepository.GetAll().Any(i => i.Naam == uitgeverij.Naam))
                {
                return false;
            }
            else
            {
                return true;
            }
        }

        public Uitgeverij GetByName(string uitgeverijnaam)
        {
            return this._uitgeverijRepository.GetAll().Where(n => n.Naam.Equals(uitgeverijnaam)).FirstOrDefault();
        }

    }
}