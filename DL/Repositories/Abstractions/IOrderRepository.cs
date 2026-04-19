using DL.Entities;

namespace DL.Repositories.Abstractions
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderEntity>> GetOrders(
            long? customerId,
            int? orderStatusId,
            DateTime? orderDate);

        //Task<long> CreateOrder(OrderEntity orderEntity);

        //Task<int> CreateOrderItem(IEnumerable<OrderItemEntity> orderItemEntities);

        Task<long> CreateOrderWithItems(
            OrderEntity orderEntity,
            IEnumerable<OrderItemEntity> orderItemEntities);
    }
}
