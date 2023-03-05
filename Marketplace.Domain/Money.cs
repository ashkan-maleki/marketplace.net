using Marketplace.Framework;

namespace Marketplace.Domain;

// public class Money : IEquatable<Money>
// {
//     public decimal Amount { get; }
//     public Money(decimal amount) => Amount = amount;
//
//     public bool Equals(Money? other)
//     {
//         if (ReferenceEquals(null, other)) return false;
//         if (ReferenceEquals(this, other)) return true;
//         return Amount == other.Amount;
//     }
//
//     public override bool Equals(object? obj)
//     {
//         if (ReferenceEquals(null, obj)) return false;
//         if (ReferenceEquals(this, obj)) return true;
//         if (obj.GetType() != this.GetType()) return false;
//         return Equals((Money) obj);
//     }
//
//     public override int GetHashCode() => Amount.GetHashCode();
//
//     public static bool operator ==(Money left, Money right) => Equals(left, right);
//
//     public static bool operator !=(Money left, Money right) => !Equals(left, right);
// }

public class Money : Value<Money>
{
    private const string DefaultCurrency = "EUR";

    public static Money FromDecimal(decimal amount, string currency = DefaultCurrency)
        => new(amount, currency);

    public static Money FromString(string amount, string currency = DefaultCurrency)
        => new(decimal.Parse(amount), currency);

    protected Money(decimal amount, string currencyCode = "EUR")
    {
        if (decimal.Round(amount, 2) != amount)
        {
            throw new ArgumentOutOfRangeException(nameof(amount)
                , "Amount Cannot have more than two decimals");
        }

        Amount = amount;
        CurrencyCode = currencyCode;
    }

    public decimal Amount { get; }
    public string CurrencyCode { get; }

    public Money Add(Money summand)
    {
        if (CurrencyCode != summand.CurrencyCode)
            throw new CurrencyMismatchException(
                "Cannot sum amounts with different currencies");
        return new(Amount + summand.Amount);
    }

    public Money Subtract(Money subtrahend)
    {
        if (CurrencyCode != subtrahend.CurrencyCode)
            throw new CurrencyMismatchException(
                "Cannot sum amounts with different currencies");
        return new(Amount - subtrahend.Amount);
    }

    public static Money operator +(Money left, Money right) => left.Add(right);
    public static Money operator -(Money left, Money right) => left.Subtract(right);
}