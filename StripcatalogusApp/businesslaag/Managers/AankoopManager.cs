using Businesslaag.Models;
using Businesslaag.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Businesslaag.Managers {
    public class AankoopManager {
        private GeneralManager _gm;
        internal IAankoopRepository _aankoopRepository;
        #region [Constructor]
        /// <summary>
        /// Default constructor
        /// </summary>
        public AankoopManager(GeneralManager generalManager, IAankoopRepository aankoopRepository)
        {
            _gm = generalManager;
            _aankoopRepository = aankoopRepository;
        }
        #endregion

        public void Add(Aankoop aankoop)
        {
            if (DoubleAankoopNotFound(aankoop))
            {
                this._aankoopRepository.Add(aankoop);
            }
            else throw new ArgumentException("aankoop bestaat al");
        }

        public List<Aankoop> GetAll()
        {
            return (List<Aankoop>)this._aankoopRepository.GetAll();
        }

        public Aankoop GetById(int id)
        {
            return this._aankoopRepository.GetById(id);
        }

        public void Update(Aankoop aankoop)
        {
            if (GetById(aankoop.ID) == null)
            {
                throw new ArgumentException("trying to update an aankoop that does not exist");
            }
            else
                this._aankoopRepository.Update(aankoop);
        }

        public void Delete(Aankoop aankoop)
        {
            if (GetById(aankoop.ID) != null)
            {
                this._aankoopRepository.DeleteById(aankoop.ID);
            }
            else
            {
                throw new ArgumentException("trying to delete an aankoop that does not exist");
            }
        }

        private Boolean DoubleAankoopNotFound(Aankoop aankoop)
        {
            if (this._aankoopRepository.GetAll().Any(i => i.ID == aankoop.ID))
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
