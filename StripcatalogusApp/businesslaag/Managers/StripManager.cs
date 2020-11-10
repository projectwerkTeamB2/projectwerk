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
    /// 
    
    public class StripManager
    {
        private GeneralManager _gm;
        internal IStripRepository _stripRepository;
        #region [Constructor]
        /// <summary>
        /// Default constructor
        /// </summary>
        public StripManager(GeneralManager generalManager , IStripRepository stripRepository)
        {
            _gm = generalManager;
            _stripRepository = stripRepository;
        }
        #endregion


        public void Add(Strip strip)
        {
            if (DoubleStripNotFound(strip))
              this._stripRepository.Add(strip);

        }
        public List<Strip> GetAll()
        {
            return (List<Strip>)this._stripRepository.GetAll();

        }

        public Strip GetById(int id)
        {
            return this._stripRepository.GetById(id);

        }

        public Strip getLastId() 
        {
            return this._stripRepository.GetLastStrip();
        }

        public void Update(Strip strip) 
        {
           if(GetById(strip.ID) != null) 
            {
                throw new ArgumentException("trying to update a strip that does not exist");
            }
            else
            this._stripRepository.Update(strip);
          
        }

        public void Delete(Strip strip) 
        {
           if(GetById(strip.ID) != null)
            {
                this._stripRepository.DeleteById(strip.ID);
            }
            else
            {
                throw new ArgumentException("trying to delete an Author that does not exist");
            }
           
        }




        private Boolean DoubleStripNotFound(Strip strip)
        {
            if (this._stripRepository.GetAll().Any(i=> i.StripNr == strip.StripNr && i.StripTitel == strip.StripTitel))
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