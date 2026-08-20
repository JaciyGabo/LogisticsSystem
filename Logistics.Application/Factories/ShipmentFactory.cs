using Logistics.Domain.Services;
using Logistics.Domain.Enums;
using System;

namespace Logistics.Application.Factories;

public class ShipmentFactory : IShipmentFactory
{
    public IShipmentMethod CreateShipmentMethod(ShipmentType type)
    {
        return type switch
        {
            ShipmentType.Ground => new GroundShipment(),
            ShipmentType.Air => new AirShipment(),
            _ => throw new ArgumentException($"El tipo de envío '{type}' no es válido.") 
        };
    }
}