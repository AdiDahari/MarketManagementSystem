namespace MarketManagementSystem.Models
{
    public static class CategoriesRepository
    {
        private static List<Category> _categories = new List<Category>()
        {
            new Category { CategoryId = 1, Name = "Fruits", Description = "All fruits" },
            new Category { CategoryId = 2, Name = "Vegetables", Description = "All vegetables" },
            new Category { CategoryId = 3, Name = "Dairy", Description = "All dairy products" },
            new Category { CategoryId = 4, Name = "Meat", Description = "All meat products" },
            new Category { CategoryId = 5, Name = "Beverages", Description = "All beverages" }
        };

        public static void AddCategory(Category category)
        {
            if (_categories == null) _categories = new List<Category>();
            var maxId = _categories.Any() ? _categories.Max(c => c.CategoryId) : 0;
            category.CategoryId = maxId + 1;
            _categories.Add(category);
        }

        public static List<Category> GetCategories() => _categories;

        public static Category? GetCategoryById(int id)
        {
            var category = _categories.FirstOrDefault(c => c.CategoryId == id);
            if (category == null)
            {
                return null;
            }

            return new Category { CategoryId = category.CategoryId, Name = category.Name, Description = category.Description };
        }

        public static void UpdateCategory(int id, Category category)
        {
            if (category == null) return;

            if (id != category.CategoryId) return;

            var categoryToUpdate = _categories.FirstOrDefault(c => c.CategoryId == id);
            if (categoryToUpdate != null)
            {
                categoryToUpdate.Name = category.Name ?? categoryToUpdate.Name;
                categoryToUpdate.Description = category.Description;


            }
        }

        public static void DeleteCategory(int id)
        {
            var category = _categories.FirstOrDefault(c => c.CategoryId == id);
            if (category != null)
            {
                _categories.Remove(category);
            }
        }
    }
}