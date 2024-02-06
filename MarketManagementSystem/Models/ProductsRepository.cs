namespace MarketManagementSystem.Models;

public class ProductsRepository
{
  private static List<Product> _products = new List<Product>()
  {
    new Product { ProductId = 1, Name = "Apple", Price = 1.99, CategoryId = 1, Quantity = 100 },
    new Product { ProductId = 2, Name = "Banana", Price = 0.99, CategoryId = 1, Quantity = 150 },
    new Product { ProductId = 3, Name = "Orange", Price = 1.49, CategoryId = 1, Quantity = 200 },
    new Product { ProductId = 4, Name = "Cucumber", Price = 0.49, CategoryId = 2, Quantity = 100 },
    new Product { ProductId = 5, Name = "Tomato", Price = 0.79, CategoryId = 2, Quantity = 150 },
    new Product { ProductId = 6, Name = "Milk", Price = 2.99, CategoryId = 3, Quantity = 100 },
    new Product { ProductId = 7, Name = "Cheese", Price = 3.99, CategoryId = 3, Quantity = 150 },
    new Product { ProductId = 8, Name = "Beef", Price = 5.99, CategoryId = 4, Quantity = 100 },
    new Product { ProductId = 9, Name = "Chicken", Price = 4.99, CategoryId = 4, Quantity = 150 },
    new Product { ProductId = 10, Name = "Water", Price = 0.99, CategoryId = 5, Quantity = 100 },
    new Product { ProductId = 11, Name = "Soda", Price = 1.49, CategoryId = 5, Quantity = 150 }
    };

  public static void AddProduct(Product product)
  {
    var maxId = _products.Any() ? _products.Max(p => p.ProductId) : 1;
    product.ProductId = maxId + 1;
    _products.Add(product);
  }

  public static List<Product> GetProducts(bool loadCategory = false)
  {
    if (!loadCategory)
    {
      return _products;
    }

    var products = _products.Select(p => new Product
    {
      ProductId = p.ProductId,
      Name = p.Name,
      Price = p.Price,
      CategoryId = p.CategoryId,
      Quantity = p.Quantity,
      Category = CategoriesRepository.GetCategoryById(p.CategoryId ?? 0)
    }).ToList();

    return products;
  }

  public static List<Category> getAllCategories()
  {
    return CategoriesRepository.GetCategories();
  }

  public static Product? GetProductById(int id, bool loadCategory = false)
  {
    var product = _products.FirstOrDefault(p => p.ProductId == id);
    if (product == null)
    {
      return null;
    }

    var productCopy = new Product { ProductId = product.ProductId, Name = product.Name, Price = product.Price, CategoryId = product.CategoryId, Quantity = product.Quantity };

    if (loadCategory && product.CategoryId.HasValue)
    {
      productCopy.Category = CategoriesRepository.GetCategoryById(product.CategoryId.Value);
    }

    return productCopy;
  }

  public static void UpdateProduct(int id, Product product)
  {
    if (product == null) return;

    if (id != product.ProductId) return;

    var productToUpdate = _products.FirstOrDefault(p => p.ProductId == id);
    if (productToUpdate != null)
    {
      productToUpdate.Name = product.Name ?? productToUpdate.Name;
      productToUpdate.Price = product.Price ?? productToUpdate.Price;
      productToUpdate.CategoryId = product.CategoryId ?? productToUpdate.CategoryId;
      productToUpdate.Quantity = product.Quantity ?? productToUpdate.Quantity;
    }
  }


  public static void DeleteProduct(int id)
  {
    var product = _products.FirstOrDefault(p => p.ProductId == id);
    if (product != null)
    {
      _products.Remove(product);
    }
  }

  public static List<Product> GetProductsByCategoryId(int categoryId)
  {
    var products = _products.Where(p => p.CategoryId == categoryId).ToList();

    return (products != null) ? products : new List<Product>();

  }

}