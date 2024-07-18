using CalculatorApp.Data;
using Repository.Models;
using System.Data;

public interface ICalculatorService
{
    CalculationResponse Evaluate(string expression);
    void SaveCalculation(Calculation calculation);
    IEnumerable<Calculation> GetHistoryByUser(string userId);
}


