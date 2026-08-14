using Logistics.Application.DTOs;
using Logistics.Application.Factories;
using Microsoft.AspNetCore.Mvc;

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

            return Ok(new 
            { 
                Type = request.ShipmentType, 
                EstimatedCost = cost,
                Currency = "USD"
            });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }
}