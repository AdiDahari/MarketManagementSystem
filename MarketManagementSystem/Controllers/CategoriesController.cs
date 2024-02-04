using MarketManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;

namespace MarketManagementSystem.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories = CategoriesRepository.GetCategories();
            return View(categories);
        }

        public IActionResult Edit(int? id)
        {
            ViewBag.Action = "edit";
            var category = CategoriesRepository.GetCategoryById(id.HasValue ? id.Value : 0);

            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            CategoriesRepository.UpdateCategory(category.CategoryId, category);

            return RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            ViewBag.Action = "create";

            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            CategoriesRepository.AddCategory(category);

            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            CategoriesRepository.DeleteCategory(id);

            return RedirectToAction("Index");
        }
    }
}