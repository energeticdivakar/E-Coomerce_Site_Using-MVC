


using System.ComponentModel.DataAnnotations;

namespace Productpage.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public string? SubCategory { get; set; }
        public byte[] ProductImage { get; set; }
        public decimal Price { get; set; }
        public Product()
        {
            ProductImage = new byte[0];
        }
    }
}