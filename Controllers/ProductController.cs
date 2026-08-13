using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartWarehouse.DataAccess;
using SmartWarehouse.Entities;

namespace SmartWarehouse.Controllers
{
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _context.Products.ToListAsync();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit (int id)
        {
            var product=await _context.Products.FindAsync(id);
            
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult>Create(Product product)
        {
            _context.Products.Add(product);

            await _context.SaveChangesAsync();

            TempData["Success"] = "Ürün başarıyla eklendi.";

            return RedirectToAction("Index");
        }   

        [HttpPost]
        public async Task<IActionResult>Edit (Product product)
        {
            _context.Products.Update(product);

            await _context.SaveChangesAsync();

            TempData["Success"] = "Ürün başarıyla güncellendi.";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult>Delete (int id)
        {

            var product = await _context.Products.FindAsync(id);

            if (product != null)
            {
                _context.Products.Remove(product);
   
                await _context.SaveChangesAsync();

                TempData["Success"] = "Ürün başarıyla silindi.";
            }

            return RedirectToAction("Index");
        }
        
        [HttpPost]
        public async Task<IActionResult>DeleteSelected([FromBody] List<int> selectedIds)
        {
            try
            {
                var products = await _context.Products
                    .Where(p => selectedIds.Contains(p.Id))
                    .ToListAsync();

                _context.Products.RemoveRange(products);

                await _context.SaveChangesAsync();

                return Json(new
                {
                    success = true,
                    message = "Seçilen ürünler başarıyla silindi."
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = ex.Message
                });
            }
        }
    }
}
