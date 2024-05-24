using System.ComponentModel.DataAnnotations;

namespace EquipmentStatusAPI.Entities;

public class EquipmentStatus
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string EquipmentId { get; set; }
    public StatusEnum Status { get; set; }
    
}
