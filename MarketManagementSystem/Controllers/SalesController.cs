using MarketManagementSystem.Models;
using MarketManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MarketManagementSystem.Controllers
{
    public class SalesController : Controller
    {
        public IActionResult Index()
        {
            var salesViewModel = new SalesViewModel
            {
                Categories = CategoriesRepository.GetCategories()
            };
            return View(salesViewModel);
        }

        public IActionResult SellProductDetailsPartial(int ProductId)
        {
            var product = ProductsRepository.GetProductById(ProductId);
            return PartialView("_sellProductDetails", product);
        }

        public IActionResult Sell(SalesViewModel salesViewModel)
        {
            var product = ProductsRepository.GetProductById(salesViewModel.SelectedProductId);
            if (!ModelState.IsValid)
            {
                salesViewModel.SelectedCategoryId = product?.CategoryId ?? 0;
                salesViewModel.Categories = CategoriesRepository.GetCategories();
                return View("Index", salesViewModel);
            }

            if (product != null)
            {
                TransactionsRepository.Add(
                    "Cashier1",
                    salesViewModel.SelectedProductId,
                    product.Name,
                    product.Price.HasValue ? product.Price.Value : 0,
                    product.Quantity.HasValue ? product.Quantity.Value : 0,
                    salesViewModel.QuantityToSell);

                product.Quantity -= salesViewModel.QuantityToSell;
                ProductsRepository.UpdateProduct(product.ProductId, product);
            }
            return RedirectToAction("Index");
        }


    }
}