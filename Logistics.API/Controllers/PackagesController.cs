using Logistics.Application.Builders;
using Logistics.Application.DTOs;
using Logistics.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Logistics.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PackagesController : ControllerBase
{
    private readonly IPackageRepository _repository;

    public PackagesController(IPackageRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> CreatePackage([FromBody] CreatePackageRequest request)
    {
        var builder = new PackageBuilder();

        var newPackage = builder
            .WithDescription(request.Description)
            .SetWeight(request.WeightInKg)
            .AssignToShipment(request.ShipmentId);

        if (request.IsFragile)
        {
            builder.MakeFragile();
        }

        var packageToSave = builder.Build();

        await _repository.AddAsync(packageToSave);
        await _repository.SaveChangesAsync();

        return Created("", packageToSave); 
    }
}