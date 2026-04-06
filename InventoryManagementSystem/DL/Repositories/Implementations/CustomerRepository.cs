using Dapper;
using InventoryManagementSystem.DL.DbContext;
using InventoryManagementSystem.DL.Entities;
using InventoryManagementSystem.DL.Repositories.Abstractions;
using InventoryManagementSystem.DL.SqlQueries;
using System.Data;

namespace InventoryManagementSystem.DL.Repositories.Implementations
{
    public class CustomerRepository(DapperContext context) : ICustomerRepository
    {
        public async Task<IEnumerable<CustomerEntity>> GetCustomers()
        {
            using IDbConnection connection = context.CreateConnection();

            return await connection.QueryAsync<CustomerEntity>(
                CustomerQueries.GetCustomers);
        }

        public async Task<CustomerEntity?> GetCustomerById(long customerId)
        {
            using IDbConnection connection = context.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<CustomerEntity>(
                CustomerQueries.GetCustomerById,
                new { CustomerId = customerId });
        }

        public async Task<long> CreateCustomer(CustomerEntity customer)
        {
            using IDbConnection connection = context.CreateConnection();

            return await connection.ExecuteScalarAsync<long>(
                CustomerQueries.CreateCustomer,
                customer);
        }

        public async Task<bool> UpdateCustomer(CustomerEntity customerEntity)
        {
            using IDbConnection connection = context.CreateConnection();

            int rows = await connection.ExecuteAsync(CustomerQueries.UpdateCustomer, customerEntity);

            return rows > 0;
        }

        public async Task<bool> DeleteCustomer(long customerId)
        {
            using IDbConnection connection = context.CreateConnection();

            int rows = await connection.ExecuteAsync(
                CustomerQueries.SoftDeleteCustomer,
                new { CustomerId = customerId });

            return rows > 0;
        }
    }
}
