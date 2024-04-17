using Handler;
using Cmd;
using Microsoft.AspNetCore.Mvc;


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

    [HttpPost("withdraw")]
    public IActionResult WithdrawMoneyEndpoint([FromBody] WithdrawMoney command)
    {
        try
        {
            _commandHandler.HandleWithdraw(command);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPost("deposit")]
    public IActionResult DepositMoneyEndpoint([FromBody] DepositMoney command)
    {
        try
        {
            _commandHandler.HandleDeposit(command);
            return Ok();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }


    [HttpPost("openaccount")]
    public IActionResult OpenAccountEndpoint()
    {
        _commandHandler.HandleOpenAccount();
        return Ok("Account opened successfully!");
    }


}