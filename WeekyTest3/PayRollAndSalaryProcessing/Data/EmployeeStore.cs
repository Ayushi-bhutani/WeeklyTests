using PayrollSystem.Models;

namespace PayrollSystem.Data
{
    public static class EmployeeStore
    {
        private static readonly List<Employee> _employees = new();

        /// <summary>
        /// Seed method defined and called once at the start of project main function --loading database
        /// </summary>
        public static void Seed()
        {
            Add(new FullTimeEmployee(1, "Ayushi", "IT", 50000));
            Add(new FullTimeEmployee(2, "Sneha", "HR", 60000));
            Add(new ContractEmployee(3, "Akram", "IT", 20, 1500));
            Add(new ContractEmployee(4, "Anuska", "Design", 18, 1800));
            Add(new FullTimeEmployee(5, "Sachin", "Sales", 55000));
            Add(new ContractEmployee(6, "Meena", "Support", 22, 1200));
        }


        /// <summary>
        /// method Add to add employee data to the seed database
        /// </summary>
        /// <param name="emp"></param>
        public static void Add(Employee emp)
        {
            _employees.Add(emp);
        }


        /// <summary>
        /// method getall to return all employee data added to the database yet
        /// </summary>
        /// <returns></returns>
        public static IReadOnlyList<Employee> GetAll()
        {
            return _employees;
        }
    }
}
