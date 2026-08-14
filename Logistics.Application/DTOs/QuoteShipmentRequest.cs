namespace Logistics.Application.DTOs;

public class QuoteShipmentRequest
{
    public string ShipmentType { get; set; } = string.Empty; 
    public double WeightInKg { get; set; }
    public double DistanceInKm { get; set; }
}