using System.Text.Json;
using ProductCatalogSystem.Models;

namespace ProductCatalogSystem.Services
{
    public class JsonProductService : IProductService
    {
        private readonly string _filePath;

        // Constructor: Faylın harada saxlanacağını müəyyən edirik
        public JsonProductService(IWebHostEnvironment env)
        {
            _filePath = Path.Combine(env.ContentRootPath, "products.json");
        }

        public List<Product> GetAllProducts()
        {
            if (!File.Exists(_filePath))
                return new List<Product>();

            var json = File.ReadAllText(_filePath);
            return JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
        }

        public Product? GetProductById(int id)
        {
            return GetAllProducts().FirstOrDefault(p => p.Id == id);
        }

        public void AddProduct(Product product)
        {
            var products = GetAllProducts();
            product.Id = products.Any() ? products.Max(p => p.Id) + 1 : 1;
            products.Add(product);
            SaveToFile(products);
        }

        public void UpdateProduct(Product updatedProduct)
        {
            var products = GetAllProducts();
            var index = products.FindIndex(p => p.Id == updatedProduct.Id);
            if (index != -1)
            {
                products[index] = updatedProduct;
                SaveToFile(products);
            }
        }

        public void DeleteProduct(int id)
        {
            var products = GetAllProducts();
            var productToRemove = products.FirstOrDefault(p => p.Id == id);
            if (productToRemove != null)
            {
                products.Remove(productToRemove);
                SaveToFile(products);
            }
        }

        // Köməkçi metod: Dəyişiklikləri yenidən JSON faylına yazır
        private void SaveToFile(List<Product> products)
        {
            var options = new JsonSerializerOptions { WriteIndented = true }; // JSON-u oxunaqlı formata salır
            var json = JsonSerializer.Serialize(products, options);
            File.WriteAllText(_filePath, json);
        }
    }
}