using InventoryManagementSystem.BL.Services.Abstractions;
using InventoryManagementSystem.Shared.DTOs.Inventory;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoriesController(IInventoryService inventoryService) : ControllerBase
    {

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<InventoryResponseDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetProducts()
        {
            IEnumerable<InventoryResponseDto> inventoryResponseDtos = 
                await inventoryService.GetInventories();
            return Ok(inventoryResponseDtos);
        }

        [HttpGet("{inventoryId}")]
        [ProducesResponseType(typeof(InventoryResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> GetInventoryById(
            [FromRoute] long inventoryId)
        {
            InventoryResponseDto inventoryResponseDto = await inventoryService.GetInventoryById(inventoryId);
            return Ok(inventoryResponseDto);
        }

        [HttpPost]
        [ProducesResponseType(typeof(InventoryResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> CreateInventory(
            InventoryCreateRequestDto inventoryCreateRequestDto)
        {
            InventoryResponseDto inventoryResponseDto =
                await inventoryService.CreateInventory(inventoryCreateRequestDto);

            return Ok(inventoryResponseDto);
        }
    }
}
