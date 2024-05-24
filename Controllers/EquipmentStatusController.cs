using EquipmentStatusAPI.Data;
using EquipmentStatusAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EquipmentStatusAPI.Controllers;

[ApiController]
[Route("api/[action]")]
public class EquipmentStatusController : ControllerBase
{
    private readonly ApplicationDbContext _dbContext;

    public EquipmentStatusController(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    [HttpPost] // POST : api/status
    public async Task<ActionResult<EquipmentStatus>> Status(EquipmentStatus status)
    {
        status.Id = Guid.NewGuid(); // ensure Id is autogenerated
        status.CreatedDate = DateTime.UtcNow; // ensure it adds correct timestamp
        
        _dbContext.EquipmentStatus.Add(status);
        await _dbContext.SaveChangesAsync();

        return Ok("Success");
    }
    
    [HttpGet]  // GET  : api/status/{equipmentId}
    public async Task<ActionResult<EquipmentStatus>> Status(string equipmentId)
    {
        // using equipmentId in the parameter find the equipment status
        var status = await _dbContext.EquipmentStatus
            .Where(e => e.EquipmentId == equipmentId).OrderByDescending(e => e.CreatedDate)
            .FirstOrDefaultAsync();

        // handle null values
        if (status is null)
            return NotFound("Equipment not found");

        return status;
    }
    
    


}