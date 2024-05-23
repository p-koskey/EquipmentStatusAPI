using System.ComponentModel.DataAnnotations;

namespace EquipmentStatusAPI.Entities;

public class Equipment
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();
    public string EquipmentId { get; set; }
    public int Status { get; set; }
    
}
