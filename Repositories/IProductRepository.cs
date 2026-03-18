using full_structure_db.Entities;

namespace full_structure_db.Repositories;

public interface IProductRepository
{
   
    /// This method is use for get all data from database
    /// return to collection list
    List<Product> FindAll();
    
    ///This methos is user for save or add product and
    /// auto-increment of id
    /// and generate time now
    void Save(Product product);
    
    Product FindByName(string name);
}