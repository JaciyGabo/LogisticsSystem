namespace Logistics.Infrastructure.Payments;

public interface ICardValidator 
{ 
    bool Validate(string cardNumber, string cvv); 
}