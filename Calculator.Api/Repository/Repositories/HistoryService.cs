using System.Collections.Generic;
using System.Linq;
using CalculatorApp.Data;
using Repository.Models;
using Repository.Services;

namespace CalculatorApp.Services
{
    public class HistoryService : IHistoryService
    {
        private readonly ApplicationDbContext _context;

        public HistoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Calculation> GetHistoryByUser(string userId)
        {
            return _context.Calculations.Where(c => c.UserId == userId).ToList();
        }
    }
}
