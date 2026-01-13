namespace OrderSystem.Models
{

    /// <summary>
    /// created enum for OrderStatus which has multiple status changes which can be made to an order 
    /// enum used because status values are fixed and finite and new status cam be added later easily
    /// </summary>
    public enum OrderStatus
    {
        Created,
        Paid,
        Packed,
        Shipped,
        Delivered,
        Cancelled
    }
}
