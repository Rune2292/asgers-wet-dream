using Controller;
using Cmd;
using Event;
using System.Security.Cryptography;


namespace Handler;

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

    public void HandleOpenAccount()
    {
        List<IEvent> eventStore = _eventPublisher.GetEventStoreList();

        string randomAccountNumber = GenerateAccountNumber();

        for (int i = 0; i < eventStore.Count; i++)
        {
            if (eventStore[i].GetEventType() != "AccountOpened")
                continue;

            string accountNumber = ((Event<AccountOpenedEventData>)eventStore[i]).Data.AccountNumber;

            if (accountNumber != randomAccountNumber)
                continue;

            randomAccountNumber = GenerateAccountNumber();
            i = 0;

        }


        //Simulate doing the deposit
        //OMG im changing the database!

        //Publish the event
        var evtData = new AccountOpenedEventData(randomAccountNumber);
        IEvent evt = new Event<AccountOpenedEventData>("AccountOpened", evtData);

        _eventPublisher.PublishEvent(evt);

    }


    private string GenerateAccountNumber()
    {
        string randomAccountNumber = string.Empty;
        var random = new Random();
        randomAccountNumber += random.Next(1, 10).ToString(); // First digit should not be 0

        for (int j = 0; j < 8; j++) //Generate the next 9 digits
        {
            randomAccountNumber += random.Next(0, 10).ToString();
        }

        return randomAccountNumber;
    }
}