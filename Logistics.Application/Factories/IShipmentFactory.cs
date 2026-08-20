using Logistics.Domain.Services;
using Logistics.Domain.Enums;

namespace Logistics.Application.Factories;

public interface IShipmentFactory
{
    IShipmentMethod CreateShipmentMethod(ShipmentType type);
}