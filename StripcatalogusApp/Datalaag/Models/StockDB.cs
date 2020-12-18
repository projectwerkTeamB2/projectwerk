using Businesslaag.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Datalaag.Models {
    public class StockDB {

        public Dictionary<Strip, int> StripHoeveelHeden;

        public StockDB(Dictionary<Strip, int> stripHoeveelHeden)
        {
            StripHoeveelHeden = stripHoeveelHeden;
        }
    }
}
