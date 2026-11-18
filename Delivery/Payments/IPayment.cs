namespace Delivery.Payments;

public interface IPayment
{
    string Name { get; }
    void Pay(decimal amount);
}