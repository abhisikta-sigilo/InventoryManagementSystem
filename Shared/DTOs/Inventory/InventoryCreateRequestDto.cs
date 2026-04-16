namespace Shared.DTOs.Inventory
{
    public class InventoryCreateRequestDto
    {
        public long ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
