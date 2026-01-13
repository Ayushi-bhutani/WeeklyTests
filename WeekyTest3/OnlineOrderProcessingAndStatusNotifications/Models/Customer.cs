namespace OrderSystem.Models
{
    public class Customer
    {

        /// <summary>
        /// property ID of customer class 
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// property Name for customer class 
        /// </summary>
        public string Name { get; }


        /// <summary>
        /// defining parameterised constructor for Customer class 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
