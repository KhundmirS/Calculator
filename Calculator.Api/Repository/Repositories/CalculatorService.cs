using CalculatorApp.Data;
using Repository.Models;
using Repository.Services;
using System;
using System.Data;

namespace CalculatorApp.Services
{
    public class CalculatorService : ICalculatorService
    {
        private readonly ApplicationDbContext _context;

        public CalculatorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public CalculationResponse Evaluate(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
            {
                throw new ArgumentException("Expression cannot be empty");
            }

            try
            {
                
                    // Use DataTable to evaluate the expression
                    var result = new DataTable().Compute(expression, null);

                    // Return the result as a string
                    return new CalculationResponse() { Id = Guid.NewGuid().ToString(), TimeStamp = DateTime.Now, Expression = expression, Result = result.ToString() };
                
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Invalid expression", ex);
            }
        }

        public void SaveCalculation(Calculation calculation)
        {
            _context.Calculations.Add(calculation);
            _context.SaveChanges();
        }

        public IEnumerable<Calculation> GetHistoryByUser(string userId)
        {
            return _context.Calculations.Where(c => c.UserId == userId).ToList();
        }
    }
}
