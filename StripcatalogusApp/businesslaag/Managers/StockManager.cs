using Businesslaag.Models;
using Businesslaag.Repositories;
using System;
using System.Collections.Generic;
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
        //VRAAG: Add nodig voor stock?
        public void Add(Stock stock) {

        }
    }
}
