using AutoMapper;
using InventoryManagementSystem.DL.Entities;
using InventoryManagementSystem.Shared.DTOs;

namespace InventoryManagementSystem.BL.Mappings.Customer.Response
{
    public class CustomerResponseMappingProfile : Profile
    {
        public CustomerResponseMappingProfile()
        {
            CreateMap<CustomerEntity, CustomerResponseDto>();
        }
    }
}
