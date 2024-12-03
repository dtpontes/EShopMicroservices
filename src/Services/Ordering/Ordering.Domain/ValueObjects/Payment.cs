namespace Ordering.Domain.ValueObjects;

public record Payment
{
    public string CardName { get; } = default!;

    public string CardNumber { get; } = default!;    

    public DateTime Expiration { get; } = default!;

    public string CVV { get; } = default!;

    public int PaymentMethod { get; } = default!;

    //Construtor para EF
    protected Payment()
    {
    }   

    private Payment(string cardName, string cardNumber, DateTime expiration, string cvv, int paymentMethod)
    {
        CardName = cardName;
        CardNumber = cardNumber;
        Expiration = expiration;
        CVV = cvv;
        PaymentMethod = paymentMethod;
    }

    public static Payment Of(string cardName, string cardNumber, DateTime expiration, string cvv, int paymentMethod)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(cardName);
        ArgumentException.ThrowIfNullOrWhiteSpace(cardNumber);
        ArgumentException.ThrowIfNullOrWhiteSpace(cvv);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(cvv.Length, 3);

        return new Payment(cardName, cardNumber, expiration, cvv, paymentMethod);
    }



}
