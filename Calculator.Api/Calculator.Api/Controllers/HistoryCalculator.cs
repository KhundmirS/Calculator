using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;
using Repository.Services;
using System.Security.Claims;

namespace Calculator.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IHistoryService  _historyService;
        public HistoryController(IHistoryService historyService)
        {
            _historyService = historyService;
        }
        [HttpGet]
        public IActionResult Evaluate()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var history = _historyService.GetHistoryByUser(userId);
            return Ok(history);

        }
    }
}
