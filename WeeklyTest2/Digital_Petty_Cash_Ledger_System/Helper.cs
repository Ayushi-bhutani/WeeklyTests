namespace DigitalMoney
{
    // ===============================
    // HELPER CLASS
    // ===============================
    public static class Helper
    {
        /// <summary>
        /// External Static Class for Calculations 

        /// </summary>

        // Calculate total amount for any list of transactions
        public static decimal CalculateTotal<T>(List<T> transactions) where T : Transaction
        {
            decimal total = 0;

            foreach (T t in transactions)
            {
                total += t.Amount;
            }

            return total;
        }

        // Calculate net balance (Income - Expense)
        public static decimal CalculateNetBalance(List<IncomeTransaction> incomes, List<ExpenseTransaction> expenses)
        {
            decimal totalIncome = CalculateTotal(incomes);
            decimal totalExpense = CalculateTotal(expenses);

            return totalIncome - totalExpense;
        }
    }
}
