namespace Shared.DTOs.Order
{
    public class OrderCreateRequestDto
    {
        public long CustomerId { get; set; }
        public List<OrderItemCreateRequestDto> OrderItems { get; set; }
    }

    public class OrderItemCreateRequestDto
    {
        public long ProductId { get; set; }

        public int Quantity { get; set; }
    }
}