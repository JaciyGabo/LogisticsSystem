using Logistics.Domain.Entities;
using System;

namespace Logistics.Application.Builders;

public interface IPackageBuilder
{
    void Reset();
    IPackageBuilder WithDescription(string description);
    IPackageBuilder SetWeight(double weightInKg);
    IPackageBuilder AssignToShipment(Guid shipmentId);
    IPackageBuilder MakeFragile();
    Package Build(); 
}