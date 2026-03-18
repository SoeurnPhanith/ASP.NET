using full_structure_db.Entities;
using full_structure_db.Repositories;

namespace full_structure_db.Services.Impl;

public class ProductService : IProductService
{

    private readonly IProductRepository _productRepo;

    public ProductService(IProductRepository productRepo)
    {
        _productRepo = productRepo;
    }

    public List<Product> GetAllProducts() => _productRepo.FindAll();
    public Product AddProduct(Product product)
    { 
        _productRepo.Save(product);
        return product;
    }
}