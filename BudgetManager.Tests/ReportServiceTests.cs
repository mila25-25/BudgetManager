using BudgetManager.Models;
using BudgetManager.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace BudgetManager.Tests
{
    public class ReportServiceTests
    {
        [Fact]
        public void Balance_ShouldBeCorrect_AfterAddingIncomeAndExpense()
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

        [Fact]
        public void Balance_ShouldBeZero_WhenNoTransactions()
        {
            var service = new ReportService();

            var transactions = new List<Transaction>();

            var result = service.CalculateBalance(transactions);

            Assert.Equal(0m, result);
        }

        [Fact]
        public void MonthlyReport_ShouldSumIncomeCorrectly()
        {
            var service = new ReportService();

            var transactions = new List<Transaction>
            {
                new Transaction { Amount = 1000m, IsIncome = true, Date = new DateTime(2025, 3, 1) },
                new Transaction { Amount = 500m, IsIncome = true, Date = new DateTime(2025, 3, 5) },
                new Transaction { Amount = 200m, IsIncome = false, Date = new DateTime(2025, 3, 10) }
            };

            var result = service.CalculateMonthlyIncome(transactions, new DateTime(2025, 3, 1));

            Assert.Equal(1500m, result);
        }

        [Fact]
        public void MonthlyReport_ShouldSumExpensesCorrectly()
        {
            var service = new ReportService();

            var transactions = new List<Transaction>
            {
                new Transaction { Amount = 100m, IsIncome = false, Date = new DateTime(2025, 3, 1) },
                new Transaction { Amount = 50m, IsIncome = false, Date = new DateTime(2025, 3, 3) }
            };

            // ВАЖНО: расходы считаем отдельным методом
            var result = service.CalculateMonthlyExpenses(transactions, new DateTime(2025, 3, 1));

            Assert.Equal(150m, result);
        }

        [Fact]
        public void MonthlyReport_ShouldIgnoreOtherMonths()
        {
            var service = new ReportService();

            var transactions = new List<Transaction>
            {
                new Transaction { Amount = 1000m, IsIncome = true, Date = new DateTime(2025, 3, 1) },
                new Transaction { Amount = 500m, IsIncome = true, Date = new DateTime(2025, 4, 1) }
            };

            var result = service.CalculateMonthlyIncome(transactions, new DateTime(2025, 3, 1));

            Assert.Equal(1000m, result);
        }

        [Fact]
        public void MonthlyExpenses_ShouldIgnoreOtherMonths()
        {
            var service = new ReportService();

            var transactions = new List<Transaction>
            {
                new Transaction { Amount = 100m, IsIncome = false, Date = new DateTime(2025, 3, 10) },
                new Transaction { Amount = 200m, IsIncome = false, Date = new DateTime(2025, 4, 10) }
            };

            var result = service.CalculateMonthlyExpenses(transactions, new DateTime(2025, 3, 1));

            Assert.Equal(100m, result);
        }
    }
}