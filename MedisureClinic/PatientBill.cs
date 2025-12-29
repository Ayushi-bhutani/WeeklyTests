namespace MediSure
{
    public class PatientBill
    {

        public string? BillId { get; set; }      //getter and setter for member variable BillId
        public string? PatientName { get; set; }   //getter and setter for member variable PatientName
        public bool HasInsurance { get; set; }     //getter and setter for member variable HasInsurance
        public decimal ConsultationFee { get; set; }   //getter and setter for member variable ConsultationFee
        public decimal LabCharges { get; set; }         //getter and setter for member variable LabCharges
        public decimal MedicineCharges { get; set; }    //getter and setter for member variable MedicineCharges
        public decimal GrossAmount { get; set; }        //getter and setter for member variable GrossAmount
        public decimal DiscountAmount { get; set; }    //getter and setter for member variable DiscountAmount
        public decimal FinalPayable { get; set; }     //getter and setter for member variable FinalPayable
    }
}
