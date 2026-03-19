using System.ComponentModel.DataAnnotations;

namespace full_structure_db.Dtos;

public class ProductRequestDto
{
    [Required(ErrorMessage = "Field name is required")]
    [MinLength(3, ErrorMessage = "Field name must be at least 3 characters long")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Name must contain only letters")]
    public string Name { get; set; }

    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0")]
    public decimal Price { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Quantity must be >= 0")]
    public int Quantity { get; set; }
}   