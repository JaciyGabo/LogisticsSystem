namespace Logistics.Infrastructure.Payments;

public interface IInvoiceService 
{ 
    string GenerateInvoice(decimal amount); 
}