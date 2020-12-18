using Businesslaag.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Businesslaag.Repositories {
    public interface IStockRepository: IRepository<Stock> {
        public void Update(int id);
        public void AddDictionary(Dictionary<Strip, int> dict);
        public Dictionary<Strip, int> GetAllDictionary();
    }
}
