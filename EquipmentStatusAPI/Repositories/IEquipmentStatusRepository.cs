using EquipmentStatusAPI.Entities;

namespace EquipmentStatusAPI.Repositories;

public interface IEquipmentStatusRepository
{
    Task AddAsync(EquipmentStatus status);
    Task<EquipmentStatus?> GetCurrentStatusAsync(string equipmentId);
}