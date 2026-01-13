using OrderSystem.Models;

namespace OrderSystem.Services
{

    /// <summary>
    /// delegate property StatusChangedHandler 
    /// </summary>
    /// <param name="order"></param>
    /// <param name="oldS"></param>
    /// <param name="newS"></param>
    public delegate void StatusChangedHandler(Order order, OrderStatus oldS, OrderStatus newS);


    /// <summary>
    /// defining class OrderService
    /// </summary>
    public class OrderService
    {

        /// <summary>
        /// defining property StatusChanged property inside OrderService class 
        /// </summary>
        public StatusChangedHandler? StatusChanged;


        /// <summary>
        /// dictionary rules which has order status 
        /// </summary>
        private readonly Dictionary<OrderStatus, OrderStatus[]> _rules = new()
        {
            { OrderStatus.Created, new[]{ OrderStatus.Paid, OrderStatus.Cancelled } },
            { OrderStatus.Paid, new[]{ OrderStatus.Packed } },
            { OrderStatus.Packed, new[]{ OrderStatus.Shipped } },
            { OrderStatus.Shipped, new[]{ OrderStatus.Delivered } }
        };


        /// <summary>
        /// method UpdateStatus for updating status of order
        /// </summary>
        /// <param name="order"></param>
        /// <param name="newStatus"></param>
        public void UpdateStatus(Order order, OrderStatus newStatus)
        {
            if (!_rules.ContainsKey(order.Status) || !_rules[order.Status].Contains(newStatus))
            {
                Console.WriteLine($"ERROR: Invalid transition {order.Status} -> {newStatus}");
                return;
            }

            var old = order.Status;
            order.ChangeStatus(newStatus);

            //Callback function 
            StatusChanged?.Invoke(order, old, newStatus);
        }
    }
}
