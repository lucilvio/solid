using Dapper;
using System;
using System.Data.SqlClient;

namespace Solid.ISP
{
    internal class DataBaseStoreReader : IStoreReader
    {
        public DataBaseStoreReader(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException("Connection cannot be empty");

            this.ConnectionString = connectionString;
        }

        public string ConnectionString { get; }

        public string ReadAllText(int id)
        {
            using (var con = new SqlConnection(this.ConnectionString))
            {
                return con.QueryFirst<string>("select msg from messages where id = @id", new { id });
            }
        }
    }
}