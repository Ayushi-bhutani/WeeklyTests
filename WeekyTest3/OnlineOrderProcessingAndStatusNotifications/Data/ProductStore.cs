using OrderSystem.Models;

namespace OrderSystem.Data
{
    public static class ProductStore
    {

        /// <summary>
        /// defining Dictionary containing all Product details
        /// </summary>
        private static readonly Dictionary<int, Product> _products = new();


        /// <summary>
        /// defining Seed which is a form of dataset
        /// </summary>
        public static void Seed()
        {
            Add(new Product(1, "Laptop", 50000));
            Add(new Product(2, "Mouse", 500));
            Add(new Product(3, "Keyboard", 1200));
            Add(new Product(4, "Headset", 1500));
            Add(new Product(5, "Monitor", 8000));
        }

        /// <summary>
        /// static method to define Add functionality
        /// </summary>
        /// <param name="p"></param>
        public static void Add(Product p) => _products[p.Id] = p;

        /// <summary>
        /// static method to get all products 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static Product Get(int id) => _products[id];
    }
}
