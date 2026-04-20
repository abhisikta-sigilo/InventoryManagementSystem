using Dapper;
using DL.Entities;
using Shared.DTOs.Order;
using DL.Repositories.Abstractions;
using DL.Services;
using DL.SqlQueries;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace DL.Repositories.Implementations
{
    public class OrderRepository(IConfiguration configuration
        ) : DbConnectionManager(configuration), IOrderRepository
    {
        public async Task<IEnumerable<OrderEntity>> GetOrders(
            OrderFilterRequestDto orderFilterRequestDto)
        {
            return await DbOperation(async connection =>
            {
                StringBuilder sql = new StringBuilder(OrderQueries.GetOrders);
                DynamicParameters parameters = new DynamicParameters();

                if (orderFilterRequestDto.CustomerId.HasValue)
                {
                    sql.Append(" AND o.CustomerId = @CustomerId");
                    parameters.Add("CustomerId", orderFilterRequestDto.CustomerId);
                }

                if (orderFilterRequestDto.OrderStatusId.HasValue)
                {
                    sql.Append(" AND o.OrderStatusId = @OrderStatusId");
                    parameters.Add("OrderStatusId", orderFilterRequestDto.OrderStatusId);
                }

                if (orderFilterRequestDto.OrderDate.HasValue)
                {
                    sql.Append(" AND CAST(o.OrderDate AS DATE) = @OrderDate");
                    parameters.Add("OrderDate", orderFilterRequestDto.OrderDate.Value.Date);
                }

                Dictionary<long, OrderEntity> orders = new Dictionary<long, OrderEntity>();

                _ = await connection.QueryAsync<OrderEntity, OrderItemEntity, OrderEntity>(
                    OrderQueries.GetOrders,
                    (OrderEntity order, OrderItemEntity item) =>
                    {
                        return MapOrderWithItems(orders, order, item);
                    },
                    parameters,
                    splitOn: "OrderItemId"
                );

                return orders.Values;
            });
        }

        public async Task<OrderEntity?> GetOrderById(long orderId)
        {
            return await DbOperation(async connection =>
            {
                Dictionary<long, OrderEntity> orders = new Dictionary<long, OrderEntity>();

                IEnumerable<OrderEntity> result = await connection.QueryAsync<OrderEntity, OrderItemEntity, OrderEntity>(
                    OrderQueries.GetOrderById,
                    (OrderEntity order, OrderItemEntity item) =>
                    {
                        return MapOrderWithItems(orders, order, item);
                    },
                    new { OrderId = orderId },
                    splitOn: "OrderItemId"
                );

                return orders.Values.FirstOrDefault();
            });
        }


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

        public async Task<bool> UpdateOrderStatus(long orderId, int statusId)
        {
            return await DbOperation(async connection =>
            {
                int rowsAffected = await connection.ExecuteAsync(
                    OrderQueries.UpdateOrderStatus,
                    new { OrderId = orderId, OrderStatusId = statusId }
                );

                return rowsAffected > 0;
            });
        }

        private OrderEntity MapOrderWithItems(
            Dictionary<long, OrderEntity> orders,
            OrderEntity order,
            OrderItemEntity item)
        {
            if (!orders.ContainsKey(order.OrderId))
            {
                order.OrderItems = new List<OrderItemEntity>();
                orders.Add(order.OrderId, order);
            }

            if (item.OrderItemId != 0)
            {
                orders[order.OrderId].OrderItems.Add(item);
            }

            return order;
        }
    }
}