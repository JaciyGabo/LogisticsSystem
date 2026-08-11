namespace Logistics.Domain.Entities;

public class Shipment
{
  public Guid Id { get; set; }
  public string TrackingNumber { get; set; } = string.Empty;
  public string OriginAddress { get; set; } = string.Empty;
  public string DestinationAddress { get; set; } = string.Empty;
  public DateTime CreatedAt { get; set; }
  public List<Package> Packages { get; set; } = new List<Package>();
}