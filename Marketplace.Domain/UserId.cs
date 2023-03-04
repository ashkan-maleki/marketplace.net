namespace Marketplace.Domain;

public class UserId
{
    private readonly Guid _value;

    public UserId(Guid value) => _value = value;
}