namespace InventoryManagementSystem.DL.SqlQueries
{
    public class InventoryQueries
    {
        public const string CreateInventory = @"
            INSERT INTO Inventory (ProductId, Quantity)
            OUTPUT INSERTED.InventoryId
            VALUES (@ProductId, @Quantity)";
    }
}
