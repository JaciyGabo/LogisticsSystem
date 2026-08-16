namespace Logistics.Application.DTOs;

public class ProcessPaymentRequest
{
    public decimal Amount { get; set; }
    public string CardNumber { get; set; } = string.Empty;
    public string Cvv { get; set; } = string.Empty;
}