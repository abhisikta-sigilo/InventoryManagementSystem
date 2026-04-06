using InventoryManagementSystem.BL.Services.Abstractions;
using InventoryManagementSystem.DL.Entities;
using InventoryManagementSystem.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace OrderManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController(ICustomerService customerService) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetCustomers()
        {
            IEnumerable<CustomerResponseDto> customerResponseDtos = await customerService.GetCustomers();
            return Ok(customerResponseDtos);
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerById(long customerId)
        {
            CustomerResponseDto? customerResponseDto = await customerService.GetCustomerById(customerId);

            if (customerResponseDto == null)
                return NotFound();

            return Ok(customerResponseDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CreateCustomerRequestDto createCustomerDto)
        {
            long customerId = await customerService.CreateCustomer(createCustomerDto);

            CustomerResponseDto? customerResponseDto = await customerService.GetCustomerById(customerId);

            return CreatedAtAction(
                nameof(GetCustomerById),
                new { customerId },
                customerResponseDto);
        }

        [HttpPut("{customerId}")]
        public async Task<IActionResult> UpdateCustomer(
            long customerId,
            UpdateCustomerRequestDto updateCustomerDto)
        {
            bool updated = await customerService.UpdateCustomer(customerId, updateCustomerDto);

            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomer(long customerId)
        {
            bool deleted = await customerService.DeleteCustomer(customerId);

            if (!deleted)
                return NotFound();

            return NoContent();
        }
    }
}