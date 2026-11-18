using Delivery.Transports;

namespace Delivery.Models;

public class Order
{
    public int Number { get; }
    public string Description { get; }
    public decimal Weight { get; }    
    public decimal Distance { get; }   

    public Transport? Transport { get; set; } 
    public decimal Cost { get; set; }
    public string PaymentName { get; set; } = "";

    public Order(int number, string description, decimal weight, decimal distance)
    {
        Number = number;
        Description = description;
        Weight = weight;
        Distance = distance;
    }

    public override string ToString()
    {
        return "Замовлення №" + Number + " (" + Description + ", " + Weight + " кг, " + Distance + " км)";
    }
}