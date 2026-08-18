using Microsoft.AspNetCore.Mvc;
using SmartWarehouse.Business.Interfaces;
using SmartWarehouse.Domain.Entities;

namespace SmartWarehouse.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit (int id)
        {
            var product=await _productService.GetByIdAsync(id);
            
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult>Create(Product product)
        {

            await _productService.AddAsync(product);

            TempData["Success"] = "Ürün başarıyla eklendi.";

            return RedirectToAction("Index");
        }   

        [HttpPost]
        public async Task<IActionResult>Edit (Product product)
        {

            await _productService.UpdateAsync(product);

            TempData["Success"] = "Ürün başarıyla güncellendi.";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult>Delete (int id)
        {
                await _productService.DeleteAsync(id);

                TempData["Success"] = "Ürün başarıyla silindi.";
            
                return RedirectToAction("Index");
        }
        
        [HttpPost]
        public async Task<IActionResult>DeleteSelected([FromBody] List<int> selectedIds)
        {
            try
            {
                await _productService.DeleteSelectedAsync(selectedIds);

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
