namespace Logistics.Infrastructure.Payments;

public class CardValidator
{
    public bool Validate(string cardNumber, string cvv)
    {
        bool isCardValid = !string.IsNullOrWhiteSpace(cardNumber) && cardNumber.Length == 16 && cardNumber.All(char.IsDigit);
        bool isCvvValid = !string.IsNullOrWhiteSpace(cvv) && cvv.Length == 3 && cvv.All(char.IsDigit);

        return isCardValid && isCvvValid;
    }
}