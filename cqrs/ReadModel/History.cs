



namespace ReadModel
{
    public class HistoryModel
    {

        public Dictionary<string, List<int>> _history = new Dictionary<string, List<int>>();
        
        public void AddEvent(string accountNumber, int amount)
        {
            if (!_history.ContainsKey(accountNumber))
            {
                _history[accountNumber] = new List<int>();
            }

            _history[accountNumber].Add(amount);
        }

        public List<int> GetHistory(string accountNumber)
        {
            if (!_history.ContainsKey(accountNumber))
            {
                return new List<int>();
            }

            return _history[accountNumber];
        }
    }


}