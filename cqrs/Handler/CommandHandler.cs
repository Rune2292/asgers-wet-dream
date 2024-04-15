using Controller;
using Cmd;
using Event;


namespace Handler
{
    
    public class CommandHandler
    {       

        private readonly CommandPublisher _commandPublisher;

        public CommandHandler(CommandPublisher commandPublisher)
        {
            _commandPublisher = commandPublisher;
        }   
        public async Task HandleDeposit(DepositMoney command)
        {
            //Validate the depositMoney is legal
            command.Validate();

            //Simulate doing the deposit
            //OMG i changing the database!

            CommandEvent commandEvent = new CommandEvent(typeof(DepositMoney), command);

            //Create a event to be published
            _commandPublisher.PublishEvent(commandEvent);            
        }
    }
}