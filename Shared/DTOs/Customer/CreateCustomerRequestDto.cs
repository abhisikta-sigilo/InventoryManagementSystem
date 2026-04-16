namespace Shared.DTOs.Customer
{
    public class CreateCustomerRequestDto
    {
        public required string CustomerName { get; set; }

        public required string Email { get; set; }

        public string? Phone { get; set; }
    }
}