namespace DL.SqlQueries
{
    internal class OrderQueries
    {
        public const string GetOrders = @"
            SELECT
                o.OrderId,
                o.CustomerId,
                o.TotalAmount,
                o.OrderStatusId,
                o.OrderDate,

                oi.OrderItemId,
                oi.ProductId,
                oi.Quantity,
                oi.TotalPrice

            FROM Orders o
            LEFT JOIN OrderItems oi
                ON oi.OrderId = o.OrderId
            WHERE o.IsDeleted = 0";

        public const string GetOrderById = @"
            SELECT
                o.OrderId,
                o.CustomerId,
                o.TotalAmount,
                o.OrderStatusId,
                o.OrderDate,

                oi.OrderItemId,
                oi.ProductId,
                oi.Quantity,
                oi.TotalPrice

            FROM Orders o
            LEFT JOIN OrderItems oi
                ON oi.OrderId = o.OrderId
            WHERE o.OrderId = @OrderId
            AND o.IsDeleted = 0";

        public const string CreateOrder = @"
            INSERT INTO Orders (CustomerId, TotalAmount, OrderStatusId, OrderDate)
            OUTPUT INSERTED.OrderId
            VALUES
            (@CustomerId, @TotalAmount, @OrderStatusId, @OrderDate)";

        public const string CreateOrderItem = @"
            INSERT INTO OrderItems (OrderId, ProductId, Quantity, TotalPrice)
            VALUES
            (@OrderId, @ProductId, @Quantity, @TotalPrice)";
    }
}
