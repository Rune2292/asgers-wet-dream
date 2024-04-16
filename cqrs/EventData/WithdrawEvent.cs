


namespace Event;

public class MoneyWithdrawnEventData(int amount, string accountNumber)
{
    public int Amount { get; set; } = amount;

    public string AccountNumber { get; set; } = accountNumber;
}