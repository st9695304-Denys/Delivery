using Delivery.Models;

namespace Delivery.Transports;

public class Truck : Transport
{
    public Truck(string name) : base(name) { }

    public override decimal CalculateCost(Order order)
    {
        return 200m + 15m * order.Distance + 0.5m * order.Weight;
    }
}