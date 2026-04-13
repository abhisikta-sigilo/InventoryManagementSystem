using InventoryManagementSystem.Shared.DTOs.Inventory;

namespace InventoryManagementSystem.BL.Services.Abstractions
{
    public interface IInventoryService
    {
        Task<InventoryResponseDto> CreateInventory(InventoryCreateRequestDto inventoryCreateRequestDto);
    }
}
