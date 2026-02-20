using DeliveryApp.Models;

namespace DeliveryApp.Patterns;

public class MenuRegistry
{
    private static MenuRegistry? _instance;
    private List<MenuItem> _items = new();

    private MenuRegistry() { }

    public static MenuRegistry Instance => _instance ??= new MenuRegistry();

    public void AddItem(MenuItem item) => _items.Add(item);
    public List<MenuItem> GetAll() => _items;
}
