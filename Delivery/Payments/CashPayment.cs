namespace Delivery.Payments;

public class CashPayment : IPayment
{
    public string Name { get { return "готівка"; } }

    public void Pay(decimal amount)
    {
        Console.WriteLine("Оплата готівкою: " + amount + " грн");
    }
}