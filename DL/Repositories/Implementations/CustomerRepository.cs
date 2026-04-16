using Dapper;
using DL.Entities;
using DL.Repositories.Abstractions;
using DL.Services;
using DL.SqlQueries;
using Microsoft.Extensions.Configuration;

namespace DL.Repositories.Implementations
{
    public class CustomerRepository(IConfiguration configuration
        ) : DbConnectionManager(configuration), ICustomerRepository
    {
        public async Task<IEnumerable<CustomerEntity>> GetCustomers()
        {
            return await DbOperation(connection =>
                connection.QueryAsync<CustomerEntity>(
                CustomerQueries.GetCustomers));
        }

        public async Task<CustomerEntity?> GetCustomerById(long customerId)
        {
            return await DbOperation(connection =>
                connection.QueryFirstOrDefaultAsync<CustomerEntity>(
                    CustomerQueries.GetCustomerById,
                    new { CustomerId = customerId }));
        }

        public async Task<long> CreateCustomer(CustomerEntity customer)
        {
            return await DbOperation(connection =>
                connection.ExecuteScalarAsync<long>(
                    CustomerQueries.CreateCustomer,
                    customer));
        }

        public async Task<bool> UpdateCustomer(CustomerEntity customerEntity)
        {
            return await DbOperation(async connection =>
            {
                int rows = await connection.ExecuteAsync(
                    CustomerQueries.UpdateCustomer, customerEntity);

                return rows > 0;
            });
        }

        public async Task<bool> DeleteCustomer(long customerId)
        {
            return await DbOperation(async connection =>
            {
                int rows = await connection.ExecuteAsync(
                CustomerQueries.SoftDeleteCustomer,
                new { CustomerId = customerId });

                return rows > 0;
            });            
        }
    }
}
