using DeliveryApp.Models;

namespace DeliveryApp.Patterns;

public class OrderBuilder
{
    private Order _order = new Order();

    public OrderBuilder SetCustomer(Customer customer)
    {
        _order.Customer = customer;
        return this;
    }

    public OrderBuilder AddItem(MenuItem item)
    {
        _order.Items.Add(item);
        return this;
    }

    public OrderBuilder SetDeliveryAddress(string address)
    {
        _order.DeliveryAddress = address;
        return this;
    }

    public OrderBuilder SetPricing(IPricingStrategy strategy)
    {
        _order.SetPricingStrategy(strategy);
        return this;
    }

    public Order Build() => _order;
}
