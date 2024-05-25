using System.ComponentModel.DataAnnotations;

namespace EquipmentStatusAPI.DTOs;

public class EquipmentStatusCreateDto
{
    [Required]
    // equipment identifier
    public string EquipmentId { get; init; }
    
    [Required]
    // numeric value of current equipment status
    public int Status{ get; init; }
}