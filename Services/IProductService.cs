using full_structure_db.Dtos;
using full_structure_db.Entities;

namespace full_structure_db.Services;

public interface IProductService
{
    List<ProductResponseDto> GetAllProducts();
    
    ProductResponseDto AddProduct(ProductRequestDto dto);

    ProductResponseDto GetOneProduct(int id);
    
    ProductResponseDto UpdateProduct(int id,ProductRequestDto dto);
    
    void DeleteProduct(int id);
}
