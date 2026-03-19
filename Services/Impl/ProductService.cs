using full_structure_db.Common;
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

    public Product GetOneProduct(int id)
    {
        return _productRepo.FindById(id);
    }

    public Product UpdateProduct(int id, Product product)
    {
        Product findProduct = _productRepo.FindById(id);
        if (findProduct == null)
        {
            throw new Exception("Product not found");
        }
        
        findProduct.Name = product.Name;
        findProduct.Price = product.Price;
        findProduct.Quantity = product.Quantity;
        
        _productRepo.Update(findProduct);
        return findProduct;
    }

    public void DeleteProduct(int id)
    {
        Product find = _productRepo.FindById(id);
        if (find == null)
        {
            throw new Exception("Product not found");
        }
        
        _productRepo.Delete(find);
    }
}