namespace DL.Entities
{
    public class OrderItemEntity : BaseEntity
    {
        public long OrderItemId { get; set; }

        public long OrderId { get; set; }

        public long ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
