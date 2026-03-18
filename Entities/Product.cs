namespace full_structure_db.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public DateTime DateCreated { get; set; }

    // Calculate automatically
    public decimal Total => Price * Quantity;
}