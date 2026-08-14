using Logistics.Domain.Services;

namespace Logistics.Application.Factories;

public interface IShipmentFactory
{
    IShipmentMethod CreateShipmentMethod(string type);
}