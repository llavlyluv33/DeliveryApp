using DeliveryApp.Models;

namespace DeliveryApp.Patterns;

public interface IOrderState
{
    void Next(Order order);
    string GetStatus();
}

public class PreparingState : IOrderState
{
    public void Next(Order order) => order.SetState(new DeliveringState());
    public string GetStatus() => "Подготовка";
}

public class DeliveringState : IOrderState
{
    public void Next(Order order) => order.SetState(new CompletedState());
    public string GetStatus() => "Доставка";
}

public class CompletedState : IOrderState
{
    public void Next(Order order) => Console.WriteLine("Заказ уже выполнен!");
    public string GetStatus() => "Выполнен";
}
