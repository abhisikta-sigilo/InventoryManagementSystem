namespace Shared.DTOs.Order
{
    public class OrderFilterRequestDto
    {
        public long? CustomerId { get; set; }

        public int? OrderStatusId { get; set; }

        public DateTime? OrderDate { get; set; }

    }
}
