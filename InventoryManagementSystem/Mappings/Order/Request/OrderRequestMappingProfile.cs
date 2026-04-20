using AutoMapper;
using DL.Entities;
using Shared.DTOs.Order;

namespace API.Mappings.Order.Request
{
    public class OrderRequestMappingProfile : Profile
    {
        public OrderRequestMappingProfile()
        {
            CreateMap<OrderCreateRequestDto, OrderEntity>()
                .ForMember(dest => dest.OrderId, opt => opt.Ignore())
                .ForMember(dest => dest.TotalAmount, opt => opt.Ignore())
                .ForMember(dest => dest.OrderStatusId, opt => opt.Ignore())
                .ForMember(dest => dest.OrderDate, opt => opt.Ignore());

            CreateMap<OrderItemCreateRequestDto, OrderItemEntity>()
                .ForMember(dest => dest.OrderItemId, opt => opt.Ignore())
                .ForMember(dest => dest.OrderId, opt => opt.Ignore())
                .ForMember(dest => dest.TotalPrice, opt => opt.Ignore());
        }
    }
}
