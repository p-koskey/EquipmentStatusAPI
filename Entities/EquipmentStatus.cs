using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EquipmentStatusAPI.Entities;

public class EquipmentStatus
{
    [Key]
    public Guid Id { get; init; } = Guid.NewGuid(); //autogenerate unique identifier
    
    public string EquipmentId { get; init; }
    
    public StatusEnum Status { get; init; }
    
    public DateTime CreatedDate { get; init; } = DateTime.UtcNow; // add created date of the status
    
}
