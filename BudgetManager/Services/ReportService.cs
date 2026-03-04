using System;
using System.Collections.Generic;
using System.Linq;
using BudgetManager.Models;

namespace BudgetManager.Services
{
    public class ReportService
    {
        public decimal CalculateBalance(IEnumerable<Transaction> transactions)
        {
            return transactions.Sum(t => t.IsIncome ? t.Amount : -t.Amount);
        }

        public decimal CalculateMonthlyIncome(IEnumerable<Transaction> transactions, DateTime month)
        {
            return transactions
                .Where(t => t.Date.Year == month.Year &&
                            t.Date.Month == month.Month &&
                            t.IsIncome)
                .Sum(t => t.Amount);
        }

        public decimal CalculateMonthlyExpenses(IEnumerable<Transaction> transactions, DateTime month)
        {
            return transactions
                .Where(t => t.Date.Year == month.Year &&
                            t.Date.Month == month.Month &&
                            !t.IsIncome)
                .Sum(t => t.Amount);
        }
    }
}