using AutoMapper;
using InventoryManagementSystem.BL.Services.Abstractions;
using InventoryManagementSystem.DL.Entities;
using InventoryManagementSystem.DL.Repositories.Abstractions;
using InventoryManagementSystem.Shared.DTOs.Product;

namespace InventoryManagementSystem.BL.Services.Implementations
{
    public class ProductService(
        IProductRepository productRepository,
        IMapper mapper
        ) : IProductService
    {
        public async Task<IEnumerable<ProductResponseDto>> GetProducts()
        {
            IEnumerable<ProductEntity> productEntities = await productRepository.GetProducts();

            return mapper.Map<IEnumerable<ProductResponseDto>>(productEntities);
        }

    }
}
