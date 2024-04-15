
using cqrs.Handler;
using Microsoft.AspNetCore.Mvc;


namespace Controller
{
    [Route("v1/call")]
    [ApiController]

    public class CmdController : ControllerBase
    {
        [HttpPost] 
        public async Task<IActionResult> DispatchCommand([FromBody] object command)
        {            
            //Dispatch command to the command handler
            
            return Ok();
        }

}

    