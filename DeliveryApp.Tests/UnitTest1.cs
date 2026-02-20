using DeliveryApp.Models;
using DeliveryApp.Patterns;

namespace DeliveryApp.Tests;

public class UnitTest1
{
    [Fact]
    public void Order_DefaultStatus_IsPreparing()
    {
        var order = new Order();
        Assert.Equal("Подготовка", order.GetStatus());
    }

    [Fact]
    public void Order_NextStatus_ChangesToDelivering()
    {
        var order = new Order();
        order.NextStatus();
        Assert.Equal("Доставка", order.GetStatus());
    }

    [Fact]
    public void Order_TwoNextStatus_ChangesToCompleted()
    {
        var order = new Order();
        order.NextStatus();
        order.NextStatus();
        Assert.Equal("Выполнен", order.GetStatus());
    }

    [Fact]
    public void DiscountPricing_AppliesCorrectly()
    {
        var strategy = new DiscountPricing(0.1m);
        var result = strategy.Calculate(1000);
        Assert.Equal(1050, result); 
    }

    [Fact]
    public void MenuRegistry_IsSingleton()
    {
        var a = MenuRegistry.Instance;
        var b = MenuRegistry.Instance;
        Assert.Same(a, b);
    }

    [Fact]
    public void OrderBuilder_BuildsCorrectly()
    {
        var customer = new Customer("Елена", "89632474512");
        var item = new MenuItem("Пицца", 500, "Еда");
        var order = new OrderBuilder()
            .SetCustomer(customer)
            .AddItem(item)
            .SetDeliveryAddress("ул. Мира, 1")
            .Build();

        Assert.Equal("Елена", order.Customer.Name);
        Assert.Single(order.Items);
        Assert.Equal("ул. Мира, 1", order.DeliveryAddress);
    }
}
