namespace DeliveryApp.Patterns;

public interface IPricingStrategy
{
    decimal Calculate(decimal basePrice);
}

public class StandardPricing : IPricingStrategy
{
    public decimal Calculate(decimal basePrice) => basePrice + 150;
}

public class DiscountPricing : IPricingStrategy
{
    private decimal _discount;
    public DiscountPricing(decimal discount) => _discount = discount;
    public decimal Calculate(decimal basePrice) => basePrice * (1 - _discount) + 150;
}

public class TaxPricing : IPricingStrategy
{
    public decimal Calculate(decimal basePrice) => basePrice * 1.2m + 150;
}
