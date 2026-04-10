using AutoMapper;
using InventoryManagementSystem.DL.Entities;
using InventoryManagementSystem.Shared.DTOs.Product;

namespace InventoryManagementSystem.BL.Mappings.Product.Response
{
    public class ProductResponseMappingProfile : Profile
    {
        public ProductResponseMappingProfile()
        {
            CreateMap<ProductEntity, ProductResponseDto>();
        }
    }
}
