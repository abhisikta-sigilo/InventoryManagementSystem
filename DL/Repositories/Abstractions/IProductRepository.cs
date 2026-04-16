using DL.Entities;

namespace DL.Repositories.Abstractions
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductEntity>> GetProducts();

        Task<ProductEntity?> GetProductById(long productId);

        Task<long> CreateProduct(ProductEntity product);
    }
}
