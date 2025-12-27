using System;

namespace QuickMart
{
    public class Program
    {
        //entry point of execution
        public static void Main(string[] args)
        {

            // creating an object 'ops' of TransactionOperations class 
            TransactionOperations ops = new TransactionOperations();
            int choice;

            do
            {
                Console.WriteLine("\n================== QuickMart Traders ==================");
                Console.WriteLine("1. Create New Transaction (Enter Purchase & Selling Details)");
                Console.WriteLine("2. View Last Transaction");
                Console.WriteLine("3. Calculate Profit/Loss (Recompute & Print)");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your option: ");

                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1: 
                        ops.CreateTransaction(); break;
                    case 2: 
                        ops.ViewLastTransaction(); break;
                    case 3: 
                        ops.Recalculate(); break;
                    case 4: 
                        Console.WriteLine("Thank you. Application closed normally."); break;
                    default:
                        Console.WriteLine("Invalid option. Please choose between 1–4.");
                        break;
                }

            } while (choice != 4);
        }
    }
}
