namespace Logistics.Infrastructure.Payments;

public class FraudService
{
    private readonly List<string> _blacklistedCards = new() 
    { 
        "4111111111111111", 
        "5555555555554444" 
    };

    public bool IsFraudulent(string cardNumber, decimal amount)
    {
        if (_blacklistedCards.Contains(cardNumber))
        {
            return true;
        }

        if (amount > 10000m)
        {
            return true;
        }

        return false;
    }
}