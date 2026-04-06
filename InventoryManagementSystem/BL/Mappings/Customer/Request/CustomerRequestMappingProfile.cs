using AutoMapper;
using InventoryManagementSystem.DL.Entities;
using InventoryManagementSystem.Shared.DTOs;

namespace InventoryManagementSystem.BL.Mappings.Customer.Request
{
    public class CustomerRequestMappingProfile : Profile
    {
        public CustomerRequestMappingProfile()
        {
            CreateMap<CreateCustomerRequestDto, CustomerEntity>();
            CreateMap<UpdateCustomerRequestDto, CustomerEntity>();
        }
    }
}
