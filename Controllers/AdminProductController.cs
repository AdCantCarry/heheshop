using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using heheshop.Data;
using heheshop.Models;

namespace heheshop.Controllers
{
    public class AdminProductController : Controller
    {
        private readonly HeheDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AdminProductController(HeheDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        private async Task LoadBrandsAndCategoriesAsync(object selectedBrand = null, object selectedCategory = null)
        {
            var brands = await _context.Brands.OrderBy(b => b.Name).ToListAsync();
            var categories = await _context.Categories.OrderBy(c => c.Name).ToListAsync();
            
            ViewBag.Brands = new SelectList(brands, "Id", "Name", selectedBrand);
            ViewBag.Categories = new SelectList(categories, "Id", "Name", selectedCategory);
        }

        // GET: AdminProduct
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .OrderByDescending(p => p.Id)
                .ToListAsync();

            return View("~/Views/Admin/AdminProduct/Index.cshtml", products);
        }

        // GET: AdminProduct/Create
        public async Task<IActionResult> Create()
        {
            await LoadBrandsAndCategoriesAsync();
            return View("~/Views/Admin/AdminProduct/Create.cshtml");
        }

        // POST: AdminProduct/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, IFormFile thumbnail)
        {
            try
            {
                // Kiểm tra validation
                if (!ModelState.IsValid)
                {
                    await LoadBrandsAndCategoriesAsync(product.BrandId, product.CategoryId);
                    return View("~/Views/Admin/AdminProduct/Create.cshtml", product);
                }

                // Xử lý upload ảnh
                if (thumbnail != null && thumbnail.Length > 0)
                {
                    var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(thumbnail.FileName);
                    var filePath = Path.Combine(uploadsFolder, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await thumbnail.CopyToAsync(fileStream);
                    }

                    product.ThumbnailUrl = "/uploads/" + fileName;
                }

                // Thêm sản phẩm vào database
                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Thêm sản phẩm thành công!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Có lỗi xảy ra: {ex.Message}");
                await LoadBrandsAndCategoriesAsync(product.BrandId, product.CategoryId);
                return View("~/Views/Admin/AdminProduct/Create.cshtml", product);
            }
        }

        // GET: AdminProduct/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            await LoadBrandsAndCategoriesAsync(product.BrandId, product.CategoryId);
            return View("~/Views/Admin/AdminProduct/Edit.cshtml", product);
        }

        // POST: AdminProduct/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product, IFormFile thumbnail)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            try
            {
                if (!ModelState.IsValid)
                {
                    await LoadBrandsAndCategoriesAsync(product.BrandId, product.CategoryId);
                    return View("~/Views/Admin/AdminProduct/Edit.cshtml", product);
                }

                // Lấy sản phẩm hiện tại từ database
                var existingProduct = await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
                if (existingProduct == null)
                {
                    return NotFound();
                }

                // Xử lý upload ảnh mới
                if (thumbnail != null && thumbnail.Length > 0)
                {
                    var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads");
                    if (!Directory.Exists(uploadsFolder))
                    {
                        Directory.CreateDirectory(uploadsFolder);
                    }

                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(thumbnail.FileName);
                    var filePath = Path.Combine(uploadsFolder, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await thumbnail.CopyToAsync(fileStream);
                    }

                    product.ThumbnailUrl = "/uploads/" + fileName;
                }
                else
                {
                    // Giữ ảnh cũ nếu không upload ảnh mới
                    product.ThumbnailUrl = existingProduct.ThumbnailUrl;
                }

                // Cập nhật sản phẩm
                _context.Products.Update(product);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = "Cập nhật sản phẩm thành công!";
                return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(product.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Có lỗi xảy ra: {ex.Message}");
                await LoadBrandsAndCategoriesAsync(product.BrandId, product.CategoryId);
                return View("~/Views/Admin/AdminProduct/Edit.cshtml", product);
            }
        }

        // GET: AdminProduct/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (product == null)
            {
                return NotFound();
            }

            return View("~/Views/Admin/AdminProduct/Delete.cshtml", product);
        }

        // POST: AdminProduct/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var product = await _context.Products.FindAsync(id);
                if (product != null)
                {
                    _context.Products.Remove(product);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Xóa sản phẩm thành công!";
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Có lỗi khi xóa sản phẩm: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}