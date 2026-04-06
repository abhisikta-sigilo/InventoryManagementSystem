namespace InventoryManagementSystem.DL.SqlQueries
{
    public class ProductQueries
    {
        public const string GetProducts = @"
            SELECT ProductId, Name, Description, Price
            FROM Products
            WHERE IsDeleted = 0;";
    }
}
