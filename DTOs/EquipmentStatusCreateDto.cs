namespace EquipmentStatusAPI.DTOs;

public class EquipmentStatusCreateDto
{
    // equipment identifier
    public string EquipmentId { get; init; }
    
    // numeric value of current equipment status
    public int Status{ get; init; }
}