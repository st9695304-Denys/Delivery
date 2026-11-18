using Delivery.Models;
using Delivery.Payments;
using Delivery.Services;
using Delivery.Transports;

namespace Delivery;

public class Program
{
    public static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        DeliveryService service = new DeliveryService();

      
        Transport bike = new Bike("Велосипед");
        Transport car = new Car("Автомобіль");
        Transport truck = new Truck("Вантажівка");
        service.AddTransport(bike);
        service.AddTransport(car);
        service.AddTransport(truck);

      
        Order o1 = service.CreateOrder(1, "Піца", 2, 5);
        Order o2 = service.CreateOrder(2, "Шафа", 50, 8);
        Order o3 = service.CreateOrder(3, "Документи", 1, 15);
        Order o4 = service.CreateOrder(4, "Посилка", 3, 4);

 
        Console.WriteLine();
        service.ShowCosts(o1);
        service.ShowCosts(o2);
        service.ShowCosts(o3);

   
        Console.WriteLine();
        service.AssignOrder(o1, bike);
        service.AssignOrder(o4, bike);
        service.AssignOrder(o2, bike);
        service.AssignOrder(o3, car);
        service.AssignOrder(o1, truck);

   
        Console.WriteLine();
        service.DeliverOrder(o2, new CashPayment());


        Console.WriteLine();
        service.PrintActive();

 
        Console.WriteLine();
        service.DeliverOrder(o1, new CardPayment());
        service.DeliverOrder(o3, new CashPayment());

    
        Console.WriteLine();
        service.AssignOrder(o4, bike);
        service.AssignOrder(o2, truck);


        Console.WriteLine();
        service.PrintActive();
        service.PrintHistory();
    }
}