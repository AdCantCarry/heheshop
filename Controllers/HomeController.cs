using heheshop.Data; // nếu DbContext nằm trong thư mục Data
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using heheshop.Models;
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly HeheDbContext _context;

    public HomeController(ILogger<HomeController> logger, HeheDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var products = _context.Products
            .Include(p => p.Brand)
            .Include(p => p.Images)
            .Include(p => p.Category)
            .ToList();

        return View(products); // Truyền danh sách sản phẩm sang view
    }

    // ...
}
