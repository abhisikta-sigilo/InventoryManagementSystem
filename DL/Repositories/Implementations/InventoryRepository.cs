using Dapper;
using DL.Entities;
using DL.Repositories.Abstractions;
using DL.Services;
using DL.SqlQueries;
using Microsoft.Extensions.Configuration;

namespace DL.Repositories.Implementations
{
    public class InventoryRepository(IConfiguration configuration
        ) : DbConnectionManager(configuration), IInventoryRepository
    {

        public async Task<IEnumerable<InventoryEntity>> GetInventories()
        {
            return await DbOperation(connection =>
                connection.QueryAsync<InventoryEntity>(InventoryQueries.GetInventories));
        }

        public async Task<InventoryEntity?> GetInventoryById(long inventoryId)
        {
            return await DbOperation(connection =>
                connection.QueryFirstOrDefaultAsync<InventoryEntity>(
                    InventoryQueries.GetInventoryById,
                    new { InventoryId = inventoryId }));
        }

        public async Task<long> CreateInventory(InventoryEntity inventoryEntity)
        {
            return await DbOperation(connection =>
                connection.ExecuteScalarAsync<long>(
                    InventoryQueries.CreateInventory,
                    inventoryEntity));
        }

        public async Task<bool> InventoryExistsByProductId(long productId)
        {
            return await DbOperation(async connection =>
            {
                int count = await connection.ExecuteScalarAsync<int>(
                    InventoryQueries.InventoryExistsByProductId,
                    new { ProductId = productId });

                return count > 0;
            });
        }

        public async Task<InventoryEntity?> GetInventoryByProductId(long productId)
        {
            return await DbOperation(connection =>
                connection.QueryFirstOrDefaultAsync<InventoryEntity>(
                    InventoryQueries.GetInventoryByProductId,
                    new { ProductId = productId }));
        }

        public async Task UpdateInventory(InventoryEntity inventoryEntity)
        {
            await DbOperation(async connection =>
            {
                await connection.ExecuteAsync(
                    InventoryQueries.UpdateInventory,
                    inventoryEntity);

                return true;
            });
        }
    }
}
