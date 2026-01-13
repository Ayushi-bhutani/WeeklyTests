namespace OrderSystem.Models
{
    public class Order
    {

        /// <summary>
        /// defining property ID for order class 
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// defining property Customer using Customer class property inside order class 
        /// </summary>
        public Customer Customer { get; }

        /// <summary>
        /// defining List Items using OrderItem class 
        /// </summary>
        public List<OrderItem> Items { get; } = new();

        /// <summary>
        /// defining Status property which is private from the OrderStatus class 
        /// </summary>
        public OrderStatus Status { get; private set; } = OrderStatus.Created;

        /// <summary>
        /// defining List History using OrderStatusLog class property
        /// </summary>
        public List<OrderStatusLog> History { get; } = new();


        /// <summary>
        /// defining parameterised constructor for Order class 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="cust"></param>
        public Order(int id, Customer cust)
        {
            Id = id;
            Customer = cust;
        }


        /// <summary>
        /// defining method AddItem which returns nothing
        /// </summary>
        /// <param name="p"></param>
        /// <param name="qty"></param>
        public void AddItem(Product p, int qty)
        {
            Items.Add(new OrderItem(p, qty));
        }


        /// <summary>
        /// defining method Total which returns sum of all items 
        /// </summary>
        /// <returns></returns>
        public decimal Total()
        {
            return Items.Sum(i => i.SubTotal);
        }


        /// <summary>
        /// defining ChangeStatus method which has parameter called from OrderStatus class object
        /// </summary>
        /// <param name="newStatus"></param>
        public void ChangeStatus(OrderStatus newStatus)
        {
            History.Add(new OrderStatusLog(Status, newStatus));
            Status = newStatus;
        }
    }
}
