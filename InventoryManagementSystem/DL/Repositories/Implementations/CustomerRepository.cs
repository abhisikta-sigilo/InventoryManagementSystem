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
        public async Task<IEnumerable<Customer>> GetCustomers()
        {
            using IDbConnection connection = context.CreateConnection();

            return await connection.QueryAsync<Customer>(
                CustomerQueries.GetCustomers);
        }

        public async Task<Customer?> GetCustomerById(long customerId)
        {
            using IDbConnection connection = context.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Customer>(
                CustomerQueries.GetCustomerById,
                new { CustomerId = customerId });
        }

        public async Task<long> CreateCustomer(Customer customer)
        {
            using IDbConnection connection = context.CreateConnection();

            return await connection.ExecuteScalarAsync<long>(
                CustomerQueries.CreateCustomer,
                customer);
        }

        public async Task<bool> UpdateCustomer(long customerId, Customer customer)
        {
            using IDbConnection connection = context.CreateConnection();

            int rows = await connection.ExecuteAsync(
                CustomerQueries.UpdateCustomer,
                new
                {
                    CustomerId = customerId,
                    customer.Name,
                    customer.Email,
                    customer.Phone
                });

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
