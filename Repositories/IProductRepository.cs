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
    
    ///This method is user for find or get student by id
    /// if it exists return @data, otherwise return @null
    Product FindById(int id);
    
    ///This method is use for save and update data in to database
    void Update(Product product);
    
    void Delete(Product product);
    
}