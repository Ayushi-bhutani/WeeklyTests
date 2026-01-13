using OrderSystem.Models;

namespace OrderSystem.Data
{
    


    /// <summary>
    /// defining static class OrderStore 
    /// </summary>
    public static class OrderStore
    {
        /// <summary>
        /// Dictionary which stores all order details
        /// </summary>
        private static readonly Dictionary<int, Order> _orders = new();

        /// <summary>
        /// method to define Addfunction for adding orders 
        /// </summary>
        /// <param name="o"></param>
        public static void Add(Order o) => _orders[o.Id] = o;

        /// <summary>
        /// static method to get all order values
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Order> GetAll() => _orders.Values;
    }
}
