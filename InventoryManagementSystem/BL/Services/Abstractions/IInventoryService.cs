using InventoryManagementSystem.Shared.DTOs.Inventory;

namespace InventoryManagementSystem.BL.Services.Abstractions
{
    public interface IInventoryService
    {
        Task<IEnumerable<InventoryResponseDto>> GetInventories();

        Task<InventoryResponseDto> GetInventoryById(long inventoryId);

        Task<InventoryResponseDto> CreateInventory(InventoryCreateRequestDto inventoryCreateRequestDto);
    }
}
