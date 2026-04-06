using InventoryManagementSystem.Shared.DTOs.Customer;

namespace InventoryManagementSystem.BL.Services.Abstractions
{
    public interface ICustomerService
    {
        Task<IEnumerable<CustomerResponseDto>> GetCustomers();

        Task<CustomerResponseDto> GetCustomerById(long customerId);

        Task CreateCustomer(CreateCustomerRequestDto createCustomerDto);

        Task UpdateCustomer(long customerId, UpdateCustomerRequestDto updateCustomerDto);

        Task DeleteCustomer(long customerId);
    }
}
