using System.ComponentModel.DataAnnotations;

namespace ProductCatalogSystem.Models
{
    public class Product
    {
        // Məhsulu tapmaq, dəyişmək və silmək üçün bizə unikal ID lazımdır
        public int Id { get; set; }

        [Required(ErrorMessage = "Məhsul adı boş ola bilməz.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Qiymət boş ola bilməz.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Qiymət 0-dan böyük olmalıdır.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Kateqoriya boş ola bilməz.")]
        public string? Category { get; set; }
    }
}