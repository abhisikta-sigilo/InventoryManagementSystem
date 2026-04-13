using InventoryManagementSystem.BL.Services.Abstractions;
using InventoryManagementSystem.Shared.DTOs.Inventory;
using Microsoft.AspNetCore.Mvc;

namespace InventoryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoriesController(IInventoryService inventoryService) : ControllerBase
    {
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
