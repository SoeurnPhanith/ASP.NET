namespace full_structure_db.Common;

public class ApiResponse<T>
{
    public bool Success { get; set; }  
    public string? Message { get; set; }  
    public T? Data { get; set; }         

    // Constructor for success with data
    public ApiResponse(T data, string message)
    {
        Success = true;
        Data = data;
        Message = message;
    }
    
    public ApiResponse(string message)
    {
        Success = true;
        Message = message;
        Data = default;
    }
}