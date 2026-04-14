namespace InventoryManagementSystem.Shared.DTOs.Inventory
{
    public class InventoryResponseDto
    {
        public long InventoryId { get; set; }

        public long ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
