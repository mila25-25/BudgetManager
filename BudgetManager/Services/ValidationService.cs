using System;

namespace BudgetManager.Services
{
    public class ValidationService
    {
        public bool IsValidTitle(string? title)
        {
            return !string.IsNullOrWhiteSpace(title);
        }

        public bool IsValidAmount(decimal amount)
        {
            return amount > 0;
        }

        public bool IsValidDate(DateTime date)
        {
            return date <= DateTime.Today;
        }
    }
}