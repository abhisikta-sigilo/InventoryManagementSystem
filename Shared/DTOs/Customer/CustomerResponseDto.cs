namespace Shared.DTOs.Customer
{
    public class CustomerResponseDto
    {
        public long CustomerId { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public string? Phone { get; set; }
    }
}