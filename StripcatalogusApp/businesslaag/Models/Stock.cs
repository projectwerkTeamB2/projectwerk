using System;
using System.Collections.Generic;
using System.Text;

namespace Businesslaag.Models {
    public class Stock {

        public Dictionary<Strip, int> StripHoeveelHeden;
      
        public Stock(Dictionary<Strip, int> stripHoeveelHeden) {
            StripHoeveelHeden = stripHoeveelHeden;
        }

    }
}
