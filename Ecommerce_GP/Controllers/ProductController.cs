using GP.Business.Interfaces;
using GP.Business.Services;
using GP.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce_GP.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await file.CopyToAsync(memoryStream);
                    product.Image = memoryStream.ToArray();
                }
            }

            await _productService.AddProductAsync(product);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Product updatedProduct)
        {
            await _productService.UpdateProductAsync(updatedProduct);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> WirelessHeadphonesIndex()
        {
            var products = await _productService.GetAllProductsAsync();
            ViewBag.Model = products.Where(p => p.Category == Category.WirelessHeadphones).ToList();
            return View();
        }

        public async Task<IActionResult> TabletProIndex()
        {
            var products = await _productService.GetAllProductsAsync();
            ViewBag.Model = products.Where(p => p.Category == Category.TabletPro).ToList();
            return View();
        }

        public async Task<IActionResult> SmartwatchIndex()
        {
            var products = await _productService.GetAllProductsAsync();
            ViewBag.Model = products.Where(p => p.Category == Category.Smartwatch).ToList();
            return View();
        }

        public async Task<IActionResult> ProfessionalCameraIndex()
        {
            var products = await _productService.GetAllProductsAsync();
            ViewBag.Model = products.Where(p => p.Category == Category.ProfessionalCamera).ToList();
            return View();
        }

        public async Task<IActionResult> GamingLaptopIndex()
        {
            var products = await _productService.GetAllProductsAsync();
            ViewBag.Model = products.Where(p => p.Category == Category.GamingLaptop).ToList();
            return View();
        }

        public async Task<IActionResult> FlagshipSmartphoneIndex()
        {
            var products = await _productService.GetAllProductsAsync();
            ViewBag.Model = products.Where(p => p.Category == Category.FlagshipSmartphone).ToList();
            return View();
        }





    }
}
