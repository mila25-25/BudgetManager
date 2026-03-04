using BudgetManager.Data;
using BudgetManager.Models;
using BudgetManager.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BudgetManager.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<Transaction> Transactions { get; } = new();

        private readonly ReportService _reportService = new ReportService();
        private readonly ValidationService _validationService = new ValidationService();

        // ===== Dashboard: Monat =====
        private DateTime _selectedMonth = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
        public DateTime SelectedMonth
        {
            get => _selectedMonth;
            set
            {
                _selectedMonth = new DateTime(value.Year, value.Month, 1);
                OnPropertyChanged();
                OnPropertyChanged(nameof(MonthTitle));
                RefreshDashboard();
            }
        }

        public string MonthTitle => SelectedMonth.ToString("MMMM yyyy", new CultureInfo("de-DE"));

        private decimal _monthIncome;
        public decimal MonthIncome
        {
            get => _monthIncome;
            private set
            {
                _monthIncome = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(MonthSaldo));
            }
        }

        private decimal _monthExpense;
        public decimal MonthExpense
        {
            get => _monthExpense;
            private set
            {
                _monthExpense = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(MonthSaldo));
            }
        }

        public decimal MonthSaldo => MonthIncome - MonthExpense;

        private string _title = "";
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
                _addCommand.RaiseCanExecuteChanged();
            }
        }

        private string _amountText = "0";
        public string AmountText
        {
            get => _amountText;
            set
            {
                _amountText = value;
                OnPropertyChanged();
                _addCommand.RaiseCanExecuteChanged();
            }
        }

        private DateTime _date = DateTime.Today;
        public DateTime Date
        {
            get => _date;
            set
            {
                _date = value;
                OnPropertyChanged();
                _addCommand.RaiseCanExecuteChanged();
            }
        }

        private bool _isIncome = true;
        public bool IsIncome
        {
            get => _isIncome;
            set
            {
                _isIncome = value;
                OnPropertyChanged();
            }
        }

        private Transaction? _selectedTransaction;
        public Transaction? SelectedTransaction
        {
            get => _selectedTransaction;
            set
            {
                _selectedTransaction = value;
                OnPropertyChanged();
                _deleteCommand.RaiseCanExecuteChanged();
            }
        }

        public decimal Balance => _reportService.CalculateBalance(Transactions);

        private readonly RelayCommand _addCommand;
        public ICommand AddCommand => _addCommand;

        private readonly RelayCommand _deleteCommand;
        public ICommand DeleteSelectedCommand => _deleteCommand;

        public MainViewModel()
        {
            _addCommand = new RelayCommand(async () => await AddAsync(), CanAdd);
            _deleteCommand = new RelayCommand(async () => await DeleteAsync(), () => SelectedTransaction != null);

            _ = LoadAsync();

            Transactions.CollectionChanged += (_, __) =>
            {
                OnPropertyChanged(nameof(Balance));
                RefreshDashboard();
            };
        }

        private bool CanAdd()
        {
            if (string.IsNullOrWhiteSpace(Title))
                return false;

            if (!decimal.TryParse(AmountText, NumberStyles.Number, CultureInfo.CurrentCulture, out var amount))
                return false;

            return _validationService.IsValidAmount(amount)
                && _validationService.IsValidDate(Date);
        }

        private void RefreshDashboard()
        {
            var monthItems = Transactions.Where(t =>
                t.Date.Year == SelectedMonth.Year &&
                t.Date.Month == SelectedMonth.Month);

            MonthIncome = _reportService.CalculateMonthlyIncome(monthItems, SelectedMonth);
            MonthExpense = _reportService.CalculateMonthlyExpenses(monthItems, SelectedMonth);
        }

        private async Task LoadAsync()
        {
            try
            {
                using var db = new BudgetDbContext();
                await db.Database.MigrateAsync();

                var items = await db.Transactions
                    .OrderByDescending(t => t.Date)
                    .ToListAsync();

                Transactions.Clear();
                foreach (var item in items)
                    Transactions.Add(item);

                OnPropertyChanged(nameof(Balance));
                RefreshDashboard();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        private async Task AddAsync()
        {
            if (!CanAdd())
                return;

            // CanAdd() already validated parsing and > 0
            decimal.TryParse(AmountText, NumberStyles.Number, CultureInfo.CurrentCulture, out var amount);

            var tx = new Transaction
            {
                Title = Title.Trim(),
                Amount = amount,
                Date = Date,
                IsIncome = IsIncome
            };

            try
            {
                using var db = new BudgetDbContext();
                db.Transactions.Add(tx);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }

            Transactions.Insert(0, tx);

            Title = "";
            AmountText = "0";
            Date = DateTime.Today;
            IsIncome = true;

            OnPropertyChanged(nameof(Balance));
            RefreshDashboard();
            _addCommand.RaiseCanExecuteChanged();
        }

        private async Task DeleteAsync()
        {
            if (SelectedTransaction == null)
                return;

            var toDelete = SelectedTransaction;

            try
            {
                using var db = new BudgetDbContext();
                db.Transactions.Remove(toDelete);
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return;
            }

            Transactions.Remove(toDelete);
            SelectedTransaction = null;

            OnPropertyChanged(nameof(Balance));
            RefreshDashboard();
            _deleteCommand.RaiseCanExecuteChanged();
        }
    }
}