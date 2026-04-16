using Shared.DTOs.Product;

namespace BL.Services.Abstractions
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDto>> GetProducts();

        Task<ProductResponseDto> GetProductById(long productId);

        Task<ProductResponseDto> CreateProduct(ProductCreateRequestDto productCreateRequestDto);
    }
}
