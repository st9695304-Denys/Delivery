using Delivery.Models;

namespace Delivery.Transports;

public class Bike : Transport
{
    public Bike(string name) : base(name) { }

    public override decimal CalculateCost(Order order)
    {
        return 20m + 5m * order.Distance;
    }

    public override bool CanTake(Order order)
    {
        return order.Weight <= 5m && order.Distance <= 10m;
    }
}