using Logistics.Domain.Services;

namespace Logistics.Application.Factories;

public class ShipmentFactory : IShipmentFactory
{
    public IShipmentMethod CreateShipmentMethod(string type)
    {
        return type.ToLower() switch
        {
            "terrestre" => new GroundShipment(),
            "aereo" => new AirShipment(),
            _ => throw new ArgumentException($"El tipo de envío '{type}' no es válido.") 
        };
    }
}