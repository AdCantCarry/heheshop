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
            ViewBag.BrandId = new SelectList(_context.Brands, "Id", "Name", product.BrandId);
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);

            await LoadBrandsAndCategoriesAsync(product.BrandId, product.CategoryId);
            return View("~/Views/Admin/AdminProduct/Edit.cshtml", product);
        }

        // POST: AdminProduct/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Product product, IFormFile? Thumbnail, List<IFormFile>? ProductImages)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Xử lý cập nhật thông tin chính
                    _context.Update(product);

                    // Nếu có ảnh đại diện mới
                    if (Thumbnail != null && Thumbnail.Length > 0)
                    {
                        var thumbnailFileName = Guid.NewGuid().ToString() + Path.GetExtension(Thumbnail.FileName);
                        var thumbnailPath = Path.Combine("wwwroot/uploads", thumbnailFileName);
                        using (var stream = new FileStream(thumbnailPath, FileMode.Create))
                        {
                            await Thumbnail.CopyToAsync(stream);
                        }
                        product.ThumbnailUrl = "/uploads/" + thumbnailFileName;
                    }

                    // Xử lý thêm ảnh chi tiết
                    if (ProductImages != null && ProductImages.Count > 0)
                    {
                        foreach (var image in ProductImages)
                        {
                            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                            var path = Path.Combine("wwwroot/uploads", fileName);
                            using (var stream = new FileStream(path, FileMode.Create))
                            {
                                await image.CopyToAsync(stream);
                            }

                            var productImage = new ProductImage
                            {
                                ProductId = product.Id,
                                ImageUrl = "/uploads/" + fileName
                            };

                            _context.ProductImages.Add(productImage);
                        }
                    }

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.Products.Any(e => e.Id == product.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return RedirectToAction(nameof(Index));
            }

            // Nếu có lỗi, nạp lại danh sách Brand/Category
            ViewBag.BrandId = new SelectList(_context.Brands, "Id", "Name", product.BrandId);
            ViewBag.CategoryId = new SelectList(_context.Categories, "Id", "Name", product.CategoryId);

            return View(product);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                TempData["ErrorMessage"] = "Không tìm thấy sản phẩm để xóa.";
                return RedirectToAction("Index");
            }

            // Xóa ảnh chi tiết nếu có
            var images = await _context.ProductImages.Where(pi => pi.ProductId == id).ToListAsync();
            if (images.Any())
                _context.ProductImages.RemoveRange(images);

            // Xóa biến thể
            var variants = await _context.ProductVariants.Where(v => v.ProductId == id).ToListAsync();
            if (variants.Any())
                _context.ProductVariants.RemoveRange(variants);

            // Xóa sản phẩm
            _context.Products.Remove(product);

            try
            {
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Xóa sản phẩm thành công.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Lỗi khi xóa sản phẩm: " + ex.Message;
            }

            return RedirectToAction("Index");
        }


    }
}