using DL.Entities;
using Shared.DTOs.Order;

namespace DL.Repositories.Abstractions
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderEntity>> GetOrders(OrderFilterRequestDto orderFilterRequestDto);

        Task<OrderEntity?> GetOrderById(long orderId);

        //Task<long> CreateOrder(OrderEntity orderEntity);

        //Task<int> CreateOrderItem(IEnumerable<OrderItemEntity> orderItemEntities);

        Task<long> CreateOrderWithItems(
            OrderEntity orderEntity,
            IEnumerable<OrderItemEntity> orderItemEntities);

        Task<bool> UpdateOrderStatus(long orderId, int statusId);
    }
}
