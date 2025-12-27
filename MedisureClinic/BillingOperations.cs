using System;

namespace MediSure
{
    public class BillingOperations
    {
        private static PatientBill? LastBill;
        private static bool HasLastBill = false;

        // ---------------- CREATE BILL ----------------
        public void CreateBill()
        {
            PatientBill bill = new PatientBill();

            Console.Write("Enter Bill Id: ");
            bill.BillId = Console.ReadLine();

            //checking if billId is NULL OR NOT
            if (string.IsNullOrWhiteSpace(bill.BillId))
            {
                Console.WriteLine("Bill Id cannot be empty.");
                return;
            }

            Console.Write("Enter Patient Name: ");
            bill.PatientName = Console.ReadLine();

            Console.Write("Is the patient insured? (Y/N): ");
            string? ins = Console.ReadLine();
            bill.HasInsurance = ins != null && ins.Trim().ToUpper() == "Y";

            Console.Write("Enter Consultation Fee: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal consult) || consult <= 0)
            {
                Console.WriteLine("Consultation Fee must be greater than 0.");
                return;
            }
            bill.ConsultationFee = consult;

            Console.Write("Enter Lab Charges: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal lab) || lab < 0)
            {
                Console.WriteLine("Lab Charges must be 0 or more.");
                return;
            }
            bill.LabCharges = lab;

            Console.Write("Enter Medicine Charges: ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal med) || med < 0)
            {
                Console.WriteLine("Medicine Charges must be 0 or more.");
                return;
            }
            bill.MedicineCharges = med;

            // Billing calculations
            bill.GrossAmount = bill.ConsultationFee + bill.LabCharges + bill.MedicineCharges;
            bill.DiscountAmount = bill.HasInsurance ? bill.GrossAmount * 0.10m : 0;
            bill.FinalPayable = bill.GrossAmount - bill.DiscountAmount;

            // Saved to static storage
            LastBill = bill;
            HasLastBill = true;

            Console.WriteLine("\nBill created successfully.");

            //printing upto 
            Console.WriteLine($"Gross Amount: {bill.GrossAmount:F2}");
            Console.WriteLine($"Discount Amount: {bill.DiscountAmount:F2}");
            Console.WriteLine($"Final Payable: {bill.FinalPayable:F2}");
            Console.WriteLine("------------------------------------------------------------");
        }

        // ---------------- VIEW BILL ----------------
        public void ViewLastBill()
        {
            if (!HasLastBill || LastBill == null)
            {
                Console.WriteLine("No bill available. Please create a new bill first.");
                return;
            }

            Console.WriteLine("\n----------- Last Bill -----------");
            Console.WriteLine($"BillId: {LastBill.BillId}");
            Console.WriteLine($"Patient: {LastBill.PatientName}");
            Console.WriteLine($"Insured: {(LastBill.HasInsurance ? "Yes" : "No")}");
            Console.WriteLine($"Consultation Fee: {LastBill.ConsultationFee:F2}");
            Console.WriteLine($"Lab Charges: {LastBill.LabCharges:F2}");
            Console.WriteLine($"Medicine Charges: {LastBill.MedicineCharges:F2}");
            Console.WriteLine($"Gross Amount: {LastBill.GrossAmount:F2}");
            Console.WriteLine($"Discount Amount: {LastBill.DiscountAmount:F2}");
            Console.WriteLine($"Final Payable: {LastBill.FinalPayable:F2}");
            Console.WriteLine("--------------------------------");
        }

        // ---------------- CLEAR BILL ----------------
        public void ClearLastBill()
        {
            LastBill = null;
            HasLastBill = false;

            Console.WriteLine("Last bill cleared.");
        }
    }
}
