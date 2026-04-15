using AutoMapper;
using DL.Entities;
using Shared.DTOs.Product;

namespace API.Mappings.Product.Response
{
    public class ProductResponseMappingProfile : Profile
    {
        public ProductResponseMappingProfile()
        {
            CreateMap<ProductEntity, ProductResponseDto>();
        }
    }
}
