using Microsoft.AspNetCore.Mvc;
using heheshop.Data;

namespace heheshop.Controllers;

public class AdminController : Controller
{
    private readonly HeheDbContext _context;

    public AdminController(HeheDbContext context)
    {
        _context = context;
    }

    public IActionResult Dashboard()
    {
        var role = HttpContext.Session.GetString("Role");
        if (role != "Admin")
            return RedirectToAction("Login", "Account");

        ViewBag.TotalUsers = _context.Users.Count();
        ViewBag.TotalOrders = _context.Orders.Count();
        ViewBag.TotalProducts = _context.Products.Count();

        return View(); // sẽ tự tìm Views/Admin/Dashboard.cshtml nếu bạn để mặc định
    }
}
