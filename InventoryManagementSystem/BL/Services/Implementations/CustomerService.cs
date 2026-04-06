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
            IEnumerable<CustomerEntity> customerEntities = await customerRepository.GetCustomers();

            return mapper.Map<IEnumerable<CustomerResponseDto>>(customerEntities);
        }

        public async Task<CustomerResponseDto> GetCustomerById(long customerId)
        {
            CustomerEntity? customerEntity = await customerRepository.GetCustomerById(customerId);

            if (customerEntity == null)
                throw new KeyNotFoundException("Customer not found");

            return mapper.Map<CustomerResponseDto>(customerEntity);
        }

        public async Task CreateCustomer(CreateCustomerRequestDto createCustomerDto)
        {
            CustomerEntity customerEntity = mapper.Map<CustomerEntity>(createCustomerDto);

            await customerRepository.CreateCustomer(customerEntity);
        }

        public async Task UpdateCustomer(long customerId, UpdateCustomerRequestDto updateCustomerDto)
        {
            CustomerEntity customerEntity = mapper.Map<CustomerEntity>(updateCustomerDto);
            customerEntity.CustomerId = customerId;

            bool updated = await customerRepository.UpdateCustomer(customerEntity);

            if (!updated)
                throw new KeyNotFoundException("Customer not found");
        }

        public async Task DeleteCustomer(long customerId)
        {
            CustomerEntity? customerEntity = await customerRepository.GetCustomerById(customerId);

            if (customerEntity == null)
                throw new KeyNotFoundException("Customer not found");

            await customerRepository.DeleteCustomer(customerId);
        }
    }
}
