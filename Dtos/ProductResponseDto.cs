namespace full_structure_db.Dtos;

public class ProductResponseDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public decimal Price { get; set; }
    
    public int Quantity { get; set; }
    
    public decimal Total { get; set; }
}
