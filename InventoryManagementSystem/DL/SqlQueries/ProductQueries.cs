namespace InventoryManagementSystem.DL.SqlQueries
{
    public class ProductQueries
    {
        public const string GetProducts = @"
            SELECT ProductId, Name, Description, Price
            FROM Products
            WHERE IsDeleted = 0;";

        public const string GetProductById = @"
            SELECT ProductId, Name, Description, Price
            FROM Products
            WHERE ProductId = @ProductId
            AND IsDeleted = 0;";

        public const string CreateProduct = @"
            INSERT INTO Products (Name, Description, Price)
            OUTPUT INSERTED.ProductId
            VALUES (@Name, @Description, @Price);";
    }
}
