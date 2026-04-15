using Dapper;
using DL.Entities;
using DL.Repositories.Abstractions;
using DL.Services;
using DL.SqlQueries;
using Microsoft.Extensions.Configuration;

namespace DL.Repositories.Implementations
{
    public class ProductRepository(IConfiguration configuration
        ) : DbConnectionManager(configuration), IProductRepository
    {
        public async Task<IEnumerable<ProductEntity>> GetProducts()
        {
            return await DbOperation(connection =>
                connection.QueryAsync<ProductEntity>(ProductQueries.GetProducts));
        }

        public async Task<ProductEntity?> GetProductById(long productId)
        {
            return await DbOperation(connection =>
                connection.QueryFirstOrDefaultAsync<ProductEntity>(
                    ProductQueries.GetProductById,
                    new { ProductId = productId }));
        }

        public async Task<long> CreateProduct(ProductEntity productEntity)
        {
            return await DbOperation(connection =>
                connection.ExecuteScalarAsync<long>(
                ProductQueries.CreateProduct,
                productEntity));
        }
    }
}
