namespace Demo;

public abstract class InvoiceBuilder
{
    public abstract InvoiceBuilder AddProduct(ItemType Type, string name, int quantity, decimal price);
    public abstract InvoiceBuilder ForCustomer(string name);
    public abstract InvoiceBuilder ApplyDeliveryCharge();
    public abstract InvoiceBuilder ApplyCoupon(string couponCode);
    public abstract Invoice Build();
}
