namespace DeliveryApp.Models;

public class MenuItem
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; }

    public MenuItem(string name, decimal price, string category)
    {
        Name = name;
        Price = price;
        Category = category;
    }
}
