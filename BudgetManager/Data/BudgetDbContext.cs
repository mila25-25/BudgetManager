using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManager.Models;


namespace BudgetManager.Data
{
    public class BudgetDbContext : DbContext
    {
        public DbSet<Transaction> Transactions { get; set; }

        public BudgetDbContext() { }

        public BudgetDbContext(DbContextOptions<BudgetDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlite("Data Source=budget.db");
        }
    }
}