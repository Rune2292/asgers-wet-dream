


using ReadModel;
using Event;
using System.Diagnostics.Tracing;
namespace Consumer;


public class HistoryConsumer{
        
    private HistoryModel _historyModel;


    public HistoryConsumer(HistoryModel historyModel, EventStore eventStore)
    {
        _historyModel = historyModel;
        eventStore.Subscribe(ConsumeEvent);
    }

    public void ConsumeEvent(object sender, IEvent evt)
    {
        switch (evt.GetEventType())
        {
            case "MoneyDeposited":
                var MoneyDepositedEvent = (Event<MoneyDepositedEventData>)evt;
                MoneyDeposited(MoneyDepositedEvent);
                break;
            case "MoneyWithdrawn":
                var MoneyWithdrawnEvent = (Event<MoneyWithdrawnEventData>)evt;
                MoneyWithdrawn(MoneyWithdrawnEvent);
                break;
            default:
                break;
        }
    }

    private void MoneyDeposited(Event<MoneyDepositedEventData> evt)
    {
        _historyModel.AddDepositEvent(evt.Data.AccountNumber, evt.Data.Amount, evt.EventTime);
    }

    private void MoneyWithdrawn(Event<MoneyWithdrawnEventData> evt)
    {
        _historyModel.AddWithdrawEvent(evt.Data.AccountNumber, evt.Data.Amount, evt.EventTime);
    }

    /*
    public void PrintHistory(string accountNumber)
    {
        var history = _historyModel.GetHistory(accountNumber);
        Console.WriteLine("History for account " + accountNumber);
        foreach (var transaction in history)
        {
            if (transaction.Item1 < 0)
            {
                Console.WriteLine("Withdrawn " + transaction + "$ at " + transaction.Item2.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            else
            {
                Console.WriteLine("Deposited " + transaction + "$ at " + transaction.Item2.ToString("yyyy-MM-dd HH:mm:ss"));
            }
        }
    }
    */

}