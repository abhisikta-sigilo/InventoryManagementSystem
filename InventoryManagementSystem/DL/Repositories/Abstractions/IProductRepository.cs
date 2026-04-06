using InventoryManagementSystem.DL.Entities;

namespace InventoryManagementSystem.DL.Repositories.Abstractions
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetProducts();

        Task<ProductEntity?> GetProductById(long productId);
    }
}
