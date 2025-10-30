namespace ECommerce.Models;

public class CartItem
{
    public int ProductId { get; set; }
    public string Title { get; set; } = "";
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal LineTotal => Price * Quantity;
}
