namespace Demo;

/// <summary>
/// Concrete Builder
/// </summary>
public partial record Invoice
{
    public class SpainInvoiceBuilder : InvoiceBuilder
    {
        private readonly Invoice _invoice = new() { Country = "Spain" };
        private List<Line> _lines = [];

        private decimal _deliveryCharge;
        private string _coupon;


        public override InvoiceBuilder AddProduct(ItemType Type, string name, int quantity, decimal price)
        {
            var total = quantity * price;
            var tax = _getTax(Type);
            _lines.Add(new()
            {
                Discretion = $"{Type} - {name}",
                Quantity = quantity,
                Price = price,
                Total = total,
                Tax = tax * 100M,
                TotalWithTax = total * (1 + tax)
            });

            return this;
        }

        public override InvoiceBuilder ForCustomer(string name)
        {
            _invoice.CustomerName = name;
            return this;
        }

        public override InvoiceBuilder ApplyCoupon(string couponCode)
        {
            if(!string.IsNullOrWhiteSpace(couponCode))
            {
                _coupon = couponCode;
            }

            return this;
        }

        public override InvoiceBuilder ApplyDeliveryCharge()
        {
            _deliveryCharge = 3.75M;
            return this;
        }

        public override Invoice Build()
        {
            _validate();

            _invoice.SubTotal = _lines.Sum(x => x.Total);
            _invoice.Total = _lines.Sum(x => x.TotalWithTax);

            var discount = _calculateCouponDiscount();
            _invoice.Total += discount;

            _calculateDeliveryCharge();

            _invoice.Lines = _lines;
            return _invoice;
        }

        private void _validate()
        {
            if(string.IsNullOrWhiteSpace(_invoice.CustomerName)) throw new ArgumentException("Customer name is required");
            if(_lines.Count == 0) throw new ArgumentException("At least one line is required");
        }

        private static decimal _getTax(ItemType productType)
            => productType switch
            {
                ItemType.Electronic => 0.21M,
                ItemType.Book => 0.04M,
                _ => 0m,
            };

        private decimal _calculateCouponDiscount()
        {
            var discountPercentage = _coupon switch
            {
                "DISCOUNT15" => -0.15M,
                "DISCOUNT20" => -0.20M,
                _ => 0
            };

            var discount = _invoice.SubTotal * discountPercentage;
            if(discount < 0)
            {
                _lines.Add(new()
                {
                    Discretion = $"Coupon discount {_coupon}",
                    Quantity = 1,
                    Price = discount,
                    Total = discount,
                    Tax = 0,
                    TotalWithTax = 0
                });
            }

            return discount;
        }

        private void _calculateDeliveryCharge()
        {
            if(_deliveryCharge > 0)
            {
                _lines.Add(new()
                {
                    Discretion = "Delivery charge",
                    Quantity = 1,
                    Price = _deliveryCharge,
                    Total = _deliveryCharge,
                    Tax = 0,
                    TotalWithTax = 0
                });

                if(_invoice.SubTotal >= 80)
                {
                    _lines.Add(new()
                    {
                        Discretion = "Delivery charge discount for orders over 80",
                        Quantity = 1,
                        Price = _deliveryCharge * -1,
                        Total = _deliveryCharge * -1,
                        Tax = 0,
                        TotalWithTax = 0
                    });

                    _deliveryCharge = 0;
                }
            }

            _invoice.Total += _deliveryCharge;
        }
    }
}
