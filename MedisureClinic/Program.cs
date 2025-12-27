using System;

namespace MediSure
{
    public class Program
    {

        //Entry Point of execution
        public static void Main(string[] args)
        {

            // creating and object ops for BillingOperations class to call its methods
            BillingOperations ops = new BillingOperations();

            int choice;

            do
            {
                Console.WriteLine("\n================== MediSure Clinic Billing ==================");
                Console.WriteLine("1. Create New Bill (Enter Patient Details)");
                Console.WriteLine("2. View Last Bill");
                Console.WriteLine("3. Clear Last Bill");
                Console.WriteLine("4. Exit");

                Console.Write("Enter your choice: ");

                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        ops.CreateBill(); break;
                    case 2: 
                        ops.ViewLastBill(); break;
                    case 3: 
                        ops.ClearLastBill(); break;
                    case 4: 
                        Console.WriteLine("Thank you. Application closed normally."); break;
                    default:
                        Console.WriteLine("Invalid option. Please select between (1–4).");
                        break;
                }

            } while (choice != 4);
        }
    }
}
