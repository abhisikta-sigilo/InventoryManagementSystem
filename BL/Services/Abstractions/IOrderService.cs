using Shared.DTOs.Order;

namespace BL.Services.Abstractions
{
    public interface IOrderService
    {
        Task<IEnumerable<OrderResponseDto>> GetOrders(OrderFilterRequestDto filter);

        Task<OrderResponseDto?> GetOrderById(long orderId);

        Task<OrderResponseDto> CreateOrder(OrderCreateRequestDto request);
    }
}