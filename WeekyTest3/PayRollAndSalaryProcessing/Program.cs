using PayrollSystem.Data;
using PayrollSystem.Services;
using PayrollSystem.Models;

class Program
{
    static void Main()
    {
        //loading data for store
        EmployeeStore.Seed();

        Console.WriteLine("Employees loaded from EmployeeStore.\n");


        //taking input from user and adding into the database 
        Console.WriteLine("Enter Employee data to be added ");
        Console.WriteLine("Enter no. of Employees to be added :");
        int count = int.Parse(Console.ReadLine()!);

        for (int i = 0; i < count; i++)
        {
            Console.WriteLine($"\nAdding Employee #{i + 1}");
            AddEmployeeFromConsole();
        }



        // creating object for PayrollProcessor class 
        PayrollProcessor processor = new();

        processor.SalaryProcessed += Notifications.NotifyHR;
        processor.SalaryProcessed += Notifications.NotifyFinance;
        



        var employees = EmployeeStore.GetAll();
        var slips = processor.ProcessPayroll(employees);

        Console.WriteLine("\n---- PAYROLL REPORT ----");
        decimal total = 0;

        foreach (var s in slips)
        {
            Console.WriteLine($"{s.EmployeeId} {s.Name} {s.Type} | Gross:{s.Gross} Ded:{s.Deductions} Net:{s.Net}");
            total += s.Net;
        }

        Console.WriteLine("\n---- SUMMARY ----");
        Console.WriteLine($"Total Employees : {slips.Count}");
        Console.WriteLine($"Total Payout    : {total}");
        Console.WriteLine($"Highest Salary  : {slips.Max(s => s.Net)}");
    }

    static void AddEmployeeFromConsole()
    {
        try
        {
            Console.WriteLine("1. Full Time Employee");
            Console.WriteLine("2. Contract Employee");
            Console.Write("Select type: ");
            int type = int.Parse(Console.ReadLine()!);

            Console.Write("Enter Id: ");
            int id = int.Parse(Console.ReadLine()!);

            Console.Write("Enter Name: ");
            string name = Console.ReadLine()!;

            Console.Write("Enter Department: ");
            string dept = Console.ReadLine()!;

            if (type == 1)
            {
                Console.Write("Enter Monthly Salary: ");
                decimal salary = decimal.Parse(Console.ReadLine()!);

                EmployeeStore.Add(new FullTimeEmployee(id, name, dept, salary));
            }
            else if (type == 2)
            {
                Console.Write("Enter Working Days: ");
                int days = int.Parse(Console.ReadLine()!);

                Console.Write("Enter Rate Per Day: ");
                decimal rate = decimal.Parse(Console.ReadLine()!);

                EmployeeStore.Add(new ContractEmployee(id, name, dept, days, rate));
            }
            else
            {
                Console.WriteLine("Invalid employee type.");
                return;
            }

            Console.WriteLine("Employee added successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Input Error: {ex.Message}");
        }
    }

    



}
