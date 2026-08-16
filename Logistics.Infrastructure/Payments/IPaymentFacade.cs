namespace Logistics.Infrastructure.Payments;

public interface IPaymentFacade
{
    Task<(bool Success, string Message, string InvoiceNumber)> ProcessOrderPaymentAsync(decimal amount, string cardNumber, string cvv);
}