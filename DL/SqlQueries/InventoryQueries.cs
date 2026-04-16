namespace DL.SqlQueries
{
    public class InventoryQueries
    {

        public const string GetInventoryById = @"
            SELECT InventoryId, ProductId, Quantity
            FROM Inventory
            WHERE InventoryId = @InventoryId
            AND IsDeleted = 0;";

        public const string GetInventories = @"
            SELECT InventoryId, ProductId, Quantity
            FROM Inventory
            WHERE IsDeleted = 0;";

        public const string CreateInventory = @"
            INSERT INTO Inventory (ProductId, Quantity)
            OUTPUT INSERTED.InventoryId
            VALUES (@ProductId, @Quantity)";

        public const string InventoryExistsByProductId = @"
            SELECT COUNT(1)
            FROM Inventory
            WHERE ProductId = @ProductId
            AND IsDeleted = 0";

        public const string UpdateInventory = @"
            UPDATE Inventory
            SET
                ProductId = @ProductId,
                Quantity = @Quantity,
                ModifiedDate = GETUTCDATE()
            WHERE InventoryId = @InventoryId
            AND IsDeleted = 0";
    }
}
