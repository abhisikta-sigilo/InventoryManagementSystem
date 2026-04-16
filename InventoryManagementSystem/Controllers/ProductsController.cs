using BL.Services.Abstractions;
using Shared.DTOs.Product;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ProductResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<IEnumerable<ProductResponseDto>>> GetProducts() 
        {
            IEnumerable<ProductResponseDto> productResponseDtos = await productService.GetProducts();
            return Ok(productResponseDtos);
        }

        [HttpGet("{productId}")]
        [ProducesResponseType(typeof(ProductResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult> GetProductById(
            [FromRoute] long productId)
        {
            ProductResponseDto productResponseDto = await productService.GetProductById(productId);
            return Ok(productResponseDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult> CreateProduct(ProductCreateRequestDto productCreateRequestDto)
        {
            await productService.CreateProduct(productCreateRequestDto);

            return Ok();
        }
    }
}
