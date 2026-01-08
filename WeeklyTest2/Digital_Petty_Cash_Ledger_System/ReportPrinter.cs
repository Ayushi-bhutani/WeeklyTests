using System;
using System.Collections.Generic;

namespace DigitalMoney
{
    /// <summary>
    /// Handles all formatted console output.
    /// Keeps UI separate from business logic.
    /// </summary>
    public static class ReportPrinter
    {
        public static void PrintSummary(decimal income, decimal expense, decimal balance)
        {
            Console.WriteLine("=== PETTY CASH SUMMARY ===");
            Console.WriteLine($"Total Income   : Rs {income}");
            Console.WriteLine($"Total Expense  : Rs {expense}");
            Console.WriteLine($"Net Balance    : Rs {balance}\n");
        }

        public static void PrintTransactions(IEnumerable<Transaction> transactions)
        {
            Console.WriteLine("TRANSACTION DETAILS");
            foreach (var t in transactions)
                Console.WriteLine(t);
        }
    }
}
