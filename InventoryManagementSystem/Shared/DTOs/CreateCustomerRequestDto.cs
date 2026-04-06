namespace InventoryManagementSystem.Shared.DTOs
{
    public class CreateCustomerRequestDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
    }
}