using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System;
using System.Windows.Controls.Primitives;

namespace BudgetManager.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Amount_LostFocus(object sender, RoutedEventArgs e)
        {
            if (sender is not TextBox tb) return;

            tb.Text = tb.Text.Replace('.', ',');

            if (string.IsNullOrWhiteSpace(tb.Text))
                tb.Text = "0";
        }
        private void Banner_ImageFailed(object sender, ExceptionRoutedEventArgs e)
        {
            MessageBox.Show(e.ErrorException?.Message ?? "ImageFailed без текста");
        }


        private void Amount_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Regex.IsMatch(e.Text, @"^[0-9\.,]+$");
        }

        private void Amount_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
                e.Handled = true;
        }

        private void Amount_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(DataFormats.Text))
            {
                var text = (string)e.DataObject.GetData(DataFormats.Text);
                if (!Regex.IsMatch(text, @"^[0-9\.,]+$"))
                    e.CancelCommand();
            }
            else
            {
                e.CancelCommand();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
        }
        private void MonthPicker_CalendarOpened(object sender, RoutedEventArgs e)
        {
            if (sender is not DatePicker dp) return;

            dp.Dispatcher.BeginInvoke(new Action(() =>
            {
                if (dp.Template.FindName("PART_Popup", dp) is not Popup popup) return;
                if (popup.Child is not Calendar cal) return;

                // Открываем сразу выбор месяцев (Year view)
                cal.DisplayMode = CalendarMode.Year;
                cal.DisplayModeChanged -= Cal_DisplayModeChanged;
                cal.DisplayModeChanged += Cal_DisplayModeChanged;
            }));
        }

        private void Cal_DisplayModeChanged(object? sender, CalendarModeChangedEventArgs e)
        {
            if (sender is not Calendar cal) return;

            // Когда пользователь выбрал месяц, календарь перейдет в Month view — мы это перехватим
            if (cal.DisplayMode == CalendarMode.Month)
            {
                // Берём выбранную дату и “обнуляем” до 1-го числа месяца
                if (cal.SelectedDate is DateTime d)
                {
                    var month = new DateTime(d.Year, d.Month, 1);

                    // Закрыть popup DatePicker
                    var dp = FindParentDatePicker(cal);
                    if (dp != null)
                    {
                        dp.SelectedDate = month;
                        dp.IsDropDownOpen = false;
                    }
                }
            }
        }

        private void MonthPicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            // На всякий случай: всегда нормализуем в 1-е число месяца
            if (sender is not DatePicker dp) return;
            if (dp.SelectedDate is DateTime d)
                dp.SelectedDate = new DateTime(d.Year, d.Month, 1);
        }

        private DatePicker? FindParentDatePicker(DependencyObject child)
        {
            DependencyObject current = child;
            while (current != null)
            {
                if (current is DatePicker dp) return dp;
                current = System.Windows.Media.VisualTreeHelper.GetParent(current);
            }
            return null;
        }
    }
}
