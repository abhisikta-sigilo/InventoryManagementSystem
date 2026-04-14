using AutoMapper;
using InventoryManagementSystem.DL.Entities;
using InventoryManagementSystem.Shared.DTOs.Inventory;

namespace InventoryManagementSystem.BL.Mappings.Inventory.Request
{
    public class InventoryRequestMappingProfile : Profile
    {
        public InventoryRequestMappingProfile()
        {
            CreateMap<InventoryCreateRequestDto, InventoryEntity>();
        }
    }
}
