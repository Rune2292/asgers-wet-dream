


namespace ReadModel
{
    public class OverviewModel
    {
        private Dictionary<string, int> _bankAccounts = new Dictionary<string, int>();

        public void ChangeBalance(string accountNumber, int amount)
        {
            if (!_bankAccounts.ContainsKey(accountNumber))
            {
                throw new Exception("Account not found");
            }

            if (_bankAccounts[accountNumber] + amount < 0)
            {
                throw new Exception("Not enough money");
            }

            _bankAccounts[accountNumber] += amount;

        }

        public int GetBalance(string accountNumber)
        {
            if (!_bankAccounts.ContainsKey(accountNumber))
            {
                return -1;
            }

            return _bankAccounts[accountNumber];
        }
    }
}