namespace DeliveryApp.Patterns;

public interface IObserver
{
    void Update(string message);
}

public interface ISubject
{
    void Subscribe(IObserver o);
    void Notify(string message);
}

public class CustomerObserver : IObserver
{
    private string _name;

    public CustomerObserver(string name) => _name = name;

    public void Update(string message) =>
        Console.WriteLine($"[Уведомление для {_name}]: {message}");
}
