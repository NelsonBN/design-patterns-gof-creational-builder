namespace Demo;

/// <summary>
/// Director
/// </summary>
public static class InvoiceManager
{
    public static Invoice Construct(InvoiceRequest request)
    {
        var builder = Invoice
            .For(request.CountryCode)
            .ForCustomer(request.CustomerName)
            .ApplyCoupon(request.Coupon);

        foreach (var line in request.Lines)
        {
            builder.AddProduct(
                line.Type,
                line.Name,
                line.Quantity,
                line.Price);
        }

        if(request.WithDelivery)
        {
            builder.ApplyDeliveryCharge();
        }

        return builder;
    }
}
