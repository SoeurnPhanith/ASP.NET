using full_structure_db.Entities;

namespace full_structure_db.Services;

public interface IProductService
{
    List<Product> GetAllProducts();
    
    Product AddProduct(Product product);
}
