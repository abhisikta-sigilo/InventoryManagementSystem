namespace Shared.DTOs.Order
{
    public class OrderResponseDto
    {
        public long OrderId { get; set; }

        public long CustomerId { get; set; }

        public decimal TotalAmount { get; set; }

        public int OrderStatusId { get; set; }

        public DateTime OrderDate { get; set; }

        public List<OrderItemResponseDto> Items { get; set; }
    }

    public class OrderItemResponseDto
    {
        public long ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }
    }
}
