using Logistics.Application.DTOs;
using Logistics.Application.Factories;
using Logistics.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Logistics.API.Controllers;

/// <summary>
/// Controller responsible for handling shipment quotes and operations.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ShipmentsController : ControllerBase
{
    private readonly IShipmentFactory _shipmentFactory;
    private readonly ILogger<ShipmentsController> _logger;

    public ShipmentsController(
        IShipmentFactory shipmentFactory, 
        ILogger<ShipmentsController> logger)
    {
        _shipmentFactory = shipmentFactory;
        _logger = logger;
    }

    /// <summary>
    /// Quotes a shipment cost dynamically using the Factory Method pattern.
    /// </summary>
    /// <param name="request">The shipment quote request payload.</param>
    /// <returns>Returns 200 OK with the estimated cost or 400 Bad Request if invalid.</returns>
    [HttpPost("quote")]
    public IActionResult QuoteShipment([FromBody] QuoteShipmentRequest request)
    {
        try
        {
            // Strictly validate the incoming string against our Domain Enum
            if (!Enum.TryParse<ShipmentType>(request.ShipmentType, true, out var shipmentEnum))
            {
                return BadRequest(new { Error = $"El tipo de envío '{request.ShipmentType}' no existe." });
            }

            // Use the Factory Method to instantiate the correct shipment strategy
            var shipmentMethod = _shipmentFactory.CreateShipmentMethod(shipmentEnum);
            var cost = shipmentMethod.CalculateCost(request.WeightInKg, request.DistanceInKm);

            // Log the successful quote 
            _logger.LogInformation("Cotización exitosa: {ShipmentType} | Costo: ${Cost}", shipmentEnum, cost);

            return Ok(new 
            { 
                Type = shipmentEnum.ToString(), 
                EstimatedCost = cost,
                Currency = "USD"
            });
        }
        catch (ArgumentException ex)
        {
            _logger.LogError(ex, "Error en cotización: {Message}", ex.Message);
            return BadRequest(new { Error = ex.Message });
        }
    }
}