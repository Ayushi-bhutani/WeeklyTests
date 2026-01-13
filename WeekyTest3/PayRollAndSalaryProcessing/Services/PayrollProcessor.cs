using PayrollSystem.Models;

namespace PayrollSystem.Services
{
    /// <summary>
    /// Delegate property SalaryProcessedHandler
    /// </summary>
    /// <param name="slip"></param>
    public delegate void SalaryProcessedHandler(PaySlip slip);

    public class PayrollProcessor
    {

        /// <summary>
        /// defining property SalaryProcessed
        /// </summary>
        public SalaryProcessedHandler? SalaryProcessed;

        /// <summary>
        /// defining list ProcessPayroll with IEnumerable employees
        /// </summary>
        /// <param name="employees"></param>
        /// <returns></returns>
        public List<PaySlip> ProcessPayroll(IEnumerable<Employee> employees)
        {

            
            List<PaySlip> slips = new();

            foreach (var emp in employees)
            {
                PaySlip slip = emp.GeneratePaySlip();
                slips.Add(slip);

                SalaryProcessed?.Invoke(slip); // multicast delegate
            }

            return slips;
        }
    }
}
