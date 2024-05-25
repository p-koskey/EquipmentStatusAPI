using System.Text.Json.Serialization;

namespace EquipmentStatusAPI.DTOs;

public class EquipmentStatusDto
{
    // equipment identifier
    public string EquipmentId { get; init; }
    
    // numeric value of current equipment status
    public int Status{ get; init; }
    
    // description of current equipment status
    public string StatusDescription{ get; init; }
    
}