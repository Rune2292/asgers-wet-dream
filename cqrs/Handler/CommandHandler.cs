using Controller;
using Commmand;


namespace Handler
{
    public class CommandHandler
    {       public async Task HandleDeposit(DepositMoney command)
        {
            command.Validate();
        }
    }
}