using AutoMapper;
using InventoryManagementSystem.DL.Entities;
using InventoryManagementSystem.Shared.DTOs.Product;

namespace InventoryManagementSystem.BL.Mappings.Product.Request
{
    public class ProductRequestMappingProfile : Profile
    {
        public ProductRequestMappingProfile()
        {
            CreateMap<ProductCreateRequestDto, ProductEntity>();
        }
    }
}
