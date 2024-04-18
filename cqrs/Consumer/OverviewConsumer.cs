
using Event;
using ReadModel;

namespace Consumer
{
    public class OverviewConsumer
    {
        private OverviewModel _overviewModel;
        private EventBroker _eventBroker;
        public OverviewConsumer(OverviewModel overviewModel, EventBroker eventBroker)
        {
            _overviewModel = overviewModel;
            _eventBroker = eventBroker;
            _eventBroker.Subscribe(ConsumeEvent);
        }
        // Adjusted to match EventHandler<IEvent>
        public void ConsumeEvent(object sender, IEvent evt)
        {
            switch (evt.GetEventType())
            {
                case "AccountOpened":
                    var AccountOpenedEvent = (Event<AccountOpenedEventData>)evt;
                    HandleAccountOpenedEvent(AccountOpenedEvent.Data);
                    break;
                case "MoneyDeposited":
                    var MoneyDepositedEvent = (Event<MoneyDepositedEventData>)evt;
                    HandleMoneyDepositedEvent(MoneyDepositedEvent.Data);
                    break;
                case "MoneyWithdrawn":
                    var MoneyWithdrawnEvent = (Event<MoneyWithdrawnEventData>)evt;
                    HandleMoneyWithdrawnEvent(MoneyWithdrawnEvent.Data);
                    break;
                default:
                    break;
            }
        }

        private void HandleAccountOpenedEvent(AccountOpenedEventData data)
        {
            _overviewModel.AccountOpened(data.AccountNumber);
        }

        private void HandleMoneyDepositedEvent(MoneyDepositedEventData data)
        {
            _overviewModel.BalanceChanged(data.AccountNumber, data.Amount);
        }

        private void HandleMoneyWithdrawnEvent(MoneyWithdrawnEventData data)
        {
            _overviewModel.BalanceChanged(data.AccountNumber, -data.Amount);
        }
    }
}