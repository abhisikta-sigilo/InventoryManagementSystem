namespace InventoryManagementSystem.Shared.DTOs.Product
{
    public class ProductCreateRequestDto
    {
        public string? ProductName { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }
    }
}
