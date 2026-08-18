namespace Logistics.Infrastructure.Payments;

public class InvoiceService : IInvoiceService
{
    public string GenerateInvoice(decimal amount)
    {
        string datePart = DateTime.UtcNow.ToString("yyyyMMdd");
        string uniquePart = Guid.NewGuid().ToString().Substring(0, 4).ToUpper();
        
        return $"INV-{datePart}-{uniquePart}";
    }
}