using AutoMapper;
using DL.Entities;
using Shared.DTOs.Inventory;

namespace API.Mappings.Inventory.Response
{
    public class InventoryResponseMappingProfile : Profile
    {
        public InventoryResponseMappingProfile()
        {
            CreateMap<InventoryEntity, InventoryResponseDto>();
        }
    }
}
