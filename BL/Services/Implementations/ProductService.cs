using AutoMapper;
using BL.Services.Abstractions;
using DL.Entities;
using DL.Repositories.Abstractions;
using Shared.DTOs.Product;

namespace BL.Services.Implementations
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

        public async Task<ProductResponseDto> CreateProduct(ProductCreateRequestDto productCreateRequestDto)
        {
            ProductEntity productEntity = mapper.Map<ProductEntity>(productCreateRequestDto);

            long productId = await productRepository.CreateProduct(productEntity);

            productEntity.ProductId = productId;

            return mapper.Map<ProductResponseDto>(productEntity);
        }
    }
}
