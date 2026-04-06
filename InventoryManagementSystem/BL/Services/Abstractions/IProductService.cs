using InventoryManagementSystem.Shared.DTOs.Product;

namespace InventoryManagementSystem.BL.Services.Abstractions
{
    public interface IProductService
    {
        Task<IEnumerable<ProductResponseDto>> GetProducts();

    }
}
