namespace Logistics.Infrastructure.Payments;

public interface IFraudService 
{ 
    bool IsFraudulent(string cardNumber, decimal amount); 
}