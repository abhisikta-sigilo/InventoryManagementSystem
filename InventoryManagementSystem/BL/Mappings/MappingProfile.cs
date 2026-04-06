using AutoMapper;
using InventoryManagementSystem.DL.Entities;
using InventoryManagementSystem.Shared.DTOs;

namespace InventoryManagementSystem.BL.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CustomerEntity, CustomerResponseDto>();
            CreateMap<CreateCustomerRequestDto, CustomerEntity>();
            CreateMap<UpdateCustomerRequestDto, CustomerEntity>();
        }
    }
}
