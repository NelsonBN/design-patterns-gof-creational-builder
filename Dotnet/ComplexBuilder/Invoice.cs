using System.Text.Json;

namespace Demo;

public enum ItemType { Electronic, Book }

public partial record Invoice
{
    public string Country { get; private set; }
    public string CustomerName { get; private set; }
    public decimal SubTotal { get; private set; }
    public decimal Total { get; private set; }
    public IEnumerable<Line> Lines { get; private set; }

    public record Line
    {
        public required string Discretion { get; init; }
        public required int Quantity { get; init; }
        public required decimal Price { get; init; }
        public required decimal Total { get; init; }
        public required decimal Tax { get; init; }
        public required decimal TotalWithTax { get; init; }
    }

    private Invoice() { }

    public static implicit operator Invoice(InvoiceBuilder builder)
        => builder.Build();

    public static InvoiceBuilder For(string countryCode)
        => countryCode switch
        {
            "ES" => new SpainInvoiceBuilder(),
            "PT" => new PortugalInvoiceBuilder(),
            _ => throw new NotSupportedException("Country not supported")
        };

    public override string ToString()
        => JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
}
