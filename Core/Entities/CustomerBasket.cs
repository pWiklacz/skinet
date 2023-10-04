namespace Core.Entities;

public class CustomerBasket
{
    public string Id { get; set; } = null!;
    public List<BasketItem> Items { get; set; } = new List<BasketItem>();

    public CustomerBasket()
    {
    }

    public CustomerBasket(string id)
    {
        Id = id;
    }
}
