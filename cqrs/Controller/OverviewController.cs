using Microsoft.AspNetCore.Mvc;
using ReadModel;
using Dto;

namespace Controller;

[ApiController]
[Route("v1/Query/[controller]")]
public class OverviewController : ControllerBase
{
    private readonly OverviewModel _overviewModel;

    public OverviewController(OverviewModel overviewModel)
    {
        _overviewModel = overviewModel;
    }

    [HttpGet("{accountNumber}")]
    public ActionResult<CurrentBalanceDto> GetBalance(string accountNumber)
    {
        try
        {
            int balance = _overviewModel.GetBalance(accountNumber);

            return Ok(new CurrentBalanceDto{ CurrentBalance = balance});
        }
        catch (Exception ex)
        {
            return BadRequest(new ErrorMessageDto { Error = ex.Message });
        }
    }
}