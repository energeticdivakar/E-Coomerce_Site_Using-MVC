

using Microsoft.AspNetCore.Mvc;
using Productpage.Models;

public class ProductController : Controller
{
    private readonly ApplicationDbContext _context;

    public ProductController(ApplicationDbContext context)
    {
        _context = context;
    }
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(IFormFile ProductImage, Product product)
    {
        if (ModelState.IsValid)
        {
            if (ProductImage != null && ProductImage.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    ProductImage.CopyTo(ms)
;
                    product.ProductImage = ms.ToArray(); 
                }
            }
            _context.Products.Add(product);
            _context.SaveChanges();
            return RedirectToAction("List");
        }

        return View(product);
    }


    public IActionResult GetSubcategories(int categoryId)
    {
        var subcategories = new List<string> { "Subcategory 1", "Subcategory 2", "Subcategory 3", "Subcategory 4", "Subcategory 5" };
        return Json(subcategories);
    }

    public IActionResult List()
    {
        var products = _context.Products.ToList();
        return View(products);
    }
}
