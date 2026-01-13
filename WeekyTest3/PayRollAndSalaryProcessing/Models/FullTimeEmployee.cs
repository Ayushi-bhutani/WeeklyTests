namespace PayrollSystem.Models
{

    /// <summary>
    /// class FullTimeEmployee inheriting from Employee class 
    /// </summary>
    public class FullTimeEmployee : Employee
    {

        /// <summary>
        /// defining property MonthlySalary
        /// </summary>
        public decimal MonthlySalary { get; }


        /// <summary>
        /// constructor FullTimeEmployee with parameters 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="dept"></param>
        /// <param name="salary"></param>
        /// <exception cref="ArgumentException"></exception>
        public FullTimeEmployee(int id, string name, string dept, decimal salary)
            : base(id, name, dept)
        {
            if (salary < 0) throw new ArgumentException("Salary cannot be negative.");
            MonthlySalary = salary;
        }


        /// <summary>
        /// method to CalculateGrossSalary defined in abstract class Employee
        /// </summary>
        /// <returns></returns>
        public override decimal CalculateGrossSalary()
        {
            return MonthlySalary + 5000; // bonus
        }
    }
}
