namespace Demo;

public record InvoiceRequest
{
    public string CountryCode { get; init; }
    public string CustomerName { get; init; }
    public string Coupon { get; init; }
    public bool WithDelivery { get; init; }
    public IEnumerable<Item> Lines { get; init; }

    public record Item
    {
        public ItemType Type { get; init; }
        public string Name { get; init; }
        public int Quantity { get; init; }
        public decimal Price { get; init; }
    }
}
