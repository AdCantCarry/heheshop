using heheshop.Data;
using heheshop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace heheshop.Controllers
{
    public class AdminBrandController : Controller
    {
        private readonly HeheDbContext _context;

        public AdminBrandController(HeheDbContext context)
        {
            _context = context;
        }

        // GET: /AdminBrand
        public async Task<IActionResult> Index()
        {
            var brands = await _context.Brands.ToListAsync();
            return View("~/Views/Admin/AdminBrand/Index.cshtml", brands);
        }

        // GET: /AdminBrand/Create
        public IActionResult Create()
        {
            return View("~/Views/Admin/AdminBrand/Create.cshtml");
        }

        // POST: /AdminBrand/Create
        [HttpPost]
        public async Task<IActionResult> Create(Brand brand)
        {
            if (ModelState.IsValid)
            {
                _context.Brands.Add(brand);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View("~/Views/Admin/AdminBrand/Create.cshtml", brand);
        }

        // GET: /AdminBrand/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null) return NotFound();
            return View("~/Views/Admin/AdminBrand/Edit.cshtml", brand);
        }

        // POST: /AdminBrand/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Brand brand)
        {
            if (id != brand.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Brands.Update(brand);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View("~/Views/Admin/AdminBrand/Edit.cshtml", brand);
        }

        // GET: /AdminBrand/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var brand = await _context.Brands.FindAsync(id);
            if (brand == null) return NotFound();

            _context.Brands.Remove(brand);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
