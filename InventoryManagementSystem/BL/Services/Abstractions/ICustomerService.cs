using InventoryManagementSystem.Shared.DTOs;

namespace InventoryManagementSystem.BL.Services.Abstractions
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerResponseDto>> GetCustomers();
        Task<CustomerResponseDto?> GetCustomerById(long customerId);
        Task<long> CreateCustomer(CreateCustomerRequestDto createCustomerDto);
        Task<bool> UpdateCustomer(long customerId, UpdateCustomerRequestDto updateCustomerDto);
        Task<bool> DeleteCustomer(long customerId);
    }
}
