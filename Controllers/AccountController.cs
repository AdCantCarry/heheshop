using Microsoft.AspNetCore.Mvc;
using heheshop.Models;
using heheshop.Data;
using System.Linq;
using Microsoft.AspNetCore.Http;
using BCrypt.Net;

namespace heheshop.Controllers;

public class AccountController : Controller
{
    private readonly HeheDbContext _context;

    public AccountController(HeheDbContext context)
    {
        _context = context;
    }

    // Đăng ký
    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(User user)
    {
        if (_context.Users.Any(u => u.Username == user.Username))
        {
            ModelState.AddModelError("Username", "Tên đăng nhập đã tồn tại.");
            return View(user);
        }

        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);

        // 🔐 Nếu Username là "admin", tự set role Admin luôn
        user.Role = user.Username.ToLower() == "admin" ? "Admin" : "Customer";

        _context.Users.Add(user);
        _context.SaveChanges();

        return RedirectToAction("Login");
    }


    // Đăng nhập
    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    // Đăng nhập
    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        var user = _context.Users.FirstOrDefault(u => u.Username == username);

        if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.PasswordHash))
        {
            ModelState.AddModelError(string.Empty, "Tên đăng nhập hoặc mật khẩu không đúng.");
            return View();
        }

        // Lưu session
        HttpContext.Session.SetInt32("UserId", user.Id);
        HttpContext.Session.SetString("Username", user.Username);
        HttpContext.Session.SetString("Role", user.Role);

        // 👉 Nếu là Admin thì về trang admin
        if (user.Role == "Admin")
            return RedirectToAction("Dashboard", "Admin");

        // 👉 Nếu là Customer thì về Home
        return RedirectToAction("Index", "Home");
    }


    // Đăng xuất
    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}
