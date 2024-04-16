
using Event;

namespace Repository;
public class AccountRepository
{
    private readonly EventStore _eventStore;

    public AccountRepository(EventStore eventStore)
    {
        _eventStore = eventStore;
    }

    public bool IfAccountExists(string accountNumber)
    {
        var eventStoreList = _eventStore.GetEventStoreList();

        foreach (var storedEvent in eventStoreList)
        {
            switch (storedEvent.GetEventType())
            {
                case "AccountOpened":
                    var accountOpenedEvent = (Event<AccountOpenedEventData>)storedEvent;
                    if (accountOpenedEvent.Data.AccountNumber == accountNumber)
                    {
                        return true;
                    }
                    break;
                default:
                    break;
            }
        }

        return false;
    }

    public string GenerateAccountNumber()
    {
        string randomAccountNumber = string.Empty;
        var random = new Random();
        randomAccountNumber += random.Next(1, 10).ToString(); // First digit should not be 0

        for (int j = 0; j < 6; j++) //Generate the next 5 digits
        {
            randomAccountNumber += random.Next(0, 10).ToString();
        }

        return randomAccountNumber;
    }

    public int CheckBalanceOnAccount(string accountNumber)
    {
        var eventStoreList = _eventStore.GetEventStoreList();

        int balance = 0;

        foreach (var storedEvent in eventStoreList)
        {
            switch (storedEvent.GetEventType())
            {
                case "MoneyDeposited":
                    var moneyDepositedEvent = (Event<MoneyDepositedEventData>)storedEvent;
                    if (moneyDepositedEvent.Data.AccountNumber == accountNumber)
                    {
                        balance += moneyDepositedEvent.Data.Amount;
                    }
                    break;
                case "MoneyWithdrawn":
                    var moneyWithdrawnEvent = (Event<MoneyWithdrawnEventData>)storedEvent;
                    if (moneyWithdrawnEvent.Data.AccountNumber == accountNumber)
                    {
                        balance -= moneyWithdrawnEvent.Data.Amount;
                    }
                    break;
                default:
                    break;
            }
        }

        return balance;
    }


}