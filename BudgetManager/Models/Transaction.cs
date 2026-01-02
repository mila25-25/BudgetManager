using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetManager.Models
{
    public class Transaction
    {
        public int Id { get; set; }                 // позже пригодится для БД
        public string Title { get; set; } = "";
        public decimal Amount { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public bool IsIncome { get; set; }          // true = доход, false = расход
    }
}