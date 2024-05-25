using EquipmentStatusAPI.DTOs;

namespace EquipmentStatusAPI.Services;

public interface IEquipmentStatusService
{
    Task<EquipmentStatusDto> AddStatusAsync(EquipmentStatusCreateDto statusCreateDto);
    Task<EquipmentStatusDto?> GetCurrentStatusAsync(string equipmentIId);
}