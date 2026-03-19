namespace full_structure_db.Exception;

public class DuplicateResourceException : System.Exception
{
    public DuplicateResourceException(string message) : base(message) { }
}