using full_structure_db.Common;
using full_structure_db.Dtos;
using full_structure_db.Entities;
using full_structure_db.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace full_structure_db.Controller;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }

    
    [HttpGet]
    public IActionResult ShowAllProducts()
    {
        var product = _productService.GetAllProducts();
        return Ok(new ApiResponse<List<ProductResponseDto>>(product, "get all data success"));
    }

    [HttpGet("{id}")]
    public IActionResult ShowProductById([FromRoute] int id)
    {
        var product = _productService.GetOneProduct(id);
        return Ok(new ApiResponse<ProductResponseDto>(product, "get data success"));
    }

    [HttpPost]
    public IActionResult CreateProduct([FromBody] ProductRequestDto dto)
    {
        var product = _productService.AddProduct(dto);
        return Created("",new ApiResponse<ProductResponseDto>(product, "add data success"));
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct([FromRoute] int id, [FromBody] ProductRequestDto dto)
    {
        var product = _productService.UpdateProduct(id, dto);
        return Ok(new ApiResponse<ProductResponseDto>(product, "update data success"));
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct([FromRoute] int id)
    {
        _productService.DeleteProduct(id);
        return Ok(new ApiResponse<bool>(true, "delete data success"));
    }
    
}