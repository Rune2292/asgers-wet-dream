
namespace Event
{
public class DepositEventArgs : EventArgs
{
    public int Amount { get; set; }

    public string AccountNumber { get; set; }

    private DateTime EventTime { get; set; }

    public DepositEventArgs(int amount, string accountNumber)
    {
        Amount = amount;
        AccountNumber = accountNumber;
        EventTime = DateTime.Now;
    }
}
}

