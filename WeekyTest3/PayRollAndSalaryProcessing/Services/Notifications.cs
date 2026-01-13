using PayrollSystem.Models;

namespace PayrollSystem.Services
{
    public static class Notifications
    {

        /// <summary>
        /// method defined for notifying HR returns nothing
        /// </summary>
        /// <param name="slip"></param>
        public static void NotifyHR(PaySlip slip)
        {
            Console.WriteLine($"[HR] Salary processed for {slip.Name} ({slip.Type})");
        }

        /// <summary>
        /// method defined for notifying finance returns nothing
        /// </summary>
        /// <param name="slip"></param>
        public static void NotifyFinance(PaySlip slip)
        {
            Console.WriteLine($"[Finance] Net Pay = {slip.Net:C} for EmpId {slip.EmployeeId}");
        }
    }
}
