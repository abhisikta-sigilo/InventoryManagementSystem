namespace InventoryManagementSystem.Shared.DTOs.Product
{
    public class ProductResponseDto
    {
        public long ProductId { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
