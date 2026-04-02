namespace InventoryManagementSystem.Shared.DTOs
{
    public class CreateCustomerDto
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public string? Phone { get; set; }
    }
}