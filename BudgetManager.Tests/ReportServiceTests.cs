using System.Collections.Generic;
using BudgetManager.Models;
using BudgetManager.Services;
using Xunit;

namespace BudgetManager.Tests
{
    public class ReportServiceTests
    {
        [Fact]
        public void CalculateBalance_ShouldReturnCorrectBalance()
        {
            var service = new ReportService();

            var transactions = new List<Transaction>
            {
                new Transaction { Amount = 1000m, IsIncome = true },
                new Transaction { Amount = 200m, IsIncome = false }
            };

            var result = service.CalculateBalance(transactions);

            Assert.Equal(800m, result);
        }
    }
}