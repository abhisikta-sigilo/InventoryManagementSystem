using BL.Services.Abstractions;
using BL.Services.Implementations;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs.Inventory;
using Shared.DTOs.Product;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType<IEnumerable<ProductResponseDto>>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetProducts() 
        {
            IEnumerable<ProductResponseDto> productResponseDtos = await productService.GetProducts();
            return Ok(productResponseDtos);
        }

        [HttpGet("{productId}")]
        [ProducesResponseType<ProductResponseDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> GetProductById(
            [FromRoute] long productId)
        {
            ProductResponseDto productResponseDto = await productService.GetProductById(productId);
            return Ok(productResponseDto);
        }

        [HttpPost]
        [ProducesResponseType<ProductResponseDto>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> CreateProduct(ProductCreateRequestDto productCreateRequestDto)
        {
            ProductResponseDto productResponseDto =
                await productService.CreateProduct(productCreateRequestDto);

            return Ok(productResponseDto);
        }
    }
}
