using Microsoft.AspNetCore.Mvc;
using ProductCatalogSystem.Models;
using ProductCatalogSystem.Services;

namespace ProductCatalogSystem.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        // Constructor: Yaratdığımız JSON servisini bura daxil edirik (Dependency Injection)
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // 1. Məhsulların siyahısı (Ana səhifə)
        public IActionResult Index()
        {
            var products = _productService.GetAllProducts();
            return View(products);
        }

        // 2. Yeni məhsul əlavə etmə (Sadəcə boş formu ekranda göstərmək üçün)
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // 3. Yeni məhsul əlavə etmə (İstifadəçi "Yadda saxla" vuranda işləyir)
        [HttpPost]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.AddProduct(product);
                // Terminala xüsusi bildiriş göndəririk
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n[SİSTEM MESAJI] -> YENİ MƏHSUL QEYDƏ ALINDI: {product.Name} | Qiymət: {product.Price} AZN");
                Console.ResetColor();
                return RedirectToAction("Index");
            }
                  
            // Şərtlər ödənməsə, xətalarla birlikdə formu yenidən göstər
            return View(product);
        }

        // 4. Məhsulu dəyişmək üçün mövcud məlumatları gətirir
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null) return NotFound();

            return View(product);
        }

        // 5. Dəyişdirilmiş məlumatları yadda saxlayır
        [HttpPost]
        public IActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                _productService.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            return View(product);
        }

        // 6. Məhsulu silmək üçün
        public IActionResult Delete(int id)
        {
            _productService.DeleteProduct(id);
            Console.ForegroundColor = ConsoleColor.Red; // Silinməni qırmızı rənglə göstəririk
            Console.WriteLine($"\n[DİQQƏT] -> MƏHSUL SİLİNDİ! İD nömrəsi: {id}");
            Console.ResetColor();
            return RedirectToAction("Index");
        }
    }
}