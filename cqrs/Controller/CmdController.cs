using Handler;
using Cmd;
using Microsoft.AspNetCore.Mvc;
using Dto;


namespace Controller;

[Route("v1/[controller]")]
[ApiController]
public class CmdController : ControllerBase
{
    private readonly CommandHandler _commandHandler;



    public CmdController(CommandHandler commandHandler)
    {
        _commandHandler = commandHandler;
    }

    [HttpPost("Withdraw")]
    public ActionResult<ErrorMessageDto> WithdrawMoneyEndpoint([FromBody] WithdrawMoney command)
    {
        try
        {
            _commandHandler.HandleWithdraw(command);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(new ErrorMessageDto {Message = e.Message });
        }
    }

    [HttpPost("Deposit")]
    public ActionResult<ErrorMessageDto> DepositMoneyEndpoint([FromBody] DepositMoney command)
    {
        try
        {
            _commandHandler.HandleDeposit(command);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(new ErrorMessageDto {Message = e.Message });
        }
    }


    [HttpPost("OpenAccount")]
    public ActionResult<OpenAccountDto> OpenAccountEndpoint()
    {
        string accountNumber = _commandHandler.HandleOpenAccount();
        return Ok(new OpenAccountDto{ AccountNumber = accountNumber });
    }
}