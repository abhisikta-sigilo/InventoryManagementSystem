using Dapper;
using InventoryManagementSystem.DL.DbContext;
using InventoryManagementSystem.DL.Entities;
using InventoryManagementSystem.DL.Repositories.Abstractions;
using InventoryManagementSystem.DL.SqlQueries;
using System.Data;

namespace InventoryManagementSystem.DL.Repositories.Implementations
{
    public class ProductRepository(DapperContext context) : IProductRepository
    {
        public async Task<IEnumerable<ProductEntity>> GetProducts()
        {
            using IDbConnection connection = context.CreateConnection();

            // Dapper method that executes a SQL query and maps the result to C# objects
            IEnumerable<ProductEntity> products = 
                await connection.QueryAsync<ProductEntity>(ProductQueries.GetProducts);

            return products;
        }

        public async Task<ProductEntity?> GetProductById(long productId)
        {
            using IDbConnection connection = context.CreateConnection();

            ProductEntity? productEntity = 
                await connection.QueryFirstOrDefaultAsync<ProductEntity>(
                    ProductQueries.GetProductById,
                    new { ProductId = productId});

            return productEntity;
        }
    }
}
