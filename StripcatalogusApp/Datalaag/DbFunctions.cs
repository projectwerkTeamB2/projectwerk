using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace Datalaag
{
    /// <summary>
    ///
    /// </summary>
    public class DbFunctions
    {
        static string GetConnectionStringByName(string name)
        {
            // Assume failure.
            string returnValue = null;

            // Look for the name in the connectionStrings section.
            ConnectionStringSettings settings =
                ConfigurationManager.ConnectionStrings[name];

            // If found, return the connection string.
            if (settings != null)
                returnValue = settings.ConnectionString;

            return returnValue;
        }

        public static SqlConnection MyConnection()
        {
            SqlConnection connection = new SqlConnection(GetConnectionStringByName("projectwerkconnection"));
            return connection;
        }
    }

}
