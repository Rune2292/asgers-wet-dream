

namespace Event;

public class AccountOpenedEventData(string accountNumber)
{
    public string AccountNumber { get; set; } = accountNumber;
}