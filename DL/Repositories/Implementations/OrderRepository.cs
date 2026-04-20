using Dapper;
using DL.Entities;
using DL.Repositories.Abstractions;
using DL.Services;
using DL.SqlQueries;
using Microsoft.Extensions.Configuration;

namespace DL.Repositories.Implementations
{
    public class OrderRepository(IConfiguration configuration
        ) : DbConnectionManager(configuration), IOrderRepository
    {
        //public async Task<long> CreateOrder(OrderEntity orderEntity)
        //{
        //    return await DbOperation(connection =>
        //        connection.ExecuteScalarAsync<long>(
        //            OrderQueries.CreateOrder,
        //            orderEntity));
        //}

        //public async Task<int> CreateOrderItem(IEnumerable<OrderItemEntity> orderItemEntities)
        //{
        //    return await DbOperation(connection =>
        //        connection.ExecuteAsync(
        //            OrderQueries.CreateOrderItem,
        //            orderItemEntities));
        //}

        public async Task<long> CreateOrderWithItems(
            OrderEntity orderEntity,
            IEnumerable<OrderItemEntity> orderItemEntities)
        {
            return await DbOperationInTransaction(async (connection, transaction) =>
            {
                long orderId = await connection.ExecuteScalarAsync<long>(
                    OrderQueries.CreateOrder,
                    orderEntity,
                    transaction);

                foreach (OrderItemEntity item in orderItemEntities)
                {
                    item.OrderId = orderId;
                }
                await connection.ExecuteAsync(
                    OrderQueries.CreateOrderItem,
                    orderItemEntities,
                    transaction);

                foreach (OrderItemEntity item in orderItemEntities)
                {
                    await connection.ExecuteAsync(
                        InventoryQueries.DeductStock,
                        new
                        {
                            ProductId = item.ProductId,
                            Quantity = item.Quantity
                        },
                        transaction);
                }
                return orderId;
            });
        }
    }
}