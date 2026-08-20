using Logistics.Domain.Entities;

namespace Logistics.Application.Builders;

public class PackageBuilder : IPackageBuilder
{
    private Package _package = null!;

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

        if (string.IsNullOrWhiteSpace(_package.Description))
            throw new InvalidOperationException("No se puede crear un paquete sin descripción.");

        if (_package.WeightInKg <= 0)
            throw new InvalidOperationException("El peso del paquete debe ser mayor a 0 kg.");

        if (_package.ShipmentId == Guid.Empty)
            throw new InvalidOperationException("El paquete debe estar asignado a un envío válido.");
            
        var builtPackage = _package;
        
        Reset(); 
        
        return builtPackage;
    }
}