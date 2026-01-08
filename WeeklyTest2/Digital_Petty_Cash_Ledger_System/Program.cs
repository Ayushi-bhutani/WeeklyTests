using System;
using System.Collections.Generic;

namespace DigitalMoney
{
    class Program
    {
        /// <summary>
        /// Entry point of the application.
        /// Demonstrates how the ledger system works.
        /// </summary>
        public static void Main()
        {
            // Create separate ledgers for incomes and expenses
            var incomeLedger = new Ledger<IncomeTransaction>();
            var expenseLedger = new Ledger<ExpenseTransaction>();

            // ----- Add Sample Income -----
            incomeLedger.AddEntry(new IncomeTransaction(
                id: 1,
                date: DateTime.Now,
                amount: 500,
                description: "Petty cash addition",
                source: "Main Fund"
            ));

            // ----- Add Sample Expenses -----
            expenseLedger.AddEntry(new ExpenseTransaction(
                id: 101,
                date: DateTime.Now,
                amount: 20,
                description: "Office stationery",
                category: "Stationery"
            ));

            expenseLedger.AddEntry(new ExpenseTransaction(
                id: 102,
                date: DateTime.Now,
                amount: 50,
                description: "Snacks",
                category: "Food"
            ));

            // ----- Perform Calculations using STATIC helper -----
            decimal totalIncome  = LedgerCalculator.CalculateTotal(incomeLedger.GetAllEntries());
            decimal totalExpense = LedgerCalculator.CalculateTotal(expenseLedger.GetAllEntries());
            decimal netBalance   = LedgerCalculator.CalculateNetBalance(
                                        incomeLedger.GetAllEntries(),
                                        expenseLedger.GetAllEntries());

            // ----- Display Summary -----
            ReportPrinter.PrintSummary(totalIncome, totalExpense, netBalance);

            // Combine transactions for unified view
            List<Transaction> all = new();
            all.AddRange(incomeLedger.GetAllEntries());
            all.AddRange(expenseLedger.GetAllEntries());

            // ----- Display Detailed Transactions -----
            ReportPrinter.PrintTransactions(all);
        }
    }
}
