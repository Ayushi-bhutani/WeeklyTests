using System;
using System.Collections.Generic;
using System.Linq;

namespace DigitalMoney
{
    /// <summary>
    /// Generic ledger storing transactions in memory.
    /// </summary>
    public class Ledger<T> where T : Transaction
    {
        private readonly List<T> entries = new();

        /// <summary>
        /// Adds a transaction entry.
        /// </summary>
        public void AddEntry(T entry) => entries.Add(entry);

        /// <summary>
        /// Returns transactions matching the given date.
        /// </summary>
        public List<T> GetTransactionByDate(DateTime date) =>
            entries.Where(e => e.Date.Date == date.Date).ToList();

        /// <summary>
        /// Returns all entries as read-only collection (safe).
        /// </summary>
        public IReadOnlyList<T> GetAllEntries() => entries.AsReadOnly();
    }
}
