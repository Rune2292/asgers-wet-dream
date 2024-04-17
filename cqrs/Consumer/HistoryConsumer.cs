using ReadModel;
using Event;


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
            case "AccountOpened":
                var AccountOpenedEvent = (Event<AccountOpenedEventData>)evt;
                AccountOpened(AccountOpenedEvent);
                break;

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

    private void AccountOpened(Event<AccountOpenedEventData> evt)
    {
        _historyModel.AddAccountOpened(evt.Data.AccountNumber);
    }

    private void MoneyDeposited(Event<MoneyDepositedEventData> evt)
    {
        _historyModel.AddTransaction(evt.Data.AccountNumber, evt.Data.Amount, evt.EventTime, "Credit");
    }

    private void MoneyWithdrawn(Event<MoneyWithdrawnEventData> evt)
    {
        _historyModel.AddTransaction(evt.Data.AccountNumber, evt.Data.Amount, evt.EventTime, "Debit");
    }
}