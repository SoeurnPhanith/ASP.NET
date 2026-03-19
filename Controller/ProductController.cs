using full_structure_db.Common;
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

    [HttpPost]
    public IActionResult AddProduct([FromBody] Product product)
    {
        try
        {
            var products = _productService.AddProduct(product);
            return Created("", new ApiResponse<Product>(products, "New Product Created Successfully"));
        }
        catch (Exception e)
        {
            return StatusCode(500, new ApiError(e.Message, 500, "Internal server error"));
        }
    }
    
    [HttpGet]
    public IActionResult ShowAllProducts()
    {
        try
        {
            var products = _productService.GetAllProducts();
            if (!products.Any())
            {
                return NotFound(new ApiError("No products found", 404));
            }
            return Ok(new ApiResponse<List<Product>>(products, "get all data success"));
        }
        catch (Exception e)
        {
            return StatusCode(500, new ApiError(e.Message, 500, details: "Internal server error"));
        }
    }

    [HttpGet("{id}")]
    public IActionResult ShowOneProduct([FromRoute] int id)
    {
        try
        {
            var product = _productService.GetOneProduct(id);
            if (product == null)
            {
                return NotFound(new ApiError("Product not found", 404));
            }

            return Ok(new ApiResponse<Product>(product, "get data success"));
        }
        catch (Exception e)
        {
            return StatusCode(500, new ApiError(e.Message, 500, "Internal server error"));
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdateProduct([FromRoute] int id, [FromBody] Product product)
    {
        try
        {
            var p = _productService.UpdateProduct(id, product);
            return Ok(new ApiResponse<Product>(p, "update data success"));
        }
        catch (Exception e)
        {
            return StatusCode(500, new ApiError(e.Message, 500, "Internal server error"));
        }
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteProduct([FromRoute] int id)
    {
        try
        {
            _productService.DeleteProduct(id);
            return Ok(new ApiResponse<string>("Product Deleted Successfully"));
        }
        catch (Exception e)
        {
            return StatusCode(500, new ApiError(e.Message, 500, "Internal server error"));
        }
    }
    
}