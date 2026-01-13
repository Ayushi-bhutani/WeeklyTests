namespace OrderSystem.Models
{
    public class Product
    {

        /// <summary>
        /// property ID for product class 
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// property Name for product class 
        /// </summary>
        public string Name { get; }


        /// <summary>
        /// property Price for product class 
        /// </summary>
        public decimal Price { get; }


        /// <summary>
        /// defining parameterised constructor for product class 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="price"></param>
        /// <exception cref="ArgumentException"></exception>

        public Product(int id, string name, decimal price)
        {
            if (price < 0) throw new ArgumentException("Price cannot be negative.");
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
