namespace DL.SqlQueries
{
    public class ProductQueries
    {
        public const string GetProducts = @"
            SELECT ProductId, ProductName, Description, Price
            FROM Products
            WHERE IsDeleted = 0;";

        public const string GetProductById = @"
            SELECT ProductId, ProductName, Description, Price
            FROM Products
            WHERE ProductId = @ProductId
            AND IsDeleted = 0;";

        public const string CreateProduct = @"
            INSERT INTO Products (ProductName, Description, Price)
            OUTPUT INSERTED.ProductId
            VALUES (@ProductName, @Description, @Price);";
    }
}
