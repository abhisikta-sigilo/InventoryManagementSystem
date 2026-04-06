using InventoryManagementSystem.BL.Services.Abstractions;
using InventoryManagementSystem.Shared.DTOs.Customer;
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
        public async Task<IActionResult> GetCustomerById(
            [FromRoute] long customerId)
        {
            CustomerResponseDto customerResponseDto = await customerService.GetCustomerById(customerId);

            return Ok(customerResponseDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(
            CreateCustomerRequestDto createCustomerDto)
        {
            await customerService.CreateCustomer(createCustomerDto);

            return Ok();
        }

        [HttpPut("{customerId}")]
        public async Task<IActionResult> UpdateCustomer(
            [FromRoute] long customerId,
            UpdateCustomerRequestDto updateCustomerDto)
        {
            await customerService.UpdateCustomer(customerId, updateCustomerDto);

            return NoContent();
        }

        [HttpDelete("{customerId}")]
        public async Task<IActionResult> DeleteCustomer(
            [FromRoute] long customerId)
        {
            await customerService.DeleteCustomer(customerId);

            return NoContent();
        }
    }
}