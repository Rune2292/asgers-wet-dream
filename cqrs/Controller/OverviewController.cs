using Microsoft.AspNetCore.Mvc;
using ReadModel;

namespace Controller;

[ApiController]
[Route("v1/query/[controller]")]
public class OverviewController : ControllerBase
{
    private readonly OverviewModel _overviewModel;

    public OverviewController(OverviewModel overviewModel)
    {
        _overviewModel = overviewModel;
    }

    [HttpGet("balance/{accountNumber}")]
    public IActionResult GetBalance(string accountNumber)
    {
        try
        {
            int balance = _overviewModel.GetBalance(accountNumber);

            return Ok(new { AccountNumber = accountNumber, Balance = balance });
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occured: {ex.Message}");
        }
    }
}