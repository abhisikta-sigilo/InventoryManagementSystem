using Dapper;
using InventoryManagementSystem.DL.Entities;
using InventoryManagementSystem.DL.Repositories.Abstractions;
using InventoryManagementSystem.DL.Services;
using InventoryManagementSystem.DL.SqlQueries;

namespace InventoryManagementSystem.DL.Repositories.Implementations
{
    public class CustomerRepository(IConfiguration configuration
        ) : DbConnectionManager(configuration), ICustomerRepository
    {
        public async Task<IEnumerable<CustomerEntity>> GetCustomers()
        {
            return await ExecuteDatabaseOperation(connection =>
                connection.QueryAsync<CustomerEntity>(
                CustomerQueries.GetCustomers));
        }

        public async Task<CustomerEntity?> GetCustomerById(long customerId)
        {
            return await ExecuteDatabaseOperation(connection =>
                connection.QueryFirstOrDefaultAsync<CustomerEntity>(
                    CustomerQueries.GetCustomerById,
                    new { CustomerId = customerId }));
        }

        public async Task<long> CreateCustomer(CustomerEntity customer)
        {
            return await ExecuteDatabaseOperation(connection =>
                connection.ExecuteScalarAsync<long>(
                    CustomerQueries.CreateCustomer,
                    customer));
        }

        public async Task<bool> UpdateCustomer(CustomerEntity customerEntity)
        {
            return await ExecuteDatabaseOperation(async connection =>
            {
                int rows = await connection.ExecuteAsync(
                    CustomerQueries.UpdateCustomer, customerEntity);

                return rows > 0;
            });
        }

        public async Task<bool> DeleteCustomer(long customerId)
        {
            return await ExecuteDatabaseOperation(async connection =>
            {
                int rows = await connection.ExecuteAsync(
                CustomerQueries.SoftDeleteCustomer,
                new { CustomerId = customerId });

                return rows > 0;
            });            
        }
    }
}
