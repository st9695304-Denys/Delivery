using Delivery.Models;

namespace Delivery.Transports;

public abstract class Transport
{
    public string Name { get; }
    public bool IsBusy { get; set; }

    protected Transport(string name)
    {
        Name = name;
        IsBusy = false;
    }

    public abstract decimal CalculateCost(Order order);

    public virtual bool CanTake(Order order)
    {
        return true;
    }
}