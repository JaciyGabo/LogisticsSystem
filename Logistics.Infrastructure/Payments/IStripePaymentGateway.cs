namespace Logistics.Infrastructure.Payments;

public interface IStripePaymentGateway 
{ 
    Task<bool> ChargeAsync(decimal amount, string cardNumber); 
}IInvoiceService