using Logistics.Application.Builders;
using Logistics.Application.DTOs;
using Logistics.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Logistics.API.Controllers;

/// <summary>
/// Controller responsible for managing package-related operations.
/// </summary>

[ApiController]
[Route("api/[controller]")]
public class PackagesController : ControllerBase
{
    private readonly IPackageRepository _repository;

    public PackagesController(IPackageRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    /// Creates a new package using the Builder pattern and saves it to the database.
    /// </summary>
    /// <param name="request">The package creation request payload.</param>
    /// <returns>Returns 201 Created if successful, or 400 Bad Request if domain validation fails.</returns>
    [HttpPost]
    public async Task<IActionResult> CreatePackage([FromBody] CreatePackageRequest request)
    {
        // Instantiate the builder to construct the package step-by-step
        var builder = new PackageBuilder()
            .WithDescription(request.Description)
            .SetWeight(request.WeightInKg)
            .AssignToShipment(request.ShipmentId);

        // Conditionally apply business rules based on request data
        if (request.IsFragile)
        {
            builder.MakeFragile();
        }

        try
        {
            // Build the package (this enforces domain invariants)
            var packageToSave = builder.Build();

            // Persist the entity using the repository pattern
            await _repository.AddAsync(packageToSave);
            await _repository.SaveChangesAsync();

            return Created("", packageToSave); 
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest( new { Error = ex.Message });
        }
    }
}