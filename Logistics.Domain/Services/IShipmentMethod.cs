namespace Logistics.Domain.Services;

public interface IShipmentMethod
{
    decimal CalculateCost(double weightInKg, double distanceInKm);
}