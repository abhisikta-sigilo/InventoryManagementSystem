namespace DL.Entities
{
    public class OrderEntity : BaseEntity
    {
        public long OrderId { get; set; }

        public long CustomerId { get; set; }

        public Decimal TotalAmount { get; set; }

        public int OrderStatusId { get; set; }

        public DateTime OrderDate { get; set; }

        public List<OrderItemEntity>? OrderItems { get; set; }
    }
}