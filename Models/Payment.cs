public class Payment
{
    public int Id { get; set; }
    public string Method { get; set; } = "COD"; // PayPal, E-Wallet, etc.
    public bool IsPaid { get; set; } = false;
    public DateTime? PaidAt { get; set; }
    public int OrderId { get; set; }
    public Order Order { get; set; } = null!;
}