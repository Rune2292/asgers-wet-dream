
using System.Text.Json;
using Handler;
using Cmd;
using Microsoft.AspNetCore.Mvc;


namespace Controller
{
    [Route("v1/[controller]/deposit")]
    [ApiController]
    public class CmdController : ControllerBase
    {
        private readonly CommandHandler _commandHandler;

        public CmdController(CommandHandler commandHandler)
        {
            _commandHandler = commandHandler;
        }

        [HttpPost] 
        public async Task<IActionResult> DepositMoneyBogo([FromBody] DepositMoney command)
        {  
            try
            {
                await _commandHandler.HandleDeposit(command);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        
    }
}

    