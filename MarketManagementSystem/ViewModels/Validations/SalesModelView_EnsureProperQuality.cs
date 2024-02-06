using System.ComponentModel.DataAnnotations;
using MarketManagementSystem.Models;

namespace MarketManagementSystem.ViewModels.Validations
{
  public class SalesModelView_EnsureProperQuality : ValidationAttribute
  {
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
      var salesViewModel = validationContext.ObjectInstance as SalesViewModel;

      if (salesViewModel == null)
      {
        return new ValidationResult("Invalid object.");
      }
      if (salesViewModel.QuantityToSell <= 0)
      {
        return new ValidationResult("Quantity must be greater than 0.");
      }

      var product = ProductsRepository.GetProductById(salesViewModel.SelectedProductId);

      if (product == null)
      {
        return new ValidationResult("Product not found.");
      }

      if (salesViewModel.QuantityToSell > product.Quantity)
      {
        return new ValidationResult($"{product.Name} has only {product.Quantity} items in stock.");
      }



      return ValidationResult.Success;
    }
  }
}
