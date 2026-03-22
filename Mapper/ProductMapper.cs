using full_structure_db.Dtos;
using full_structure_db.Entities;

namespace full_structure_db.Mapper;

public static class ProductMapper
{
    //a Mapper folder is usually a place where we put mapping logic between different types of object

    ///This methos is map data from request dto to entities
    public static Product ToEntity(ProductRequestDto dto)
    {
        return new Product
        {
            Name = dto.Name,
            Price = dto.Price,
            Quantity = dto.Quantity
        };
    }


    ///This method is map data from entities to response dto
    public static ProductResponseDto ToResponseDto(Product product)
    {
        return new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            Quantity = product.Quantity,
            Total = product.Total
        };
    }


    ///This method is use for update data in entity using mapper for map data
    public static Product UpdateEntity(ProductRequestDto dto, Product entity)
    {
        entity.Name = dto.Name;
        entity.Price = dto.Price;
        entity.Quantity = dto.Quantity;
        
        return entity;
    }
}