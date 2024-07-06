using Mydu_Shoes.Models;

public class OrderDetail
{
    public Guid Id { get; set; }
    public Guid InvoiceId { get; set; }
    public Invoice Invoice { get; set; }
    public Guid CartItemId { get; set; }
    public CartItem CartItem { get; set; }
    public int Quantity { get; set; }
    public string Size { get; set; }
    public decimal Price { get; set; }
    public decimal Total => Quantity * Price;
}

