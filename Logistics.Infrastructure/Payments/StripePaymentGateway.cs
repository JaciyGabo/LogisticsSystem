namespace Logistics.Infrastructure.Payments;

public class StripePaymentGateway : IStripePaymentGateway
{
    public async Task<bool> ChargeAsync(decimal amount, string cardNumber)
    {
        await Task.Delay(1500);

        if (cardNumber.EndsWith("0000")) 
        {
            return false;
        }

        return true; 
    }
}