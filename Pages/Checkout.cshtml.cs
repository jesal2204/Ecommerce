using ECommerce.Models;
using ECommerce.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class CheckoutModel : PageModel
{
    public List<CartItem> Cart { get; set; } = new();

    public void OnGet()
    {
        Cart = HttpContext.Session.GetJson<List<CartItem>>("cart") ?? new List<CartItem>();
    }

    public IActionResult OnPost(string FullName, string Address)
    {
        Cart = HttpContext.Session.GetJson<List<CartItem>>("cart") ?? new List<CartItem>();
        if (!Cart.Any()) return RedirectToPage("/Index");

        // In a real app persist order to DB and process payment.
        // Here we'll just clear session and show confirmation.

        HttpContext.Session.Remove("cart");

        TempData["OrderName"] = FullName;
        TempData["OrderTotal"] = Cart.Sum(i => i.LineTotal).ToString("0.00");
        return RedirectToPage("/OrderConfirmation");
    }
}
