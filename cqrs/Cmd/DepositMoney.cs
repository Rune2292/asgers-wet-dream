

namespace Cmd;
public class DepositMoney
{
    public int Amount { get; set; }
    public string? AccountNumber { get; set; }
    public void Validate()
    {
        if (string.IsNullOrEmpty(AccountNumber))
        {
            throw new Exception("Account number must not be empty");
        }
        if (Amount <= 0)
        {
            throw new Exception("Amount must be greater than 0");
        }
    }
}