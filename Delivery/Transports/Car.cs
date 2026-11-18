using Delivery.Models;

namespace Delivery.Transports;

public class Car : Transport
{
    public Car(string name) : base(name) { }

    public override decimal CalculateCost(Order order)
    {
        return 50m + 8m * order.Distance + 1m * order.Weight;
    }
}