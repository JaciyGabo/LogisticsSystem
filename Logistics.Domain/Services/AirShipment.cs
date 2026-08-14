namespace Logistics.Domain.Services;

public class AirShipment : IShipmentMethod
{
    public decimal CalculateCost(double weightInKg, double distanceInKm)
    {
        // Regla de negocio ficticia: Aéreo cobra muchísimo por peso, incluye tarifa base
        decimal baseTariff = 50.0m;
        return baseTariff + (decimal)(weightInKg * 5.0 + distanceInKm * 0.1);
    }
}