using Microsoft.AspNetCore.Mvc;
using ReadModel;

namespace Controller;

[ApiController]
[Route("v1/Query/[controller]")]
public class HistoryController : ControllerBase
{
    private readonly HistoryModel _historyModel;

    public HistoryController(HistoryModel historyModel)
    {
        _historyModel = historyModel;
    }
    
    [HttpGet("{accountNumber}")]
    public ActionResult<Transaction[]> GetHistory(string accountNumber)
    {
        try
        {
            List<Transaction> history = _historyModel.GetHistory(accountNumber);

            return Ok(history);
        }
        catch (Exception ex)
        {
            return BadRequest($"An error occured: {ex.Message}");
        }
    }

}