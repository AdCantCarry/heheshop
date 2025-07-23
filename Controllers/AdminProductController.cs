using Microsoft.AspNetCore.Mvc;
using heheshop.Data;
using heheshop.Models;
using Microsoft.EntityFrameworkCore;

namespace heheshop.Controllers;

public class AdminProductController : Controller
{
    private readonly HeheDbContext _context;

    public AdminProductController(HeheDbContext context)
    {
        _context = context;
    }

    // Danh sách sản phẩm
    public IActionResult Index()
    {
        var products = _context.Products
            .Include(p => p.Brand)
            .Include(p => p.Category)
            .ToList();

        return View("~/Views/Admin/AdminProduct/Index.cshtml", products);
    }

    // Chi tiết sản phẩm
    public IActionResult Details(int id)
    {
        var product = _context.Products
            .Include(p => p.Brand)
            .Include(p => p.Category)
            .Include(p => p.Images)
            .Include(p => p.Variants)
            .FirstOrDefault(p => p.Id == id);

        if (product == null) return NotFound();

        return View("~/Views/Admin/AdminProduct/Details.cshtml", product);
    }

    // GET: Tạo sản phẩm
    public IActionResult Create()
    {
        ViewBag.Brands = _context.Brands.ToList();
        ViewBag.Categories = _context.Categories.ToList();

        return View("~/Views/Admin/AdminProduct/Create.cshtml");
    }

    // POST: Tạo sản phẩm
    [HttpPost]
    public IActionResult Create(Product product)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Brands = _context.Brands.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            return View("~/Views/Admin/AdminProduct/Create.cshtml", product);
        }

        _context.Products.Add(product);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    // GET: Sửa sản phẩm
    public IActionResult Edit(int id)
    {
        var product = _context.Products
            .Include(p => p.Images)
            .Include(p => p.Variants)
            .FirstOrDefault(p => p.Id == id);

        if (product == null) return NotFound();

        ViewBag.Brands = _context.Brands.ToList();
        ViewBag.Categories = _context.Categories.ToList();

        return View("~/Views/Admin/AdminProduct/Edit.cshtml", product);
    }

    // POST: Sửa sản phẩm
    [HttpPost]
    public IActionResult Edit(Product product)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Brands = _context.Brands.ToList();
            ViewBag.Categories = _context.Categories.ToList();
            return View("~/Views/Admin/AdminProduct/Edit.cshtml", product);
        }

        _context.Products.Update(product);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    // Xoá sản phẩm
    public IActionResult Delete(int id)
    {
        var product = _context.Products.Find(id);
        if (product == null) return NotFound();

        _context.Products.Remove(product);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}
