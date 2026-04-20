using Shared.DTOs.Order;

namespace BL.Services.Abstractions
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponseDto>> GetOrders(OrderFilterRequestDto orderFilterRequestDto);

        Task<OrderResponseDto?> GetOrderById(long orderId);

        Task<OrderResponseDto> CreateOrder(OrderCreateRequestDto orderCreateRequestDto);

        Task UpdateOrderStatus(long orderId, int newStatusId);
    }
}