using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks.Dataflow;

namespace store {
    public class BookUtility
    {
        Book book = new Book();
        public void GetBookDetails()
        {
            Console.WriteLine($"{book.Id} {book.Title} {book.Price} {book.Stock}");
        }

        public void UpdateBookPrice(int newPrice)
        {
            Console.WriteLine($"Updated price: {newPrice}");
        }
        public void UpdateBookPrice(int newStock)
        {
            Console.WriteLine($"Updated Stock: {newStock}");
        }

    }
}