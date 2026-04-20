using DL.Entities;

namespace DL.Repositories.Abstractions
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<InventoryEntity>> GetInventories();

        Task<InventoryEntity?> GetInventoryById(long inventoryId);

        Task<long> CreateInventory(InventoryEntity inventoryEntity);

        Task<bool> InventoryExistsByProductId(long productId);

        Task<InventoryEntity?> GetInventoryByProductId(long productId);

        Task UpdateInventory(InventoryEntity inventoryEntity);
    }
}
