using AutoMapper;
using InventoryManagementSystem.DL.Entities;
using InventoryManagementSystem.Shared.DTOs.Inventory;

namespace InventoryManagementSystem.BL.Mappings.Inventory.Response
{
    public class InventoryResponseMappingProfile : Profile
    {
        public InventoryResponseMappingProfile()
        {
            CreateMap<InventoryEntity, InventoryResponseDto>();
        }
    }
}
