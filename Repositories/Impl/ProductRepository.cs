using full_structure_db.Data;
using full_structure_db.Entities;

namespace full_structure_db.Repositories.Impl;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;
    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public List<Product> FindAll() => _context.Products.ToList();
    
    public void Save(Product product)
    {
        int maxId = _context.Products.Any() ? _context.Products.Max(s => s.Id) : 0;
        
        product.Id = maxId + 1;
        product.DateCreated = DateTime.UtcNow;

        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public Product FindByName(string name)
    {
        throw new NotImplementedException();
    }
}