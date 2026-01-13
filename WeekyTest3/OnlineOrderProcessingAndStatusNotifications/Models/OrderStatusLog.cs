namespace OrderSystem.Models
{

    /// <summary>
    /// defining OrderStatusLog class 
    /// </summary>
    public class OrderStatusLog
    {

        /// <summary>
        /// defining property OldStatus
        /// </summary>
        public OrderStatus OldStatus { get; }

        /// <summary>
        /// defining property NewStatus
        /// </summary>
        public OrderStatus NewStatus { get; }


        /// <summary>
        /// defining DateTime datatype for Time property of OrderStatusLOg
        /// </summary>
        public DateTime Time { get; }



        /// <summary>
        /// defining constructor OrderStatusLog
        /// </summary>
        /// <param name="oldS"></param>
        /// <param name="newS"></param>
        public OrderStatusLog(OrderStatus oldS, OrderStatus newS)
        {
            OldStatus = oldS;
            NewStatus = newS;
            Time = DateTime.Now;
        }
    }
}
