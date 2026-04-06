using AutoMapper;
using InventoryManagementSystem.DL.Entities;
using InventoryManagementSystem.Shared.DTOs;

namespace InventoryManagementSystem.BL.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerResponseDto>();
            CreateMap<CreateCustomerRequestDto, Customer>();
            CreateMap<UpdateCustomerRequestDto, Customer>();
        }
    }
}
