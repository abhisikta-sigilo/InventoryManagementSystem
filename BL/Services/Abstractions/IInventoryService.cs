using Shared.DTOs.Inventory;

namespace BL.Services.Abstractions
{
    public interface IInventoryService
    {
        Task<IEnumerable<InventoryResponseDto>> GetInventories();

        Task<InventoryResponseDto> GetInventoryById(long inventoryId);

        Task<InventoryResponseDto> CreateInventory(InventoryCreateRequestDto inventoryCreateRequestDto);

        Task<InventoryResponseDto> UpdateInventory(long inventoryId, InventoryUpdateRequestDto inventoryUpdateRequestDto);
    }
}
