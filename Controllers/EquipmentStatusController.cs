using EquipmentStatusAPI.Data;
using EquipmentStatusAPI.Entities;
using Microsoft.AspNetCore.Mvc;

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
        _dbContext.EquipmentStatus.Add(status);
        await _dbContext.SaveChangesAsync();

        return Ok("Success");
    }


}