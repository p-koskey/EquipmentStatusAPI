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
    
    [HttpPost] // POST : api/status
    public async Task<ActionResult<EquipmentStatus>> Status(EquipmentStatusCreateDto statusDto)
    {
        // validate input data
        if (!Enum.IsDefined(typeof(StatusEnum),statusDto.Status) || string.IsNullOrWhiteSpace(statusDto.EquipmentId))
        {
            // return 400 Bad Request if input data is invalid
            return BadRequest("Invalid input data.");
        }

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