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
        public async Task<long> CreateCustomer(CreateCustomerRequestDto createCustomerDto)
        {
            Customer customer = mapper.Map<Customer>(createCustomerDto);

            return await customerRepository.CreateCustomer(customer);
        }

        public async Task<IEnumerable<CustomerResponseDto>> GetCustomers()
        {
            IEnumerable<Customer> customers = await customerRepository.GetCustomers();

            return mapper.Map<IEnumerable<CustomerResponseDto>>(customers);
        }

        public async Task<CustomerResponseDto?> GetCustomerById(long customerId)
        {
            Customer? customer = await customerRepository.GetCustomerById(customerId);

            if (customer == null)
                return null;

            return mapper.Map<CustomerResponseDto>(customer);
        }

        public async Task<bool> UpdateCustomer(long customerId, UpdateCustomerRequestDto updateCustomerDto)
        {
            Customer customer = mapper.Map<Customer>(updateCustomerDto);

            return await customerRepository.UpdateCustomer(customerId, customer);
        }

        public async Task<bool> DeleteCustomer(long customerId)
        {
            return await customerRepository.DeleteCustomer(customerId);
        }
    }
}
