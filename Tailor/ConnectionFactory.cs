using System;
using System.Data;
using System.Data.SqlClient;

namespace Tailor
{
    public class ConnectionFactory : IConnectionFactory, IDisposable
    {
        public ConnectionFactory(string connectionString)
        {
            Connection = new SqlConnection(connectionString);
            Connection.Open();
        }

        public IDbConnection Connection { get; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Connection.Close();
            }
        }
    }
}