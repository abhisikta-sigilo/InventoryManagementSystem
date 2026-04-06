namespace InventoryManagementSystem.DL.Entities
{
    public class Customer : BaseEntity
    {
        public long CustomerId { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public string? Phone { get; set; }

    }
}
