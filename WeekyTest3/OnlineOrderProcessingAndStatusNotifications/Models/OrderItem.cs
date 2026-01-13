namespace OrderSystem.Models
{

    /// <summary>
    /// class OrderItem is a user defined datatype which can be used by other classes while defining their properties
    /// </summary>
    public class OrderItem
    {

        /// <summary>
        /// defining property Product using Product datatype class 
        /// </summary>
        public Product Product { get; }

        /// <summary>
        /// defining Quantity property
        /// </summary>
        public int Quantity { get; }


        /// <summary>
        /// defining SubTotal which returns total 
        /// </summary>
        public decimal SubTotal => Product.Price * Quantity;


        /// <summary>
        /// defining constructor for OrderItem class  
        /// </summary>
        /// <param name="product"></param>
        /// <param name="qty"></param>
        /// <exception cref="ArgumentException"></exception>
        public OrderItem(Product product, int qty)
        {
            if (qty <= 0) throw new ArgumentException("Quantity must be positive.");
            Product = product;
            Quantity = qty;
        }
    }
}
