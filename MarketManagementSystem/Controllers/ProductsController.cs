using MarketManagementSystem.Models;
using MarketManagementSystem.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MarketManagementSystem.Controllers;

public class ProductsController : Controller
{
  public IActionResult Index()
  {
    var products = ProductsRepository.GetProducts(true);
    return View(products);
  }

  public IActionResult Edit(int? id)
  {
    ViewBag.Action = "edit";
    var product = ProductsRepository.GetProductById(id ?? 0, true);

    if (product == null)
    {
      return RedirectToAction("Index");
    }


    var productViewModel = new ProductViewModel
    {
      Categories = ProductsRepository.getAllCategories(),
      Product = new Product
      {
        ProductId = product.ProductId,
        Name = product.Name,
        Price = product.Price,
        CategoryId = product.CategoryId,
        Quantity = product.Quantity
      }
    };


    return View(productViewModel);
  }

  [HttpPost]
  public IActionResult Edit(ProductViewModel productViewModel)
  {
    if (!ModelState.IsValid)
    {
      return View(productViewModel);
    }
    ProductsRepository.UpdateProduct(productViewModel.Product.ProductId, productViewModel.Product);
    return RedirectToAction("Index");
  }

  public IActionResult Create()
  {

    ViewBag.Action = "create";
    var productViewModel = new ProductViewModel
    {
      Categories = ProductsRepository.getAllCategories()
    };

    return View(productViewModel);
  }

  [HttpPost]
  public IActionResult Create(ProductViewModel productViewModel)
  {
    if (!ModelState.IsValid)
    {
      return View(productViewModel);
    }
    ProductsRepository.AddProduct(productViewModel.Product);
    return RedirectToAction("Index");
  }

  public IActionResult Delete(int id)
  {
    var product = ProductsRepository.GetProductById(id);
    if (product == null)
    {
      return RedirectToAction("Index");
    }
    ProductsRepository.DeleteProduct(id);
    return RedirectToAction("Index");
  }

  public IActionResult GetProductsByCategoryPartial(int categoryId)
  {
    var products = ProductsRepository.GetProductsByCategoryId(categoryId);
    return PartialView("_products", products);
  }


}