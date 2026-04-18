using AutoMapper;
using DL.Entities;
using Shared.DTOs.Order;

namespace API.Mappings.Order.Response
{
    public class OrderResponseMappingProfile : Profile
    {
        public OrderResponseMappingProfile()
        {
            CreateMap<OrderEntity, OrderResponseDto>();

            CreateMap<OrderItemEntity, OrderItemResponseDto>();
        }
    }
}
