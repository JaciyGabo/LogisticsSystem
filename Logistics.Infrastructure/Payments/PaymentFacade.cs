namespace Logistics.Infrastructure.Payments;

public class PaymentFacade : IPaymentFacade
{
    private readonly CardValidator _cardValidator;
    private readonly FraudService _fraudService;
    private readonly StripePaymentGateway _paymentGateway;
    private readonly InvoiceService _invoiceService;

    public PaymentFacade()
    {
        _cardValidator = new CardValidator();
        _fraudService = new FraudService();
        _paymentGateway = new StripePaymentGateway();
        _invoiceService = new InvoiceService();
    }

    public async Task<(bool Success, string Message, string InvoiceNumber)> ProcessOrderPaymentAsync(decimal amount, string cardNumber, string cvv)
    {
        if (!_cardValidator.Validate(cardNumber, cvv))
        {
            return (false, "La tarjeta es inválida. Verifica los números.", string.Empty);
        }

        if (_fraudService.IsFraudulent(cardNumber, amount))
        {
            return (false, "Transacción declinada por prevención de fraude.", string.Empty);
        }

        bool charged = await _paymentGateway.ChargeAsync(amount, cardNumber);
        if (!charged)
        {
            return (false, "Fondos insuficientes o error en la pasarela bancaria.", string.Empty);
        }

        string invoice = _invoiceService.GenerateInvoice(amount);

        return (true, "Pago procesado exitosamente.", invoice);
    }
}