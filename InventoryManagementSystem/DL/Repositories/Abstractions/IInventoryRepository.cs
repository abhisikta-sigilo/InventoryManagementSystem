using InventoryManagementSystem.DL.Entities;

namespace InventoryManagementSystem.DL.Repositories.Abstractions
{
    public interface IInventoryRepository
    {
        Task<long> CreateInventory(InventoryEntity inventoryEntity);

        Task<bool> InventoryExistsByProductId(long productId);
    }
}
