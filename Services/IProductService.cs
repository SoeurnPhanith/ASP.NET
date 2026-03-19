using full_structure_db.Entities;

namespace full_structure_db.Services;

public interface IProductService
{
    List<Product> GetAllProducts();
    
    Product AddProduct(Product product);

    Product GetOneProduct(int id);
    
    Product UpdateProduct(int id,Product product);
    
    void DeleteProduct(int id);
}
