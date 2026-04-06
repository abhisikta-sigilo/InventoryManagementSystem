namespace InventoryManagementSystem.Shared.DTOs.Product
{
    public class CreateProductRequestDto
    {
        public string? Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }
    }
}
