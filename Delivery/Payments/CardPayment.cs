namespace Delivery.Payments;

public class CardPayment : IPayment
{
    public string Name { get { return "картка"; } }

    public void Pay(decimal amount)
    {
        Console.WriteLine("Оплата карткою: " + amount + " грн");
    }
}