using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
namespace DataLayer.Repositories
{
    /// <summary>
    /// abstracte classe voor het manipuleren van de databank.
    /// andere classes gaan deze implementeren
    /// </summary>
    /// <typeparam name="T"></typeparam>

    public abstract class CRUDRepository<T> where T : class
    {
        private static SqlConnection _connection;
        public CRUDRepository(string connectionString)
        {
            _connection = new SqlConnection(connectionString);
        }
        public virtual T PopulateRecord(SqlDataReader reader)
        {
            return null;
        }
        protected IEnumerable<T> GetRecords(SqlCommand command)
        {
            var list = new List<T>();
            command.Connection = _connection;
            _connection.Open();
            try
            {
                var reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                        list.Add(PopulateRecord(reader));
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
            finally
            {
                _connection.Close();
            }
            return list;
        }
        protected T GetRecord(SqlCommand command)
        {
            T record = null;
            command.Connection = _connection;
            _connection.Open();
            try
            {
                var reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        record = PopulateRecord(reader);
                        break;
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }
            finally
            {
                _connection.Close();
            }
            return record;
        }

        protected void ExecuteCommand(SqlCommand command)
        {
            command.Connection = _connection;
            command.CommandType = CommandType.Text;
            _connection.Open();
            try
            {
                command.ExecuteNonQuery();
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}