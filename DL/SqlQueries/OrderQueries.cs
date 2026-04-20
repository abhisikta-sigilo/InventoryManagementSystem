namespace DL.SqlQueries
{
    internal class OrderQueries
    {
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
