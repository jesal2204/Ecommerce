using ECommerce.Data;
using ECommerce.Models;
using ECommerce.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class IndexModel : PageModel
{
    private readonly ProductService _productService;
    public IEnumerable<Product> Products { get; set; } = Enumerable.Empty<Product>();

    public IndexModel(ProductService productService) => _productService = productService;

    public void OnGet() => Products = _productService.GetAll();

    public IActionResult OnPostAddToCart(int productId, int qty = 1)
    {
        var prod = _productService.GetById(productId);
        if (prod == null) return NotFound();

        var cart = HttpContext.Session.GetJson<List<CartItem>>("cart") ?? new List<CartItem>();
        var existing = cart.FirstOrDefault(c => c.ProductId == productId);
        if (existing != null) existing.Quantity += qty;
        else cart.Add(new CartItem { ProductId = prod.Id, Title = prod.Title, Price = prod.Price, Quantity = qty });

        HttpContext.Session.SetJson("cart", cart);
        return RedirectToPage();
    }
}
