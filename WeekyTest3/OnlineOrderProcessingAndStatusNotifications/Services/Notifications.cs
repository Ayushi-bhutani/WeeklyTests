using OrderSystem.Models;

namespace OrderSystem.Services
{
    public static class Notifications
    {
        /// <summary>
        /// method NotifyCustomer which notifies customer about order id and status 
        /// </summary>
        /// <param name="o"></param>
        /// <param name="oldS"></param>
        /// <param name="newS"></param>
        public static void NotifyCustomer(Order o, OrderStatus oldS, OrderStatus newS)
        {
            Console.WriteLine($"[Customer] Order #{o.Id} is now {newS}");
        }


        /// <summary>
        /// static method NotifyLogistics to notify if order is dispatched
        /// </summary>
        /// <param name="o"></param>
        /// <param name="oldS"></param>
        /// <param name="newS"></param>
        public static void NotifyLogistics(Order o, OrderStatus oldS, OrderStatus newS)
        {
            if (newS == OrderStatus.Shipped)
                Console.WriteLine($"[Logistics] Dispatch Order #{o.Id}");
        }
    }
}
