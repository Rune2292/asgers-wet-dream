

namespace ReadModel
{

    public class Transaction(string accountNumber, int amount, DateTime date, string debitCredit)
    {
        public string AccountNumber { get; set; } = accountNumber;
        public int Amount { get; set; } = amount;
        public DateTime Date { get; set; } = date;
        public string DebitCredit { get; set; } = debitCredit;
    }
    public class HistoryModel
    {

        public Dictionary<string, List<Transaction>> _history = new();

        public void AddDepositEvent(string accountNumber, int amount, DateTime date)
        {
            if (!_history.ContainsKey(accountNumber))
            {
                _history[accountNumber] = new List<Transaction>();
            }

            _history[accountNumber].Add(new Transaction(accountNumber, amount, date, "Credit"));
        }

        public void AddWithdrawEvent(string accountNumber, int amount, DateTime date)
        {
            if (!_history.ContainsKey(accountNumber))
            {
                _history[accountNumber] = new List<Transaction>();
            }

            _history[accountNumber].Add(new Transaction(accountNumber, amount, date, "Debit"));
        }



        public List<Transaction> GetHistory(string accountNumber)
        {
            if (!_history.ContainsKey(accountNumber))
            {
                throw new Exception("Account not found");
            }

            return _history[accountNumber];

        }

    }
}