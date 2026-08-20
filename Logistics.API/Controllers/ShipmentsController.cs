using Logistics.Application.DTOs;
using Logistics.Application.Factories;
using Logistics.Domain.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Logistics.API.Controllers;

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

    [HttpPost("quote")]
    public IActionResult QuoteShipment([FromBody] QuoteShipmentRequest request)
    {
        try
        {
            if (!Enum.TryParse<ShipmentType>(request.ShipmentType, true, out var shipmentEnum))
            {
                return BadRequest(new { Error = $"El tipo de envío '{request.ShipmentType}' no existe." });
            }

            var shipmentMethod = _shipmentFactory.CreateShipmentMethod(shipmentEnum);
            var cost = shipmentMethod.CalculateCost(request.WeightInKg, request.DistanceInKm);

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