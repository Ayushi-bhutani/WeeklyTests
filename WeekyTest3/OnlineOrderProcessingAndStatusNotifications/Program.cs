using OrderSystem.Models;
using OrderSystem.Data;
using OrderSystem.Services;

class Program
{

    /// <summary>
    /// entry point of program
    /// </summary>
    static void Main()
    {

        // loading seed i.e database file 
        ProductStore.Seed();


        //creating objects for Customer class 
        Customer c1 = new(1, "Riya");
        Customer c2 = new(2, "Aman");


        //creating o1 object for Order class 
        Order o1 = new(101, c1);
        o1.AddItem(ProductStore.Get(1), 1);
        o1.AddItem(ProductStore.Get(2), 2);

        //creating o2 object for Order class 
        Order o2 = new(102, c2);
        o2.AddItem(ProductStore.Get(3), 1);
        o2.AddItem(ProductStore.Get(5), 1);

        //adding orders to store database
        OrderStore.Add(o1);
        OrderStore.Add(o2);

        //creating object for OrderService class 
        OrderService service = new();

        //calling StatusChanged function and NotifyCustomer and NotifyLogistics functions 
        service.StatusChanged += Notifications.NotifyCustomer;
        service.StatusChanged += Notifications.NotifyLogistics;

        //calling UpdateStatus method with different status 
        service.UpdateStatus(o1, OrderStatus.Paid);
        service.UpdateStatus(o1, OrderStatus.Packed);
        service.UpdateStatus(o1, OrderStatus.Shipped);
        service.UpdateStatus(o1, OrderStatus.Delivered);

        Console.WriteLine("\n---- REPORT ----");
        foreach (var o in OrderStore.GetAll())
        {
            Console.WriteLine($"Order #{o.Id} | {o.Customer.Name} | Total: {o.Total()} | Status: {o.Status}");
            foreach (var h in o.History)
                Console.WriteLine($"  {h.OldStatus} -> {h.NewStatus} at {h.Time}");
        }
    }
}
