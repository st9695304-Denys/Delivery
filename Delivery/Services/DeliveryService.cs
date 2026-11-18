using Delivery.Models;
using Delivery.Payments;
using Delivery.Transports;

namespace Delivery.Services;

public class DeliveryService
{
    private List<Transport> transports = new List<Transport>();
    private List<Order> activeOrders = new List<Order>();
    private List<Order> history = new List<Order>();

    public void AddTransport(Transport transport)
    {
        transports.Add(transport);
        Console.WriteLine("Створено транспорт: " + transport.Name);
    }

    public Order CreateOrder(int number, string description, decimal weight, decimal distance)
    {
        Order order = new Order(number, description, weight, distance);
        activeOrders.Add(order);
        Console.WriteLine("Створено: " + order);
        return order;
    }

    public void ShowCosts(Order order)
    {
        Console.WriteLine("Вартість для " + order + ":");
        bool anyone = false;
        foreach (Transport t in transports)
        {
            if (t.CanTake(order))
            {
                Console.WriteLine("  " + t.Name + ": " + t.CalculateCost(order) + " грн");
                anyone = true;
            }
        }
        if (!anyone)
        {
            Console.WriteLine("  Жоден транспорт не може взяти це замовлення");
        }
    }

    public bool AssignOrder(Order order, Transport transport)
    {
        if (order.Transport != null)
        {
            Console.WriteLine("Помилка: замовлення №" + order.Number + " вже призначене");
            return false;
        }
        if (transport.IsBusy)
        {
            Console.WriteLine("Помилка: " + transport.Name + " зайнятий");
            return false;
        }
        if (!transport.CanTake(order))
        {
            Console.WriteLine("Помилка: " + transport.Name + " не може взяти замовлення №" + order.Number);
            return false;
        }

        order.Transport = transport;
        order.Cost = transport.CalculateCost(order);
        transport.IsBusy = true;
        Console.WriteLine("Замовлення №" + order.Number + " призначено на " + transport.Name);
        return true;
    }

    public bool DeliverOrder(Order order, IPayment payment)
    {
        if (order.Transport == null)
        {
            Console.WriteLine("Помилка: замовлення №" + order.Number + " ще не призначене на транспорт");
            return false;
        }

        payment.Pay(order.Cost);
        order.PaymentName = payment.Name;
        order.Transport.IsBusy = false;

        activeOrders.Remove(order);
        history.Add(order);
        Console.WriteLine("Замовлення №" + order.Number + " доставлено");
        return true;
    }

    public void PrintActive()
    {
        Console.WriteLine("--- Активні замовлення ---");
        if (activeOrders.Count == 0)
        {
            Console.WriteLine("Немає");
        }
        foreach (Order o in activeOrders)
        {
            string status = o.Transport == null ? "не призначено" : "транспорт: " + o.Transport.Name;
            Console.WriteLine(o + " - " + status);
        }
    }

    public void PrintHistory()
    {
        Console.WriteLine("--- Історія доставок ---");
        if (history.Count == 0)
        {
            Console.WriteLine("Немає");
        }
        foreach (Order o in history)
        {
            string transportName = o.Transport == null ? "-" : o.Transport.Name;
            Console.WriteLine(o + " - " + transportName + ", " + o.Cost + " грн, оплата: " + o.PaymentName);
        }
    }
}