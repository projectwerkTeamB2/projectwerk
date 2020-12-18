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

        public void Add(Stock stock)
        {
            if (DoubleStockNotFound(stock))
            {
                this._stockRepository.Add(stock);
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

        public void Update(Stock stock)
        {
            if (GetById(stock.StripHoeveelHeden.ContainsKey()) == null)
            {
                throw new ArgumentException("trying to update an Author that does not exist");
            }
            else
                this._stockRepository.Update(stock);
        }

        public void Delete(Stock stock)
        {
            if (GetById(stock.ID) != null)
            {
                this._stockRepository.DeleteById(stock.ID);
            }
            else
            {
                throw new ArgumentException("trying to delete an Stock that does not exist");
            }
        }

        private Boolean DoubleStockNotFound(Stock stock)
        {
            if (this._stockRepository.GetAll().Any(i => i.ID == stock.ID))
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
