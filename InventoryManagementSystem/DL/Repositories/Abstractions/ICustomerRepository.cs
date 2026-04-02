using InventoryManagementSystem.DL.Entities;

namespace InventoryManagementSystem.DL.Repositories.Abstractions
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<Customer?> GetCustomerById(long customerId);
        Task<long> CreateCustomer(Customer customer);
        Task<bool> UpdateCustomer(long customerId, Customer customer);
        Task<bool> DeleteCustomer(long customerId);

    }
}
