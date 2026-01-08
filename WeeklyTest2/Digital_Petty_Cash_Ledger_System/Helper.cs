using System.Collections.Generic;
using System.Linq;

namespace DigitalMoney
{
    /// <summary>
    /// Static helper class responsible only for calculations.
    /// </summary>
    public static class LedgerCalculator
    {
        public static decimal CalculateTotal<T>(IEnumerable<T> transactions)
            where T : Transaction =>
            transactions.Sum(t => t.Amount);

        public static decimal CalculateNetBalance(
            IEnumerable<IncomeTransaction> incomes,
            IEnumerable<ExpenseTransaction> expenses)
        {
            return CalculateTotal(incomes) - CalculateTotal(expenses);
        }
    }
}
