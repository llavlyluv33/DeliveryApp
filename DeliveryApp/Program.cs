using DeliveryApp.Models;
using DeliveryApp.Patterns;

var menu = MenuRegistry.Instance;
menu.AddItem(new MenuItem("Пицца Маргарита", 650, "Пицца"));
menu.AddItem(new MenuItem("Суши сет", 1200, "Японская кухня"));
menu.AddItem(new MenuItem("Бургер", 450, "Фаст-фуд"));


var customer = new Customer("Анна", "+7 999 123-45-67");
var observer = new CustomerObserver(customer.Name);


var order = new OrderBuilder()
    .SetCustomer(customer)
    .AddItem(menu.GetAll()[0]) 
    .AddItem(menu.GetAll()[2]) 
    .SetDeliveryAddress("ул. Невский пр., 1")
    .SetPricing(new DiscountPricing(0.1m)) 
    .Build();


order.Subscribe(observer);


Console.WriteLine($"Заказ для: {order.Customer.Name}");
Console.WriteLine($"Адрес: {order.DeliveryAddress}");
Console.WriteLine($"Статус: {order.GetStatus()}");
Console.WriteLine($"Сумма: {order.GetTotal()} руб.");


Console.WriteLine("\nОбновления статуса заказа:");
order.NextStatus(); 
order.NextStatus(); 
order.NextStatus(); 
