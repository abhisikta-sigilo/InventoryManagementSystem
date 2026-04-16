using AutoMapper;
using DL.Entities;
using Shared.DTOs.Inventory;

namespace API.Mappings.Inventory.Request
{
    public class InventoryRequestMappingProfile : Profile
    {
        public InventoryRequestMappingProfile()
        {
            CreateMap<InventoryCreateRequestDto, InventoryEntity>();
        }
    }
}
