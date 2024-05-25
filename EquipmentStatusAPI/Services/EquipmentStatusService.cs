using EquipmentStatusAPI.DTOs;
using EquipmentStatusAPI.Entities;
using EquipmentStatusAPI.Repositories;
namespace EquipmentStatusAPI.Services;

public class EquipmentStatusService : IEquipmentStatusService
{
    private readonly IEquipmentStatusRepository _repository;

    public EquipmentStatusService(IEquipmentStatusRepository repository)
    {
        _repository = repository;
    }
    public async Task<EquipmentStatusDto> AddStatusAsync(EquipmentStatusCreateDto statusCreateDto)
    {
        // convert DTO TO an entity object
        var status = new EquipmentStatus
        {
            EquipmentId = statusCreateDto.EquipmentId,
            Status = (StatusEnum)statusCreateDto.Status
        };
        
        // add new status to the repository
        await _repository.AddAsync(status);
        
        // return  a DTO containing status description of the new status
        return new EquipmentStatusDto
        {
            EquipmentId = status.EquipmentId,
            Status = (int)status.Status,
            StatusDescription = status.Status.ToString()
        };
        
    }

    public async Task<EquipmentStatusDto?> GetCurrentStatusAsync(string equipmentId)
    {
        var status = await _repository.GetCurrentStatusAsync(equipmentId);

        if (status is null)
        {
            // return null if status is not found
            return null;
        }

        // return a DTO with the description of the current status
        return new EquipmentStatusDto
        {
            EquipmentId = status.EquipmentId,
            Status = (int)status.Status,
            StatusDescription = status.Status.ToString()
        };

    }
}