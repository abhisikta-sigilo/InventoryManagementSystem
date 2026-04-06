using InventoryManagementSystem.BL.Services.Abstractions;
using InventoryManagementSystem.Shared.DTOs.Product;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetProducts() 
        {
            IEnumerable<ProductResponseDto> productResponseDtos = await productService.GetProducts();
            return Ok(productResponseDtos);
        }
    }
}
