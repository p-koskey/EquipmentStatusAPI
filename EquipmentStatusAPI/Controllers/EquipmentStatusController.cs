using EquipmentStatusAPI.DTOs;
using EquipmentStatusAPI.Entities;
using EquipmentStatusAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EquipmentStatusAPI.Controllers;

[ApiController]
[Route("api/[action]")]
public class EquipmentStatusController : ControllerBase
{
    private readonly IEquipmentStatusService _equipmentStatusService;
    public EquipmentStatusController(IEquipmentStatusService equipmentStatusService)
    {
        _equipmentStatusService = equipmentStatusService;
    }
    
    /// <summary>
    /// Receives and stores status updates for equipment.
    /// </summary>
    /// <param name="statusDto">The equipment Id and equipment status.</param>
    /// <returns>The created status update data.</returns>
    [HttpPost] // POST : api/status
    public async Task<ActionResult<EquipmentStatus>> Status(EquipmentStatusCreateDto statusDto)
    {
        // validate equipment Id
        if (string.IsNullOrWhiteSpace(statusDto.EquipmentId))
            // return 400 Bad Request if input data is invalid
            return BadRequest("Equipment Id should not be null or whitespace");
        
        // validate status
        if (!Enum.IsDefined(typeof(StatusEnum),statusDto.Status) )
            // return 400 Bad Request if input data is invalid
            return BadRequest("Unknown status, status should be between 1 and 5 ");

        try
        {
            var responseDto = await _equipmentStatusService.AddStatusAsync(statusDto);
            return Ok(responseDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
    }
    
    /// <summary>
    /// Retrieves the current status of the specified equipment.
    /// </summary>
    /// <param name="equipmentId">The ID of the equipment.</param>
    /// <returns>The current status of the equipment.</returns>
    [HttpGet("{equipmentId}")]  // GET  : api/status/{equipmentId}
    public async Task<ActionResult<EquipmentStatusDto>> GetStatus(string equipmentId)
    {
        // retrieve current status from database
        var statusDto = await _equipmentStatusService.GetCurrentStatusAsync(equipmentId);

        // handle no equipment status in database
        if (statusDto is null)
        {
            return NotFound("Equipment not found");
        }
        
        return Ok(statusDto);
    }
    
}