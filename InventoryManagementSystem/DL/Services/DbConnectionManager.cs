using Microsoft.Data.SqlClient;
using System.Data;

namespace InventoryManagementSystem.DL.Services
{
    public abstract class DbConnectionManager
    {
        private readonly string _connectionString;
        protected DbConnectionManager(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")
                                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
        }

        protected IDbConnection CreateSqlConnection()
        {
            return new SqlConnection(_connectionString);
        }

        private async Task<T> ExecuteDatabaseOperation<T>(
        Func<IDbConnection, Task<T>> dbOperation)
        {
            using IDbConnection connection = CreateSqlConnection();

            connection.Open();

            return await dbOperation(connection);
        }

        protected async Task<T> DbOperation<T>(Func<IDbConnection, Task<T>> dbOperation)
        {
            return await ExecuteDatabaseOperation(dbOperation);
        }

        protected async Task<T> DbOperationInTransaction<T>(
            Func<IDbConnection, IDbTransaction, Task<T>> dbOperation)
        {
            return await ExecuteDatabaseOperation(async connection =>
            {
                using IDbTransaction transaction = connection.BeginTransaction();
                try
                {
                    T dbOperationResult = await dbOperation(connection, transaction);
                    transaction.Commit();

                    return dbOperationResult;
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            });
        }
    }
}
