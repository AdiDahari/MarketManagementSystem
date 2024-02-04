using System.ComponentModel.DataAnnotations;

namespace MarketManagementSystem.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        [Range(0, int.MaxValue)]
        public double? Price { get; set; }
        [Required]
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
        public Category? Category { get; set; }
        public int? Quantity { get; set; }
    }
}