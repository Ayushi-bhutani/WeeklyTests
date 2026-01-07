namespace QuickMart
{
    public class SaleTransaction
    {

        public string? InvoiceNo { get; set; }  //getters and setter for InvoiceNo 

        public string? CustomerName { get; set; }  //getters and setter for CustomerName 
        public string? ItemName { get; set; }  //getters and setter for ItemName 
        public int Quantity { get; set; }    //getters and setter for Quantity 

        public decimal PurchaseAmount { get; set; }   //getters and setter for PurchaseAmount 
        public decimal SellingAmount { get; set; }       //getters and setter for SellingAmount 

        public string? ProfitOrLossStatus { get; set; }     //getters and setter for ProfitOrLossStatus 
        public decimal ProfitOrLossAmount { get; set; }          //getters and setter for ProfitOrLossAmount 
        public decimal ProfitMarginPercent { get; set; }      //getters and setter for ProfitMarginPercent 
    }
}
