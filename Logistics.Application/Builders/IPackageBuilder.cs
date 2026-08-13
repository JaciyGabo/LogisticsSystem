using Logistics.Domain.Entities;

namespace Logistics.Application.Builders;

public interface IPackageBuilder
{
    IPackageBuilder WithDescription(string description);
    IPackageBuilder SetWeight(double weightInKg);
    IPackageBuilder MakeFragile();
    IPackageBuilder AssignToShipment(Guid shipmentId);
    
    Package Build(); 
}