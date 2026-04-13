namespace InventoryManagementSystem.DL.SqlQueries
{
    public class InventoryQueries
    {
        public const string CreateInventory = @"
            INSERT INTO Inventory (ProductId, Quantity)
            OUTPUT INSERTED.InventoryId
            VALUES (@ProductId, @Quantity)";

        public const string InventoryExistsByProductId = @"
            SELECT COUNT(1)
            FROM Inventory
            WHERE ProductId = @ProductId
            AND IsDeleted = 0";
    }
}
