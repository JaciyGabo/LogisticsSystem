using Logistics.Application.DTOs;
using Logistics.Application.Factories;
using Microsoft.AspNetCore.Mvc;
using Logistics.Infrastructure.Logging;

namespace Logistics.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShipmentsController : ControllerBase
{
    private readonly IShipmentFactory _shipmentFactory;

    public ShipmentsController(IShipmentFactory shipmentFactory)
    {
        _shipmentFactory = shipmentFactory;
    }

    [HttpPost("quote")]
    public IActionResult QuoteShipment([FromBody] QuoteShipmentRequest request)
    {
        try
        {
            var shipmentMethod = _shipmentFactory.CreateShipmentMethod(request.ShipmentType);
            var cost = shipmentMethod.CalculateCost(request.WeightInKg, request.DistanceInKm);

            FileLogger.Instance.Log($"Quote request: {request.ShipmentType}, Cost: {cost}");

            return Ok(new 
            { 
                Type = request.ShipmentType, 
                EstimatedCost = cost,
                Currency = "USD"
            });
        }
        catch (ArgumentException ex)
        {
            FileLogger.Instance.Log($"Error in quote request: {ex.Message}");
            return BadRequest(new { Error = ex.Message });
        }
    }
}