namespace DigitalMoney
{
    
    class Program
    {
        /// <summary>
        /// Entry point of the program
        /// </summary>
        public static void Main()
        {
            // Income Ledger 
            Ledger<IncomeTransaction> IncomeLedger = new Ledger<IncomeTransaction>();

            IncomeLedger.AddEntry(new IncomeTransaction(
                id: 1,
                date: DateTime.Now,
                amount: 500,
                description: "Petty cash Addition",
                source: "Main Fund"
            ));

            // Expense Ledger
            Ledger<ExpenseTransaction> ExpenseLedger = new Ledger<ExpenseTransaction>();

            ExpenseLedger.AddEntry(new ExpenseTransaction(
                id: 101,
                date: DateTime.Now,
                amount: 20,
                description: "Office stationery",
                category: "Stationery"
            ));

            ExpenseLedger.AddEntry(new ExpenseTransaction(
                id: 102,
                date: DateTime.Now,
                amount: 50,
                description: "Snacks",
                category: "Food"
            ));

            
            // Using Helper Class Functions

            decimal totalIncome = Helper.CalculateTotal(IncomeLedger.GetAllEntries());
            decimal totalExpense = Helper.CalculateTotal(ExpenseLedger.GetAllEntries());
            decimal netBalance = Helper.CalculateNetBalance(IncomeLedger.GetAllEntries(), ExpenseLedger.GetAllEntries());

            // printing the output 
            Console.WriteLine("=== PETTY CASH SUMMARY ===\n");

            Console.WriteLine($"Total Income   : Rs {totalIncome}");
            Console.WriteLine($"Total Expense  : Rs {totalExpense}");
            Console.WriteLine($"Net Balance    : Rs {netBalance}\n");

            
            Console.WriteLine("TRANSACTION DETAILS");

            // Combine all transactions from income and expense ledgers for unified display
            List<Transaction> allTransactions = new List<Transaction>();
            allTransactions.AddRange(IncomeLedger.GetAllEntries());
            allTransactions.AddRange(ExpenseLedger.GetAllEntries());

            foreach (Transaction t in allTransactions)
            {
                Console.WriteLine(t.GetSummary());
            }
        }
    }
}