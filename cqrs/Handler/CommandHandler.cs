using Controller;
using Cmd;
using Event;


namespace Handler
{
    
    public class CommandHandler
    {       

        private readonly EventStore _eventPublisher;

        public CommandHandler(EventStore eventPublisher)
        {
            _eventPublisher = eventPublisher;
        }   
        public void HandleDeposit(DepositMoney command)
        {
            //Validate the depositMoney is legal
            command.Validate();

            //Simulate doing the deposit
            //OMG im changing the database!

            //Publish the event
            var evtData = new MoneyDepositedEventData(command.Amount, command.AccountNumber);
            IEvent evt = new Event<MoneyDepositedEventData>("MoneyDeposited", evtData);

            _eventPublisher.PublishEvent(evt);
        
        }


        public void HandleWithdraw(WithdrawMoney command)
        {
            //Validate the WithdrawMoney is legal
            command.Validate();

            //Simulate doing the deposit
            //OMG im changing the database!

            //Publish the event
            var evtData = new MoneyWithdrawnEventData(command.Amount, command.AccountNumber);
            IEvent evt = new Event<MoneyWithdrawnEventData>("MoneyWithdrawn", evtData);

            _eventPublisher.PublishEvent(evt);

        }
    }
}