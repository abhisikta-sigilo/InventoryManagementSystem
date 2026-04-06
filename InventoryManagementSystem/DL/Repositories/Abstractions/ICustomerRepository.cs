using InventoryManagementSystem.DL.Entities;

namespace InventoryManagementSystem.DL.Repositories.Abstractions
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerEntity>> GetCustomers();

        Task<CustomerEntity?> GetCustomerById(long customerId);

        Task<long> CreateCustomer(CustomerEntity customerEntity);

        Task<bool> UpdateCustomer(CustomerEntity customerEntity);

        Task<bool> DeleteCustomer(long customerId);
    }
}
