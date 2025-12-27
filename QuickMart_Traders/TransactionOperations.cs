using System;

namespace QuickMart
{
    public class TransactionOperations
    {
        private static SaleTransaction? LastTransaction;
        private static bool HasLastTransaction = false;

        // ------- CREATE TRANSACTION -------
        public void CreateTransaction()
        {
            SaleTransaction tx = new SaleTransaction();

            Console.Write("Enter Invoice No: ");
            tx.InvoiceNo = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(tx.InvoiceNo))
            {
                Console.WriteLine("Invoice No cannot be empty.");
                return;
            }

            Console.Write("Enter Customer Name: ");
            tx.CustomerName = Console.ReadLine();

            Console.Write("Enter Item Name: ");
            tx.ItemName = Console.ReadLine();

            Console.Write("Enter Quantity: ");
            if (!int.TryParse(Console.ReadLine(), out int qty) || qty <= 0)
            {
                Console.WriteLine("Quantity must be greater than 0.");
                return;
            }
            tx.Quantity = qty;

            Console.Write("Enter Purchase Amount (total): ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal purchase) || purchase <= 0)
            {
                Console.WriteLine("Purchase Amount must be greater than 0.");
                return;
            }
            tx.PurchaseAmount = purchase;

            Console.Write("Enter Selling Amount (total): ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal selling) || selling < 0)
            {
                Console.WriteLine("Selling Amount must be 0 or more.");
                return;
            }
            tx.SellingAmount = selling;

            Compute(tx);

            LastTransaction = tx;
            HasLastTransaction = true;

            Console.WriteLine("\nTransaction saved successfully.");
            PrintResults(tx);
        }

        // ------- VIEW LAST -------
        public void ViewLastTransaction()
        {
            if (!HasLastTransaction || LastTransaction == null)
            {
                Console.WriteLine("No transaction available. Please create a new transaction first.");
                return;
            }

            Console.WriteLine("\n-------------- Last Transaction --------------");
            Console.WriteLine($"InvoiceNo: {LastTransaction.InvoiceNo}");
            Console.WriteLine($"Customer: {LastTransaction.CustomerName}");
            Console.WriteLine($"Item: {LastTransaction.ItemName}");
            Console.WriteLine($"Quantity: {LastTransaction.Quantity}");
            Console.WriteLine($"Purchase Amount: {LastTransaction.PurchaseAmount:F2}");
            Console.WriteLine($"Selling Amount: {LastTransaction.SellingAmount:F2}");
            Console.WriteLine($"Status: {LastTransaction.ProfitOrLossStatus}");
            Console.WriteLine($"Profit/Loss Amount: {LastTransaction.ProfitOrLossAmount:F2}");
            Console.WriteLine($"Profit Margin (%): {LastTransaction.ProfitMarginPercent:F2}");
            Console.WriteLine("--------------------------------------------");
        }

        // ------- RECALCULATE -------
        public void Recalculate()
        {
            if (!HasLastTransaction || LastTransaction == null)
            {
                Console.WriteLine("No transaction available. Please create a new transaction first.");
                return;
            }

            Compute(LastTransaction);
            PrintResults(LastTransaction);
        }

        // ------- HELPER: CALCULATE -------
        private void Compute(SaleTransaction tx)
        {
            if (tx.SellingAmount > tx.PurchaseAmount)
            {
                tx.ProfitOrLossStatus = "PROFIT";
                tx.ProfitOrLossAmount = tx.SellingAmount - tx.PurchaseAmount;
            }
            else if (tx.SellingAmount < tx.PurchaseAmount)
            {
                tx.ProfitOrLossStatus = "LOSS";
                tx.ProfitOrLossAmount = tx.PurchaseAmount - tx.SellingAmount;
            }
            else
            {
                tx.ProfitOrLossStatus = "BREAK-EVEN";
                tx.ProfitOrLossAmount = 0;
            }

            tx.ProfitMarginPercent = (tx.ProfitOrLossAmount / tx.PurchaseAmount) * 100;
        }

        // ------- HELPER: PRINT -------
        private void PrintResults(SaleTransaction tx)
        {
            Console.WriteLine($"Status: {tx.ProfitOrLossStatus}");
            Console.WriteLine($"Profit/Loss Amount: {tx.ProfitOrLossAmount:F2}");
            Console.WriteLine($"Profit Margin (%): {tx.ProfitMarginPercent:F2}");
            Console.WriteLine("------------------------------------------------------");
        }
    }
}
