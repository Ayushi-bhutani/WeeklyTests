namespace PayrollSystem.Models
{
    public class ContractEmployee : Employee
    {
        /// <summary>
        /// WorkingDays property of a ContractEmployee
        /// </summary>
        public int WorkingDays { get; }

        /// <summary>
        /// RatePerDay property of a ContractEmployee
        /// </summary>
        public decimal RatePerDay { get; }

        /// <summary>
        /// ContractEmployee constructor with parameters 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="dept"></param>
        /// <param name="days"></param>
        /// <param name="rate"></param>
        /// <exception cref="ArgumentException"></exception>
        public ContractEmployee(int id, string name, string dept, int days, decimal rate)
            : base(id, name, dept)
        {
            if (days < 0 || days > 31) throw new ArgumentException("Invalid days.");
            if (rate < 0) throw new ArgumentException("Rate cannot be negative.");

            WorkingDays = days;
            RatePerDay = rate;
        }

        /// <summary>
        /// method to calculate gross salary defined in abstract class Employee
        /// </summary>
        /// <returns></returns>
        public override decimal CalculateGrossSalary()
        {
            return WorkingDays * RatePerDay;
        }

        /// <summary>
        /// method to calculate deductions
        /// </summary>
        /// <param name="gross"></param>
        /// <returns></returns>
        public override decimal CalculateDeductions(decimal gross)
        {
            return gross * 0.05m; // lower tax
        }
    }
}
