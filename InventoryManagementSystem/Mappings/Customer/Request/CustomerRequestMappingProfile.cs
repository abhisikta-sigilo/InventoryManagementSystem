using AutoMapper;
using DL.Entities;
using Shared.DTOs.Customer;

namespace API.Mappings.Customer.Request
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
