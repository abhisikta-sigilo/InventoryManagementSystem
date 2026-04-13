using Dapper;
using InventoryManagementSystem.DL.DbContext;
using InventoryManagementSystem.DL.Entities;
using InventoryManagementSystem.DL.Repositories.Abstractions;
using InventoryManagementSystem.DL.SqlQueries;
using System.Data;

namespace InventoryManagementSystem.DL.Repositories.Implementations
{
    public class InventoryRepository(DapperContext context) : IInventoryRepository
    {
        public async Task<long> CreateInventory(InventoryEntity inventoryEntity)
        {
            using IDbConnection connection = context.CreateConnection();

            long productId = await connection.ExecuteScalarAsync<long>(
                InventoryQueries.CreateInventory,
                inventoryEntity);

            return productId;
        }
    }
}
