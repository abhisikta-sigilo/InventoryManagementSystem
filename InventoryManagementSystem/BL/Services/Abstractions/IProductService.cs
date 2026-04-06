using InventoryManagementSystem.Shared.DTOs.Product;

namespace InventoryManagementSystem.BL.Services.Abstractions
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDto>> GetProducts();

        Task<ProductResponseDto> GetProductById(long productId);

        Task CreateProduct(CreateProductRequestDto createProductRequestDto);
    }
}
