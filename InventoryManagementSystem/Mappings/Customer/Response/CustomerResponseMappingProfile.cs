using AutoMapper;
using DL.Entities;
using Shared.DTOs.Customer;

namespace API.Mappings.Customer.Response
{
    public class CustomerResponseMappingProfile : Profile
    {
        public CustomerResponseMappingProfile()
        {
            CreateMap<CustomerEntity, CustomerResponseDto>();
        }
    }
}
