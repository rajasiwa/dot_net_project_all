using Microsoft.AspNetCore.Mvc; // Required for Controller and IActionResult
using System.Collections.Generic; // Required for List<T>

namespace ProductCatalogApp.Controllers
{
    // This controller handles requests related to products
    public class ProductController : Controller
    {
        // Action to display the product list
        // URL: /Product/Index
        public IActionResult Index()
        {
            // Sample product list
            var products = new List<string> { "Laptop", "Phone", "Tablet" };

            // Pass the product list to the view
            return View(products);
        }

        // Action to display details of a specific product
        // URL: /Product/Details/{id}
        public IActionResult Details(int id)
        {
            // Create a string representing the product details
            var product = $"Product {id}";

            // Pass the product details to the view named "Details"
            return View("Details", product);
        }
    }
}
