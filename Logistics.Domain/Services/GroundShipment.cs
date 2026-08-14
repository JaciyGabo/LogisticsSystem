namespace Logistics.Domain.Services;

public class GroundShipment : IShipmentMethod
{
    public decimal CalculateCost(double weightInKg, double distanceInKm)
    {
        // Regla de negocio ficticia: Terrestre cobra mucho por distancia, poco por peso
        return (decimal)(weightInKg * 0.5 + distanceInKm * 1.5);
    }
}
