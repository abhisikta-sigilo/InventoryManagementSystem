namespace InventoryManagementSystem.Shared.DTOs.Inventory
{
    public class InventoryUpdateRequestDto
    {
        public long ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
