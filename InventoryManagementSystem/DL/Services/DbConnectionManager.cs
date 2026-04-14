using Microsoft.Data.SqlClient;
using System.Data;

namespace InventoryManagementSystem.DL.Services
{
    public abstract class DbConnectionManager
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        public DbConnectionManager(IConfiguration configuration)
        {
            _configuration = configuration;

            _connectionString = _configuration.GetConnectionString("DefaultConnection")
                                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        public IDbConnection CreateSqlConnection()
        {
            return new SqlConnection(_connectionString);
        }

        protected async Task<T> ExecuteDatabaseOperation<T>(
        Func<IDbConnection, Task<T>> dbOperation)
        {
            using IDbConnection connection = CreateSqlConnection();

            connection.Open();

            return await dbOperation(connection);
        }

    }
}
