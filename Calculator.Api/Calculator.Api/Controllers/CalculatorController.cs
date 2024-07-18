using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repository.Models;

[ApiController]
[Route("api/[controller]")]
public class CalculatorController : ControllerBase
{
    private readonly ICalculatorService _calculatorService;
    private readonly UserManager<User> _userManager;

    public CalculatorController(ICalculatorService calculatorService, UserManager<User> userManager)
    {
        _calculatorService = calculatorService;
        _userManager = userManager;
    }

    [HttpPost("evaluate")]
    public async Task<IActionResult> Evaluate([FromBody] RequestExpression request)
    {
        var userId = _userManager.GetUserId(User);
        var result = _calculatorService.Evaluate(request.Expression);

        var calculation = new Calculation
        {
            Expression = request.Expression,
            Result = result.Result,
            TimeStamp = DateTime.UtcNow,
            UserId = userId
        };

        _calculatorService.SaveCalculation(calculation);
        return Ok(result);
    }

    [Authorize]
    [HttpGet("history")]
    public IActionResult GetHistory()
    {
        var userId = _userManager.GetUserId(User);
        var history = _calculatorService.GetHistoryByUser(userId);
        return Ok(history);
    }
}
