namespace Marketplace.Domain;

public class ClassifiedAd
{
    public Guid Id { get; }

    public ClassifiedAd(Guid? id)
    {
        Id = id ?? throw new ArgumentException("Identity must be specified", nameof(id));
    }

    public void SetTitle(string title) => _title = title;
    public void UpdateText(string text) => _text = text;
    public void UpdatePrice(decimal price) => _price = price;
    
    private Guid _ownerId;
    private string _title;
    private string _text;
    private decimal _price;
}