

using Microsoft.AspNetCore.Mvc;
using ReadModel;

namespace Controller;
    [ApiController]
    [Route("v1/query/[controller]")]
public class HistoryController : ControllerBase
{
    private readonly HistoryModel _historyModel;

    public HistoryController(HistoryModel historyModel)
    {
        _historyModel = historyModel;
    }
    
    [HttpGet("history/{accountNumber}")]
    public ActionResult<Transaction[]> GetHistory(string accountNumber)
    {
        try
        {
            List<Transaction> history = _historyModel.GetHistory(accountNumber);

            if (history.Count == 0)
            {
                return NotFound("Account not found");
            }

            return Ok(history);
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occured: {ex.Message}");
        }
    }

}