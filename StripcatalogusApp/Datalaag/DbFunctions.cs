using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace Datalaag
{
    /// <summary>
    /// Deze methode haalt connection string op uit App.config
    /// Iedereens App.config heeft een andere connection string
    /// Zo kan iedereen makkelijk aan zijn eigen databank
    /// </summary>
    public  class DbFunctions
    {
        public  string conString;

        public  DbFunctions() {
            conString = GetprojectwerkconnectionString();
        }

      public static  string GetprojectwerkconnectionString()
        {
            return ConfigurationManager.ConnectionStrings["projectwerkconnectionString"].ConnectionString;
                
        }


    }

}
