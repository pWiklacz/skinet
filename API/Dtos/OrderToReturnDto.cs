using Core.Entities.OrderAggregate;

namespace API.Dtos;

public class OrderToReturnDto
{
    public int Id { get; set; }
    public string BuyerEmail { get; set; } = null!;
    public DateTime OrderDate { get; set; }
    public Address ShipToAddress { get; set; } = null!;
    public string DeliveryMethod { get; set; } = null!;
    public decimal ShippingPrice { get; set; }
    public IReadOnlyList<OrderItemDto> OrderItems { get; set; } = null!;
    public decimal Subtotal { get; set; }
    public decimal Total { get; set; }
    public string Status { get; set; } = null!;
}