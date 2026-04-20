using AutoMapper;
using BL.Services.Abstractions;
using DL.Entities;
using DL.Repositories.Abstractions;
using Shared.DTOs.Order;
using Shared.Enums;

namespace BL.Services.Implementations
{
    public class OrderService(
        IOrderRepository orderRepository,
        IProductRepository productRepository,
        IInventoryRepository inventoryRepository,
        IMapper mapper
        ) :IOrderService
    {
        public async Task<IEnumerable<OrderResponseDto>> GetOrders(
            OrderFilterRequestDto orderFilterRequestDto)
        {
            IEnumerable<OrderEntity> orderEntities = await orderRepository.GetOrders(
                filter.CustomerId,
                filter.OrderStatusId,
                filter.OrderDate);
                
            return mapper.Map<IEnumerable<OrderResponseDto>>(orderEntities);
        }
        public async Task<OrderResponseDto?> GetOrderById(long orderId)
        {
            OrderEntity? orderEntity = await orderRepository.GetOrderById(orderId);

            if (orderEntity == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            return mapper.Map<OrderResponseDto>(orderEntity);
        }

        public async Task<OrderResponseDto> CreateOrder(OrderCreateRequestDto orderCreateRequestDto)
        {
            decimal totalAmount = 0;

            List<OrderItemEntity> orderItemEntities = 
                mapper.Map<List<OrderItemEntity>>(orderCreateRequestDto.OrderItems);

            foreach (OrderItemEntity item in orderItemEntities)
            {
                ProductEntity? productEntity = await productRepository.GetProductById(item.ProductId);

                if (productEntity == null)
                    throw new Exception($"Product {item.ProductId} not found");

                InventoryEntity? inventory =
                    await inventoryRepository.GetInventoryByProductId(item.ProductId);

                if (inventory == null)
                    throw new Exception($"Inventory not found for product {item.ProductId}");

                if (inventory.Quantity < item.Quantity)
                    throw new Exception($"Insufficient stock for product {item.ProductId}");

                decimal itemTotal = productEntity.Price * item.Quantity;

                item.TotalPrice = itemTotal;

                totalAmount += itemTotal;
            }

            OrderEntity orderEntity = mapper.Map<OrderEntity>(orderCreateRequestDto);

            orderEntity.TotalAmount = totalAmount;
            orderEntity.OrderStatusId = (int)OrderStatus.Pending;
            orderEntity.OrderDate = DateTime.UtcNow;

            long orderId = await orderRepository.CreateOrderWithItems(
                orderEntity,
                orderItemEntities);

            orderEntity.OrderId = orderId;

            OrderResponseDto orderResponseDto =
                mapper.Map<OrderResponseDto>(orderEntity);

            orderResponseDto.OrderItems =
                mapper.Map<List<OrderItemResponseDto>>(orderItemEntities);

            return orderResponseDto;
        }

        public async Task UpdateOrderStatus(long orderId, int newStatusId)
        {
            OrderEntity? order = await orderRepository.GetOrderById(orderId);

            if (order == null)
            {
                throw new KeyNotFoundException("Order not found");
            }

            OrderStatus currentStatus = (OrderStatus)order.OrderStatusId;
            OrderStatus newStatus = (OrderStatus)newStatusId;

            ValidateStatusTransition(currentStatus, newStatus);

            bool updated = await orderRepository.UpdateOrderStatus(orderId, newStatusId);

            if (!updated)
            {
                throw new Exception("Order status not updated");
            }
        }

        private void ValidateStatusTransition(
            OrderStatus currentStatus,
            OrderStatus newStatus)
        {
            if (!Enum.IsDefined(typeof(OrderStatus), newStatus))
            {
                throw new InvalidOperationException("Invalid order status");
            }

            if (currentStatus == OrderStatus.Delivered ||
                currentStatus == OrderStatus.Cancelled)
            {
                throw new InvalidOperationException("Order cannot be updated after completion (delivered) or cancellation");
            }

            if (currentStatus == OrderStatus.Pending &&
                (newStatus == OrderStatus.Confirmed || newStatus == OrderStatus.Cancelled))
            {
                return;
            }

            if (currentStatus == OrderStatus.Confirmed &&
                newStatus == OrderStatus.Shipped)
            {
                return;
            }

            if (currentStatus == OrderStatus.Shipped &&
                newStatus == OrderStatus.Delivered)
            {
                return;
            }

            throw new InvalidOperationException("Invalid order status transition");
        }
    }
}