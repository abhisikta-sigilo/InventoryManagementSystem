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

        public async Task<ProductResponseDto> GetProductById(long productId)
        {
            ProductEntity? productEntity = await productRepository.GetProductById(productId);

            if (productEntity == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            return mapper.Map<ProductResponseDto>(productEntity);
        }

        public async Task CreateProduct(CreateProductRequestDto createProductRequestDto)
        {
            ProductEntity productEntity = mapper.Map<ProductEntity>(createProductRequestDto);

            await productRepository.CreateProduct(productEntity);
        }
    }
}
