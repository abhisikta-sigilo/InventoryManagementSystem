using AutoMapper;
using InventoryManagementSystem.BL.Services.Abstractions;
using InventoryManagementSystem.DL.Entities;
using InventoryManagementSystem.DL.Repositories.Abstractions;
using InventoryManagementSystem.Shared.DTOs.Inventory;

namespace InventoryManagementSystem.BL.Services.Implementations
{
    public class InventoryService(
        IInventoryRepository inventoryRepository,
        IMapper mapper
    ) : IInventoryService
    {
        public async Task<InventoryResponseDto> CreateInventory(InventoryCreateRequestDto inventoryCreateRequestDto)
        {
            InventoryEntity inventoryEntity = mapper.Map<InventoryEntity>( inventoryCreateRequestDto );

            long inventoryId = await inventoryRepository.CreateInventory(inventoryEntity);

            inventoryEntity.InventoryId = inventoryId;

            InventoryResponseDto inventoryResponseDto = mapper.Map<InventoryResponseDto>( inventoryEntity );

            return inventoryResponseDto;
        }
    }
}
