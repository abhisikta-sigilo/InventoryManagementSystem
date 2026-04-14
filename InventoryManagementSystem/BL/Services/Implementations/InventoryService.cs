using AutoMapper;
using InventoryManagementSystem.BL.Services.Abstractions;
using InventoryManagementSystem.DL.Entities;
using InventoryManagementSystem.DL.Repositories.Abstractions;
using InventoryManagementSystem.DL.Repositories.Implementations;
using InventoryManagementSystem.Shared.DTOs.Inventory;
using InventoryManagementSystem.Shared.DTOs.Product;

namespace InventoryManagementSystem.BL.Services.Implementations
{
    public class InventoryService(
        IInventoryRepository inventoryRepository,
        IProductRepository productRepository,
        IMapper mapper
    ) : IInventoryService
    {
        public async Task<IEnumerable<InventoryResponseDto>> GetInventories()
        {
            IEnumerable<InventoryEntity> inventoryEntities = await inventoryRepository.GetInventories();

            return mapper.Map<IEnumerable<InventoryResponseDto>>(inventoryEntities);
        }

        public async Task<InventoryResponseDto> GetInventoryById(long inventoryId)
        {
            InventoryEntity? inventoryEntity = await inventoryRepository.GetInventoryById(inventoryId);

            if (inventoryEntity == null)
            {
                throw new KeyNotFoundException("Inventory not found");
            }

            return mapper.Map<InventoryResponseDto>(inventoryEntity);
        }

        public async Task<InventoryResponseDto> CreateInventory(InventoryCreateRequestDto inventoryCreateRequestDto)
        {

            await ValidateInventory(
                inventoryCreateRequestDto.ProductId,
                inventoryCreateRequestDto.Quantity);

            InventoryEntity inventoryEntity = mapper.Map<InventoryEntity>( inventoryCreateRequestDto );

            long inventoryId = await inventoryRepository.CreateInventory(inventoryEntity);

            inventoryEntity.InventoryId = inventoryId;

            InventoryResponseDto inventoryResponseDto = mapper.Map<InventoryResponseDto>( inventoryEntity );

            return inventoryResponseDto;
        }

        public async Task ValidateInventory(long productId, int quantity)
        {
            ProductEntity? productEntity = await productRepository.GetProductById(productId);

            if (productEntity == null)
                throw new Exception("Product does not exist");

            if (quantity < 0)
                throw new Exception("Quantity cannot be negative");

            bool inventoryExists = await inventoryRepository.InventoryExistsByProductId(productId);

            if (inventoryExists)
                throw new Exception("Inventory already exists for this product");
        }
    }
}
