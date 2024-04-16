using Event;
using ReadModel;

namespace Consumer;



public class OverviewConsumer
{
    private OverviewModel _overviewModel;
    public OverviewConsumer(OverviewModel overviewModel){
        _overviewModel = overviewModel;
    }
    public void ConsumeEvent(IEvent evt)
    {
        switch (evt.GetEventType())
        {
            case "MoneyDeposited":
                var MoneyDepositedEvent = (Event<MoneyDepositedEventData>) evt;
                MoneyDeposited(MoneyDepositedEvent.Data);
                //Do something with the data
                break;
            case "MoneyWithdrawn":
                var MoneyWithdrawnEvent = (Event<MoneyWithdrawnEventData>) evt;
                MoneyWithdrawn(MoneyWithdrawnEvent.Data);
                //Do something with the data
                break;
            default:
                break;
        }
    }
    
    public void PrintBalance(string accountNumber)
    {
        if (_overviewModel.GetBalance(accountNumber) == -1)
        {
            Console.WriteLine("Account not found");
            return;
        }
        Console.WriteLine("Account " + accountNumber + " Has " + _overviewModel.GetBalance(accountNumber) + "$");
    }

    public void MoneyDeposited(MoneyDepositedEventData data)
    {
        try {
            _overviewModel.ChangeBalance(data.AccountNumber, data.Amount);
            Console.WriteLine("Deposited " + data.Amount + "$ to account " + data.AccountNumber);
            PrintBalance(data.AccountNumber);
        } catch (System.Exception e) {
            Console.WriteLine(e);
        }
    }

    public void MoneyWithdrawn(MoneyWithdrawnEventData data)
    {
        try {
            _overviewModel.ChangeBalance(data.AccountNumber, -data.Amount);
            Console.WriteLine("Withdrawn " + data.Amount + "$ from account " + data.AccountNumber);
            PrintBalance(data.AccountNumber);
        } catch (System.Exception e) {
            Console.WriteLine(e);
        }
    }

}