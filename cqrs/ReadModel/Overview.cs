


namespace ReadModel;
public class OverviewModel
{
    private Dictionary<string, int> _bankAccounts = new Dictionary<string, int>();

    public void AccountOpened(string accountNumber)
    {
        _bankAccounts[accountNumber] = 0;
    }
    public void BalanceChanged(string accountNumber, int amount)
    {
        _bankAccounts[accountNumber] += amount;
    }


    public int GetBalance(string accountNumber)
    {
        if (!_bankAccounts.ContainsKey(accountNumber))
        {
            throw new Exception("Account not found");
        }
        return _bankAccounts[accountNumber];
    }

}