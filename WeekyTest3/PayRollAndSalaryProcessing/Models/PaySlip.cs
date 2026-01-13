namespace PayrollSystem.Models
{
    public class PaySlip
    {
        /// <summary>
        /// defining property EmployeeId
        /// </summary>
        public int EmployeeId { get; }

        /// <summary>
        /// defining property Name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// defining property Type 
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// defining property Gross 
        /// </summary>
        public decimal Gross { get; }

        /// <summary>
        /// defining property Deductions 
        /// </summary>
        public decimal Deductions { get; }

        /// <summary>
        /// defining property Net 
        /// </summary>
        public decimal Net { get; }

        /// <summary>
        /// constructor for payslip class
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="type"></param>
        /// <param name="gross"></param>
        /// <param name="deductions"></param>
        /// <param name="net"></param>
        public PaySlip(int id, string name, string type,
                        decimal gross, decimal deductions, decimal net)
        {
            EmployeeId = id;
            Name = name;
            Type = type;
            Gross = gross;
            Deductions = deductions;
            Net = net;
        }
    }
}
