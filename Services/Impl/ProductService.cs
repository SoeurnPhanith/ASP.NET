using System.Data;
using full_structure_db.Common;
using full_structure_db.Dtos;
using full_structure_db.Entities;
using full_structure_db.Exception;
using full_structure_db.Repositories;

namespace full_structure_db.Services.Impl;

public class ProductService : IProductService
{

    private readonly IProductRepository _productRepo;

    public ProductService(IProductRepository productRepo)
    {
        _productRepo = productRepo;
    }

    public List<ProductResponseDto> GetAllProducts()
    {
        //get all data from db
        var products = _productRepo.FindAll();
        if (!products.Any())
        {
            throw new ResourceNotFoundException("No products record");
        }

        //map from entity -> dto
        var productDtos = products.Select(p => new ProductResponseDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Quantity = p.Quantity
        }).ToList();

        return productDtos;
    }
    public ProductResponseDto AddProduct(ProductRequestDto dto)
    {
        if (_productRepo.ExistsByName(dto.Name))
        {
            throw new DuplicateResourceException("Product name already exists");
        }
        
        //map from dto -> entity
        Product product = new Product
        {
            Name = dto.Name,
            Price = dto.Price,
            Quantity = dto.Quantity
        };
        
        //save to db
        _productRepo.Save(product);
        
        //map from entity -> dto
        ProductResponseDto response = new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Quantity = product.Quantity,
            Total =  product.Total
        };
        return response;
    }

    public ProductResponseDto GetOneProduct(int id)
    {
        //find product from entity
        var product = _productRepo.FindById(id) 
                      ?? throw new ResourceNotFoundException("Product not found");
        
        //map data from entity -> response dto
        ProductResponseDto dto = new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Quantity = product.Quantity,
            Total = product.Total
        };
        return dto;
    }

    public ProductResponseDto UpdateProduct(int id, ProductRequestDto dto)
    {
        // Find product
        Product find = _productRepo.FindById(id)
                       ?? throw new ResourceNotFoundException("Product not found");

        // Check for duplicate name (optional, if updating name)
        if (_productRepo.ExistsByName(dto.Name) && dto.Name != find.Name)
        {
            throw new DuplicateResourceException("Product name already exists");
        }

        // Update entity from DTO
        find.Name = dto.Name;
        find.Price = dto.Price;
        find.Quantity = dto.Quantity;

        // Save changes
        _productRepo.Update(find);

        // Map entity → Response DTO
        return new ProductResponseDto
        {
            Id = find.Id,
            Name = find.Name,
            Price = find.Price,
            Quantity = find.Quantity
        };
    }

    public void DeleteProduct(int id)
    {
        // Find product or throw custom exception
        Product find = _productRepo.FindById(id)
                       ?? throw new ResourceNotFoundException("Product not found");

        // Delete product
        _productRepo.Delete(find);
    }
}