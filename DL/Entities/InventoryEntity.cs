namespace DL.Entities
{
    public class InventoryEntity : BaseEntity
    {
        public long InventoryId { get; set; }

        public long ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
