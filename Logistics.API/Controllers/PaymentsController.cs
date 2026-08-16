using Logistics.Application.DTOs;
using Logistics.Infrastructure.Payments;
using Microsoft.AspNetCore.Mvc;

namespace Logistics.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PaymentsController : ControllerBase
{
    private readonly IPaymentFacade _paymentFacade;

    public PaymentsController(IPaymentFacade paymentFacade)
    {
        _paymentFacade = paymentFacade;
    }

    [HttpPost]
    public async Task<IActionResult> ProcessPayment([FromBody] ProcessPaymentRequest request)
    {
        var result = await _paymentFacade.ProcessOrderPaymentAsync(
            request.Amount, 
            request.CardNumber, 
            request.Cvv
        );

        if (!result.Success)
        {
            return BadRequest(new { Error = result.Message });
        }

        return Ok(new 
        { 
            Message = result.Message, 
            Invoice = result.InvoiceNumber 
        });
    }
}