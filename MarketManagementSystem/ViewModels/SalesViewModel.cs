using System.ComponentModel.DataAnnotations;
using MarketManagementSystem.Models;
using MarketManagementSystem.ViewModels.Validations;

namespace MarketManagementSystem.ViewModels
{
    public class SalesViewModel
    {
        public int SelectedCategoryId { get; set; }
        public IEnumerable<Category> Categories { get; set; } = new List<Category>();
        public int SelectedProductId { get; set; }

        [Range(1, int.MaxValue)]
        [Display(Name = "Quantity")]
        [SalesModelView_EnsureProperQuality]
        public int QuantityToSell { get; set; }
    }
}