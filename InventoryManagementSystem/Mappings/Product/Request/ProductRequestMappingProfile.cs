using AutoMapper;
using DL.Entities;
using Shared.DTOs.Product;

namespace API.Mappings.Product.Request
{
    public class ProductRequestMappingProfile : Profile
    {
        public ProductRequestMappingProfile()
        {
            CreateMap<ProductCreateRequestDto, ProductEntity>();
        }
    }
}
