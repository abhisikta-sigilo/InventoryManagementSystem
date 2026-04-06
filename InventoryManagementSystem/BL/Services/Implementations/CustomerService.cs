using AutoMapper;
using InventoryManagementSystem.BL.Services.Abstractions;
using InventoryManagementSystem.DL.Entities;
using InventoryManagementSystem.DL.Repositories.Abstractions;
using InventoryManagementSystem.Shared.DTOs;

namespace InventoryManagementSystem.BL.Services.Implementations
{
    public class CustomerService(
        ICustomerRepository customerRepository,
        IMapper mapper
    ) : ICustomerService
    {
        public async Task<IEnumerable<CustomerResponseDto>> GetCustomers()
        {
            IEnumerable<Customer> customers = await customerRepository.GetCustomers();

            return mapper.Map<IEnumerable<CustomerResponseDto>>(customers);
        }

        public async Task<CustomerResponseDto> GetCustomerById(long customerId)
        {
            Customer? customer = await customerRepository.GetCustomerById(customerId);

            if (customer == null)
                throw new KeyNotFoundException("Customer not found");

            return mapper.Map<CustomerResponseDto>(customer);
        }

        public async Task CreateCustomer(CreateCustomerRequestDto createCustomerDto)
        {
            Customer customer = mapper.Map<Customer>(createCustomerDto);

            await customerRepository.CreateCustomer(customer);
        }

        public async Task UpdateCustomer(long customerId, UpdateCustomerRequestDto updateCustomerDto)
        {
            Customer customer = mapper.Map<Customer>(updateCustomerDto);

            bool updated = await customerRepository.UpdateCustomer(customerId, customer);

            if (!updated)
                throw new KeyNotFoundException("Customer not found");
        }

        public async Task DeleteCustomer(long customerId)
        {
            bool deleted = await customerRepository.DeleteCustomer(customerId);

            if (!deleted)
                throw new KeyNotFoundException("Customer not found");
        }
    }
}
