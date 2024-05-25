using EquipmentStatusAPI.Data;
using EquipmentStatusAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace EquipmentStatusAPI.Repositories;

public class EquipmentStatusRepository : IEquipmentStatusRepository
{
    private readonly ApplicationDbContext _dbContext;

    public EquipmentStatusRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task AddAsync(EquipmentStatus status)
    {
        // add new status to the dbcontext
        _dbContext.EquipmentStatus.Add(status);
        
        // save the changes
        await _dbContext.SaveChangesAsync();
    }

    public async Task<EquipmentStatus?> GetCurrentStatusAsync(string equipmentId)
    {
        // return the most current equipment status determined by the created date/time
        return await _dbContext.EquipmentStatus
            .Where(e => e.EquipmentId == equipmentId)
            .OrderByDescending(e => e.CreatedDate)
            .FirstOrDefaultAsync();
    }
}