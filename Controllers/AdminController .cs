using Microsoft.AspNetCore.Mvc;
using heheshop.Data;

public class AdminDashboardController : Controller
{
    private readonly HeheDbContext _context;

    public AdminDashboardController(HeheDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var role = HttpContext.Session.GetString("Role");
        if (role != "Admin")
            return RedirectToAction("Login", "Account");

        ViewBag.TotalUsers = _context.Users.Count();
        ViewBag.TotalOrders = _context.Orders.Count();
        ViewBag.TotalProducts = _context.Products.Count();

        return View();
    }
}
