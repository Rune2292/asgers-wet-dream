using Cmd;
using Event;
using Repository;


namespace Handler;

public class CommandHandler
{

    private readonly EventStore _eventPublisher;

    private readonly AccountRepository _accountRepository;

    public CommandHandler(EventStore eventPublisher, AccountRepository accountRepository)
    {
        _eventPublisher = eventPublisher;
        _accountRepository = accountRepository;
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

        //Check if there is enough balance on the account to withdraw
        int balance = _accountRepository.CheckBalanceOnAccount(command.AccountNumber);
        //Check if enough balance
        if (balance < command.Amount)
        {
            throw new System.Exception("Not enough balance to withdraw");
        }

        //Publish the event
        var evtData = new MoneyWithdrawnEventData(command.Amount, command.AccountNumber);
        IEvent evt = new Event<MoneyWithdrawnEventData>("MoneyWithdrawn", evtData);

        _eventPublisher.PublishEvent(evt);

    }

    public string HandleOpenAccount()
    {
        string randomAccountNumber;
        //Check if the account already exists
        do 
        {
            randomAccountNumber = _accountRepository.GenerateAccountNumber();

        } while (_accountRepository.IfAccountExists(randomAccountNumber));

        //Publish the event
        var evtData = new AccountOpenedEventData(randomAccountNumber);
        IEvent evt = new Event<AccountOpenedEventData>("AccountOpened", evtData);

        _eventPublisher.PublishEvent(evt);

        return randomAccountNumber;

    }
}