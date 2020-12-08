using Datalaag;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace integratieTests {
    public class Initialize {
       
        public void ClearDB() {
            SqlConnection conn = new SqlConnection(DbFunctions.GetprojectwerkconnectionString());
            string query = "delete Strip delete Strip_has_Auteur delete Uitgeverij delete Reeks delete Auteur";
            using(SqlCommand cmd = conn.CreateCommand()) {
                cmd.CommandText = query;
                conn.Open();
                try {
                    cmd.ExecuteNonQuery();
                } catch(Exception e) {
                    Console.WriteLine(e.Message);
                } finally {
                    conn.Close();
                }
            }
        }
    }
}
