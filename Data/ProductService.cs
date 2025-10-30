using ECommerce.Models;

namespace ECommerce.Data;

public class ProductService
{
    private readonly List<Product> _products;

    public ProductService()
    {
        _products = new List<Product>
        {
            new Product { Id = 1, Title = "Wireless Headphones", Description = "Comfortable & long battery life", Price = 149.99m, ImageUrl="/images/headphones.jpg" },
            new Product { Id = 2, Title = "Mechanical Keyboard", Description = "Tactile switches, RGB", Price = 89.50m, ImageUrl="/images/keyboard.jpg" },
            new Product { Id = 3, Title = "Smart Watch", Description = "Fitness tracking & notifications", Price = 199.00m, ImageUrl="/images/watch.jpg" },
            new Product { Id = 4, Title = "Portable Speaker", Description = "Water-resistant Bluetooth speaker", Price = 59.99m, ImageUrl="/images/speaker.jpg" }
        };
    }

    public IEnumerable<Product> GetAll() => _products;
    public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);
}
