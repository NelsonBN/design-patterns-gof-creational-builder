using Demo;

Console.WriteLine("Complex Scenario");

var ptInvoice = InvoiceManager.Construct(new()
{
    CountryCode = "PT",
    CustomerName = "John Doe",
    Coupon = "20-OFF",
    WithDelivery = true,
    Lines = new List<InvoiceRequest.Item>
    {
        new() { Name = "Gangs of Four (GoF) Design Patterns", Type = ItemType.Book, Quantity = 1, Price = 45 },
        new() { Name = "USB-C to HDMI Adapter", Type = ItemType.Electronic, Quantity = 2, Price = 5 }
    }
});
Console.WriteLine(ptInvoice);

Console.WriteLine("------------------");

var esInvoice = InvoiceManager.Construct(new()
{
    CountryCode = "ES",
    CustomerName = "Max Mustermann",
    Coupon = "DISCOUNT15",
    WithDelivery = true,
    Lines = new List<InvoiceRequest.Item>
    {
        new() { Name = "Laptop", Type = ItemType.Electronic, Quantity = 1, Price = 1000 }
    }
});
Console.WriteLine(esInvoice);
