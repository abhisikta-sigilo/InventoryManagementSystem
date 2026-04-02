using InventoryManagementSystem.Shared.DTOs;

namespace InventoryManagementSystem.BL.Services.Abstractions
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerResponseDto>> GetCustomers();
        Task<CustomerResponseDto?> GetCustomerById(long customerId);
        Task<long> CreateCustomer(CreateCustomerDto createCustomerDto);
        Task<bool> UpdateCustomer(long customerId, UpdateCustomerDto updateCustomerDto);
        Task<bool> DeleteCustomer(long customerId);
    }
}
