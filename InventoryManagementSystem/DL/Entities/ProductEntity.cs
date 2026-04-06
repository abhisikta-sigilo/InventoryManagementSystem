namespace InventoryManagementSystem.DL.Entities
{
    public class ProductEntity : BaseEntity
    {
        public long ProductId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
