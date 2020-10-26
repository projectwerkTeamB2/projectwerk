using Datalaag;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace Businesslaag.Models
{
    public class StripManager
    {
        public StripManager()
        {
            DbFunctions dbf = new DbFunctions();
            string connectionString = dbf.conString;
        }

        public object DbFunctions { get; }

        public void AddStrip() {
        
        }

    }
}
