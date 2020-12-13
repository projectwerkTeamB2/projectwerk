using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Businesslaag.Models;
using Businesslaag.Repositories;

namespace Businesslaag.Managers
{
    /// <summary>
    ///klasse verantwoordelijk voor alles ivm reeks wat via de businesslaag gecommuniceerd moet worden naar de datalaag. 
    /// kan enkel aan zijn eigen repository voor de andere moet het de generalManager aanspreken.
    /// voert ook controlles uit of hij al bestaat enz 
    /// </summary>

    public class ReeksManager
    {
        private GeneralManager _gm;
        #region [Constructor]
        /// <summary>
        /// Default constructor
        /// </summary>

        internal IReeksRepository _reeksRepository;
        public ReeksManager(GeneralManager generalManager, IReeksRepository reeksRepository)
        {
            _gm = generalManager;
            _reeksRepository = reeksRepository;
        }


        public void Add(Reeks reeks)
        {
          
            if (DoubleReeksNotFound(reeks)) { 
               this._reeksRepository.Add(reeks);
            }
            else throw new ArgumentException("Reeks bestaat al");
        }


        public List<Reeks> GetAll()
        {
            return (List<Reeks>)this._reeksRepository.GetAll();

        }

        public Reeks GetById(int id)
        {
            return this._reeksRepository.GetById(id);

        }

        public void Update(Reeks reeks)
        {
            if (GetById(reeks.ID) != null)
            {
                this._reeksRepository.Update(reeks);
            }
            else
                
            throw new ArgumentException("trying to update a series that does not exist");

        }

        public void Delete(Reeks reeks)
        {
            if(GetById(reeks.ID) != null)
            {
                this._reeksRepository.DeleteById(reeks.ID);
            }
            else
            {
                throw new ArgumentException("trying to delete a series that does not exist");
            }
           
        }

        private Boolean DoubleReeksNotFound(Reeks reeks)
        {
       //     if (this._reeksRepository.GetAll().Any(i => i.ID == reeks.ID && i.Naam.ToLower() == reeks.Naam.ToLower())) //weg moeten doen voor toevoegen, sinds nieuwe altijd id 0 hebben?
            if (this._reeksRepository.GetAll().Any(i => i.Naam == reeks.Naam))
            {
                return false;
            }
            else
            {
                return true;
            }
        }


        public Reeks GetByName(string reeksnaam)
        {
            return this._reeksRepository.GetAll().Where(n => n.Naam.Equals(reeksnaam)).FirstOrDefault();
        }

        #endregion

    }
}