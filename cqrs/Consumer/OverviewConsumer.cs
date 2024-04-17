using Event;
using ReadModel;

namespace Consumer
{
    public class OverviewConsumer
    {
        private OverviewModel _overviewModel;
        private EventStore _eventStore;

        public OverviewConsumer(OverviewModel overviewModel, EventStore eventStore)
        {
            _overviewModel = overviewModel;
            _eventStore = eventStore;
            _eventStore.Subscribe(ConsumeEvent);
        }
        // Adjusted to match EventHandler<IEvent>
        public void ConsumeEvent(object sender, IEvent evt)
        {
            switch (evt.GetEventType())
            {
                case "MoneyDeposited":
                    var MoneyDepositedEvent = (Event<MoneyDepositedEventData>)evt;
                    MoneyDeposited(MoneyDepositedEvent.Data);
                    break;
                case "MoneyWithdrawn":
                    var MoneyWithdrawnEvent = (Event<MoneyWithdrawnEventData>)evt;
                    MoneyWithdrawn(MoneyWithdrawnEvent.Data);
                    break;
                default:
                    break;
            }
        }


        private void MoneyDeposited(MoneyDepositedEventData data)
        {
            try
            {
                _overviewModel.DepositMoney(data.AccountNumber, data.Amount);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
            }
        }

        private void MoneyWithdrawn(MoneyWithdrawnEventData data)
        {
            try
            {
                _overviewModel.WithdrawMoney(data.AccountNumber, data.Amount);
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
