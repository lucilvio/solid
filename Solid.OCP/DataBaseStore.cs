using Dapper;
using System;
using System.Data.SqlClient;
using System.IO;

namespace Solid.OCP
{
    internal class DataBaseStore : Store
    {
        public DataBaseStore(string connectionString)
        {
            if (string.IsNullOrEmpty(connectionString))
                throw new ArgumentException("Connection cannot be empty");

            this.ConnectionString = connectionString;

        }

        public string ConnectionString { get; }

        internal override FileInfo GetFileInfo(int id)
        {
            throw new NotImplementedException();
        }

        internal override void WriteAllText(int id, string message)
        {
            using(var con = new SqlConnection(this.ConnectionString))
            {
                con.Execute("insert into messages values(@id, @message)", new { id, message });
            }
        }

        internal override string ReadAllText(int id)
        {
            using (var con = new SqlConnection(this.ConnectionString))
            {
                return con.QueryFirst<string>("select msg from messages where id = @id", new { id });
            }
        }
    }
}