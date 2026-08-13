using Logistics.Domain.Entities;

namespace Logistics.Application.Builders;

public class PackageBuilder : IPackageBuilder
{
    private Package _package;

    public PackageBuilder()
    {
        Reset();
    }

    public void Reset()
    {
        _package = new Package
        {
            Id = Guid.NewGuid() 
        };
    }

    public IPackageBuilder WithDescription(string description)
    {
        _package.Description = description;
        return this;
    }

    public IPackageBuilder SetWeight(double weightInKg)
    {
        _package.WeightInKg = weightInKg;
        return this;
    }

    public IPackageBuilder MakeFragile()
    {
        _package.IsFragile = true;
        return this;
    }

    public IPackageBuilder AssignToShipment(Guid shipmentId)
    {
        _package.ShipmentId = shipmentId;
        return this;
    }

    public Package Build()
    {
        var result = _package;
        
        Reset(); 
        
        return result;
    }
}