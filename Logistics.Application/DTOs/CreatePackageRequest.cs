namespace Logistics.Application.DTOs;

public class CreatePackageRequest
{
    public string Description { get; set; } = string.Empty;
    public double WeightInKg { get; set; }
    public bool IsFragile { get; set; }
    public Guid ShipmentId { get; set; }
}