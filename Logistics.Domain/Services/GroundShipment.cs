namespace Logistics.Domain.Services;

public class GroundShipment : IShipmentMethod
{
    public decimal CalculateCost(double weightInKg, double distanceInKm)
    {
        // Regla de negocio ficticia: Terrestre cobra mucho por distancia, poco por peso
        return (decimal)(weightInKg * 1.5 + distanceInKm * 0.5);
    }
}
