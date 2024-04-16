
namespace Event
{
public class MoneyDepositedEventData(int amount, string accountNumber)
    {
        public int Amount { get; set; } = amount;

        public string AccountNumber { get; set; } = accountNumber;
    }
}

