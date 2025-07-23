namespace heheshop.Models;
public class DiscountCode
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public decimal DiscountAmount { get; set; } // e.g. 10.00 means 10,000 VND
    public DateTime ExpiryDate { get; set; }
    public bool IsActive { get; set; } = true;
}
