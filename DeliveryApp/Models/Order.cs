using DeliveryApp.Patterns;

namespace DeliveryApp.Models;

public class Order : ISubject
{
    public Customer Customer { get; set; }
    public List<MenuItem> Items { get; set; } = new();
    public string DeliveryAddress { get; set; } = "";
    private IOrderState _state = new PreparingState();
    private IPricingStrategy _pricing = new StandardPricing();
    private List<IObserver> _observers = new();

    public void SetState(IOrderState state)
    {
        _state = state;
        Notify($"Статус изменён: {state.GetStatus()}");
    }

    public void NextStatus() => _state.Next(this);
    public string GetStatus() => _state.GetStatus();

    public void SetPricingStrategy(IPricingStrategy strategy) => _pricing = strategy;

    public decimal GetTotal()
    {
        decimal basePrice = Items.Sum(i => i.Price);
        return _pricing.Calculate(basePrice);
    }

    public void Subscribe(IObserver o) => _observers.Add(o);

    public void Notify(string message)
    {
        foreach (var o in _observers) o.Update(message);
    }
}
