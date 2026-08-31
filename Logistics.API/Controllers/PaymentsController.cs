using Logistics.Application.DTOs;
using Logistics.Infrastructure.Payments;
using Microsoft.AspNetCore.Mvc;

namespace Logistics.API.Controllers;

/// <summary>
/// Controller responsible for processing shipment payments.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentFacade _paymentFacade;

    public PaymentsController(IPaymentFacade paymentFacade)
    {
        _paymentFacade = paymentFacade;
    }

    /// <summary>
    /// Processes a payment through the payment facade, hiding underlying subsystem complexity.
    /// </summary>
    /// <param name="request">The payment processing request payload.</param>
    /// <returns>Returns 200 OK with invoice details or 400 Bad Request if declined.</returns>
    [HttpPost]
    public async Task<IActionResult> ProcessPayment([FromBody] ProcessPaymentRequest request)
    {
        // Delegate the complex payment orchestration to the Facade
        var result = await _paymentFacade.ProcessOrderPaymentAsync(
            request.Amount, 
            request.CardNumber, 
            request.Cvv
        );

        // Handle fraud or gateway rejections
        if (!result.Success)
        {
            return BadRequest(new { Error = result.Message });
        }

        // Return successful transaction details
        return Ok(new 
        { 
            Message = result.Message, 
            Invoice = result.InvoiceNumber 
        });
    }
}