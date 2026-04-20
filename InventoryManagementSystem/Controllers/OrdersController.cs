using BL.Services.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.Order;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(IOrderService orderService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType<OrderResponseDto>(StatusCodes.Status200OK)]

        public async Task<ActionResult> GetOrders(
            [FromQuery] OrderFilterRequestDto filter)
        {
            IEnumerable<OrderResponseDto> responseDtos = await orderService.GetOrders(filter);

            return Ok(responseDtos);
        }

        [HttpGet("{orderId}")]
        [ProducesResponseType<OrderResponseDto>(StatusCodes.Status200OK)]

        public async Task<ActionResult> GetOrderById(
            [FromRoute] long orderId)
        {
            OrderResponseDto responseDto = await orderService.GetOrderById(orderId);

            return Ok(responseDto);
        }

        [HttpPost]
        [ProducesResponseType<OrderResponseDto>(StatusCodes.Status200OK)]

        public async Task<ActionResult> CreateOrder(
            [FromBody] OrderCreateRequestDto orderCreateRequestDto)
        {
            OrderResponseDto orderResponseDto = await orderService.CreateOrder(orderCreateRequestDto);

            return Ok(orderResponseDto);
        }
    }
}
