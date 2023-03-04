using Xunit;
using FluentAssertions;
using Marketplace.Domain;

namespace Marketplace.Tests;


public class MoneyTest
{
    [Fact]
    public void Money_objects_with_same_amount_should_be_equal()
    {
        Money firstAmount = new(5);
        Money secondAmount = new(5);
        firstAmount.Should().Be(secondAmount);
        // Assert.Equal(firstAmount, secondAmount);
    }

    [Fact]
    public void Sum_of_money_gives_full_amount()
    {
        Money coin1 = new(1);
        Money coin2 = new(2);
        Money coin3 = new(2);
        Money banknote = new(5);

        banknote.Should().Be(coin1 + coin2 + coin3);
    }
}