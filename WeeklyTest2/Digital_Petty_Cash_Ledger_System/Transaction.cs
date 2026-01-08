using System;

namespace DigitalMoney
{
    /// <summary>
    /// Abstract base class representing a generic transaction.
    /// </summary>
    public abstract class Transaction : IReportable
    {
        public int Id { get; private set; }
        public DateTime Date { get; private set; }
        public decimal Amount { get; private set; }
        public string Description { get; private set; }

        protected Transaction(int id, DateTime date, decimal amount, string description)
        {
            if (amount <= 0)
                throw new ArgumentException("Amount must be positive.");

            if (string.IsNullOrWhiteSpace(description))
                throw new ArgumentException("Description is required.");

            Id = id;
            Date = date;
            Amount = amount;
            Description = description;
        }

        /// <summary>
        /// All transactions must provide a formatted summary.
        /// </summary>
        public abstract string GetSummary();

        public override string ToString() => GetSummary();
    }


    /// <summary>
    /// Represents a spending transaction.
    /// </summary>
    public class ExpenseTransaction : Transaction
    {
        public string Category { get; private set; }

        public ExpenseTransaction(int id, DateTime date, decimal amount,
                                  string description, string category)
            : base(id, date, amount, description)
        {
            Category = category;
        }

        public override string GetSummary()
        {
            return $"[EXPENSE] Rs {Amount} | {Category} | {Description} | {Date:d}";
        }
    }


    /// <summary>
    /// Represents money added into petty cash.
    /// </summary>
    public class IncomeTransaction : Transaction
    {
        public string Source { get; private set; }

        public IncomeTransaction(int id, DateTime date, decimal amount,
                                 string description, string source)
            : base(id, date, amount, description)
        {
            Source = source;
        }

        public override string GetSummary()
        {
            return $"[INCOME] Rs {Amount} | Source: {Source} | {Description} | {Date:d}";
        }
    }
}
