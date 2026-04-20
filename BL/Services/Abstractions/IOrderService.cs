using Shared.DTOs.Order;

namespace BL.Services.Abstractions
{
    public interface IOrderService
    {
        Task<OrderResponseDto> CreateOrder(OrderCreateRequestDto request);
    }
}