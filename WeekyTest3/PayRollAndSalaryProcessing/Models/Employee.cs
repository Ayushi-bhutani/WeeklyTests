namespace PayrollSystem.Models
{

    /// <summary>
    /// abstract class Employee whose methods gets overrided
    /// </summary>
    public abstract class Employee
    {
        /// <summary>
        /// property ID for Employee class
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// property Name for Employee class
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// property Department for Employee class
        /// </summary>
        public string Department { get; }


        /// <summary>
        /// protected constructor for Employee class with parameters
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="department"></param>
        /// <exception cref="ArgumentException"></exception>
        protected Employee(int id, string name, string department)
        {
            if (id <= 0) throw new ArgumentException("Id must be positive.");
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("Name required.");

            Id = id;
            Name = name;
            Department = department;
        }

        
        /// <summary>
        /// Polymorphic behavior abstract method to calculate gross salary
        /// </summary>
        /// <returns></returns>
        public abstract decimal CalculateGrossSalary();

        
        /// <summary>
        /// Common deduction logic using virual class which may or may not be overridden 
        /// </summary>
        /// <param name="gross"></param>
        /// <returns></returns>
        public virtual decimal CalculateDeductions(decimal gross)
        {
            return gross * 0.10m; // 10% tax
        }

        /// <summary>
        /// method GeneratePaySlip using PaySlip constructor
        /// </summary>
        /// <returns></returns>
        public PaySlip GeneratePaySlip()
        {
            decimal gross = CalculateGrossSalary();
            decimal deductions = CalculateDeductions(gross);
            decimal net = gross - deductions;

            return new PaySlip(Id, Name, GetType().Name, gross, deductions, net);
        }
    }
}
