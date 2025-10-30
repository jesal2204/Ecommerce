using ECommerce.Models;
using ECommerce.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class CartModel : PageModel
{
    public List<CartItem> Cart { get; set; } = new();

    public void OnGet()
    {
        Cart = HttpContext.Session.GetJson<List<CartItem>>("cart") ?? new List<CartItem>();
    }

    public IActionResult OnPostRemove(int productId)
    {
        var cart = HttpContext.Session.GetJson<List<CartItem>>("cart") ?? new List<CartItem>();
        cart.RemoveAll(c => c.ProductId == productId);
        HttpContext.Session.SetJson("cart", cart);
        return RedirectToPage();
    }

    public IActionResult OnPostUpdateQty(int productId, int qty)
    {
        var cart = HttpContext.Session.GetJson<List<CartItem>>("cart") ?? new List<CartItem>();
        var item = cart.FirstOrDefault(c => c.ProductId == productId);
        if (item != null)
        {
            item.Quantity = Math.Max(1, qty);
            HttpContext.Session.SetJson("cart", cart);
        }
        return RedirectToPage();
    }
}
