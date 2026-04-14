using Dapper;
using InventoryManagementSystem.DL.Entities;
using InventoryManagementSystem.DL.Repositories.Abstractions;
using InventoryManagementSystem.DL.Services;
using InventoryManagementSystem.DL.SqlQueries;

namespace InventoryManagementSystem.DL.Repositories.Implementations
{
    public class ProductRepository(IConfiguration configuration
        ) : DbConnectionManager(configuration), IProductRepository
    {
        public async Task<IEnumerable<ProductEntity>> GetProducts()
        {
            return await ExecuteDatabaseOperation(connection =>
                connection.QueryAsync<ProductEntity>(ProductQueries.GetProducts));
        }

        public async Task<ProductEntity?> GetProductById(long productId)
        {
            return await ExecuteDatabaseOperation(connection =>
                connection.QueryFirstOrDefaultAsync<ProductEntity>(
                    ProductQueries.GetProductById,
                    new { ProductId = productId }));
        }

        public async Task<long> CreateProduct(ProductEntity productEntity)
        {
            return await ExecuteDatabaseOperation(connection =>
                connection.ExecuteScalarAsync<long>(
                ProductQueries.CreateProduct,
                productEntity));
        }
    }
}
