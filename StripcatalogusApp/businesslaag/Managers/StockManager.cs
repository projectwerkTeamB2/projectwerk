using Businesslaag.Models;
using Businesslaag.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Businesslaag.Managers {
    public class StockManager {
        private GeneralManager _generalManager;
        internal IStockRepository _stockRepository;

        #region Constructor
        public StockManager (GeneralManager generalManager, IStockRepository stockRepository) {
            _generalManager = generalManager;
            _stockRepository = stockRepository;
        }
        #endregion

        public void AddDictionary(Dictionary<Strip,int> dict)
        {
            if (DoubleDictionaryNotFound(dict)) 
            {
                this._stockRepository.AddDictionary(dict);
            }
            else throw new ArgumentException("stock bestaat al");
        }

        public List<Stock> GetAll()
        {
            return (List<Stock>)this._stockRepository.GetAll();
        }

        public Stock GetById(int id)
        {
            return this._stockRepository.GetById(id);
        }

        public void Update(int id)
        {
            if (GetById(id) != null)
            {
                this._stockRepository.DeleteById(id);
            }
            else
            {
                throw new ArgumentException("trying to update an Stock that does not exist");
            }
        }

        public void Delete(Dictionary<Strip, int> dict)
        {
            if (GetById(dict.FirstOrDefault().Key.ID) != null)
            {
                this._stockRepository.DeleteById(dict.FirstOrDefault().Key.ID);
            }
            else
            {
                throw new ArgumentException("trying to delete an Stock that does not exist");
            }
        }

        private Boolean DoubleDictionaryNotFound(Dictionary<Strip,int> dict)
        {
            if (this._stockRepository.GetAllDictionary().Any(i => i.Key.ID == dict.FirstOrDefault().Key.ID))
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
