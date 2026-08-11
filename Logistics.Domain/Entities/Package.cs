namespace Logistics.Domain.Entities;

public class Package
{
  public Guid Id { get; set; } 
  public string Description { get; set; } = string.Empty;
  public double WeightInKg { get; set; }
  public bool IsFragile { get; set; }   
  public Guid ShipmentId { get; set; }
  public Shipment Shipment { get; set; } 
}