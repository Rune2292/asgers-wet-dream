using Cmd;
using Event;
using Repository;


namespace Handler;

public class CommandHandler
{

    private readonly EventBroker _eventBroker;

    private readonly AccountRepository _accountRepository;

    public CommandHandler(EventBroker eventBroker, AccountRepository accountRepository)
    {
        _eventBroker = eventBroker;
        _accountRepository = accountRepository;
    }

    public void HandleDeposit(DepositMoney command)
    {
        //Validate the depositMoney is legal
        command.Validate();

        if  (!_accountRepository.IfAccountExists(command.AccountNumber))
            throw new Exception("Account does not exist!");

        //Simulate doing the deposit
        //OMG im changing the database!

        //Publish the event
        var evtData = new MoneyDepositedEventData(command.Amount, command.AccountNumber);
        IEvent evt = new Event<MoneyDepositedEventData>("MoneyDeposited", evtData);



        _eventBroker.PublishEvent(evt);
        _accountRepository.SaveEvent(evt);

    }


    public void HandleWithdraw(WithdrawMoney command)
    {
        //Validate the WithdrawMoney is legal
        command.Validate();

        if  (!_accountRepository.IfAccountExists(command.AccountNumber))
            throw new Exception("Account does not exist!");
        //Check if there is enough balance on the account to withdraw
        int balance = _accountRepository.CheckBalanceOnAccount(command.AccountNumber);

        
        //Check if enough balance
        if (balance < command.Amount)
        {
            throw new Exception("Insufficient funds!");
        }

        //Publish the event
        var evtData = new MoneyWithdrawnEventData(command.Amount, command.AccountNumber);
        IEvent evt = new Event<MoneyWithdrawnEventData>("MoneyWithdrawn", evtData);

        _eventBroker.PublishEvent(evt);
        
        _accountRepository.SaveEvent(evt);
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

        _eventBroker.PublishEvent(evt);
        
        _accountRepository.SaveEvent(evt);

        return randomAccountNumber;

    }
}